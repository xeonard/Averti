﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Phidgets.Events;
using Phidgets;

namespace AvertiFestivalApplication
{
    public partial class FestivalAppForm : Form
    {
        List<Article> articles = new List<Article>();
        private RFID RfidCheckin;

        DBHandler db = new DBHandler();

        public FestivalAppForm()
        {
            InitializeComponent();

            RfidCheckin = new RFID();
            //TabControl.TabPages.Remove(tabSales);

        //    //code for sales page
        //    try
        //    {
        //        List <string > list = new List<string>(db.InfoArticle)
                
        //        foreach (Article a in db.InfoArticle())
        //        {
        //            this.cbxNameArticles.Items.Add(a.Name);
        //        }
        //    }
        //    catch(NullReferenceException)
        //    {
        //        MessageBox.Show("There is no Articles in database");
        //    }

        //    dataGridView1.DataSource = db.GetDatatable("event");
        }

        public FestivalAppForm(String personalID)
        {
            InitializeComponent();

            // check id to see which tabs to remove

            TabControl.TabPages.Remove(tabSales); // how to remove a tab

        }

        private void FestivalAppForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopRFID();
            Thread thread = new Thread(new ThreadStart(LogInThread));
            thread.Start();
        }

        private static void LogInThread()
        {
            Application.Run(new LogInForm());
        }

        private void btnCheckTicket_Click(object sender, EventArgs e)
        {
                switch (db.CheckTicket(this.tbxCheckInID.Text))
                {
                    case -1:
                        // lbStatus.Text = "Ticket info: invalid ticket"; 
                        tabCheckIn.BackColor = Color.Red;
                        RfidCheckin.Tag -= new TagEventHandler(ProcessThisTag);
                        break;
                    case 1:
                        //  lbStatus.Text = "Ticket info: visitor hasnt arrived";
                        tabCheckIn.BackColor = Color.Green;
                        StartRFID();
                        RfidCheckin.Tag += new TagEventHandler(ProcessThisTag);
                        RfidCheckin.Tag -= new TagEventHandler(RemoveThisTag);
                        break;                        

                    case 2:
                        // lbStatus.Text = "Ticket info: visitor has arrived";
                        tabCheckIn.BackColor = Color.Red;
                        RfidCheckin.Tag -= new TagEventHandler(ProcessThisTag);
                        break;
                    case 3:
                        //  lbStatus.Text = "Ticket info: visitor left";
                        tabCheckIn.BackColor = Color.Green;
                        StartRFID();
                        RfidCheckin.Tag -= new TagEventHandler(RemoveThisTag);
                        RfidCheckin.Tag += new TagEventHandler(ProcessThisTag);


                        break;
                }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            StartRFID();
            lbUnassigned.Visible = false;
            tabCheckIn.BackColor = this.BackColor;

            RfidCheckin.Tag -= new TagEventHandler(ProcessThisTag);
            RfidCheckin.Tag += new TagEventHandler(RemoveThisTag);
           
            
        }

        private void StartRFID()
        {
            try
            {
                this.StopRFID();
                RfidCheckin.open();
                RfidCheckin.waitForAttachment(1500);
                RfidCheckin.Antenna = true;
                RfidCheckin.LED = true;

            }
            catch (PhidgetException)
            {
                MessageBox.Show("No RFID connection");
            }
        }

        private void StopRFID()
        {

                if (RfidCheckin.Attached)
                {
                    RfidCheckin.Antenna = false;
                    RfidCheckin.LED = false;
                    RfidCheckin.close();
                }

        }

        private void ProcessThisTag(Object sender, TagEventArgs e) 
        {
            if (db.AssignRFID(this.tbxCheckInID.Text, e.Tag))
            {
                lbAssigned.Text = "RFID: Assigned to " + db.GetName(e.Tag);
                tabCheckIn.BackColor = this.BackColor;
                lbUnassigned.Visible = false;
                lbAssigned.Visible = true;


            }
            
        }

        private void RemoveThisTag(Object sender, TagEventArgs e)
        {
           if (db.UnassignRFID(e.Tag))
            {
                lbAssigned.Visible = false;

                lbUnassigned.Visible = true;
            }
            //this.StopRFID();
        }
        private void cbxDTInfoType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxDTSelectEvent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void btnSTAddToOrder_Click(object sender, EventArgs e)
        {
            double overallPrice = 0;
            if (cbxSortArticle.SelectedItem != null && cbxNameArticles.SelectedItem != null && NUDSTArticleAmount.Value > 0)
            {
                foreach (var item in articles)
                {
                    if (item.Name == cbxNameArticles.SelectedItem && item.SoortArticle == cbxSortArticle.SelectedItem)
                    {
                        lbOrder.Items.Add("Sort: ");
                        lbOrder.Items.Add(item.SoortArticle);
                        lbOrder.Items.Add("Stock:");
                        lbOrder.Items.Add(Convert.ToString(NUDSTArticleAmount.Value));
                        lbOrder.Items.Add("Name:");
                        lbOrder.Items.Add(item.Name);
                        lbOrder.Items.Add("Price:");
                        lbOrder.Items.Add(Convert.ToString(item.Price));
                        lbOrder.Items.Add("Totale Price:");
                        double totalePrice = item.Price * Convert.ToInt32(NUDSTArticleAmount.Value);
                        overallPrice = overallPrice + totalePrice;
                        lbOrder.Items.Add(Convert.ToString(totalePrice));
                        lbOrder.Items.Add("\n");

                        double newWalletCredit = db.WalletBalance(tbxRFID.Text) - overallPrice;
                        lblSTNewWalletCredit.Text = "Your new balance is: "+ Convert.ToString(newWalletCredit);
                    }



                }
            }
        }

        private void btnETSelectEvent_Click(object sender, EventArgs e)
        {

        }

        private void btnETNewEvent_Click(object sender, EventArgs e)
        {

        }

        private void tabEvent_Click(object sender, EventArgs e)
        {
            List<string> eventsq = db.GetEvents();

            List<Event> events = new List<Event>();
            for (int i = 0; i < eventsq.Count -1; i = i+2)
            {
                Event newevent = new Event(eventsq[i+1],Convert.ToInt32(eventsq[i]));
                events.Add(newevent);
            }
            foreach (var item in events)
            {
                this.cmbxEventSelectEvent.Items.Add(item.Name);   
            }
            

        }


        private void btnGoToDetails_Click(object sender, EventArgs e)
        {
            MessageBox.Show("" + "" + "");
        }


        private void btnShow_Click(object sender, EventArgs e)
        {
            if(cbxDTInfoType.SelectedIndex==1)
            {
                lblPersonID.Visible = true;
                tbxDTPErsonID.Visible = true;
                lblSelectEvent.Visible = false;
                cbxDTSelectEvent.Visible = false;
                lblSelectCSpot.Visible = false;
                cbxDTSelectCampSpot.Visible = false;
                lblSelectArticle.Visible = false;
                cbxDTSelectArticle.Visible = false ;
            }
            else 
                if(cbxDTInfoType.SelectedIndex==0)
                {
                    lblSelectEvent.Visible = true;
                    cbxDTSelectEvent.Visible = true;
                    lblPersonID.Visible = false;
                    tbxDTPErsonID.Visible = false;
                    lblSelectCSpot.Visible = false;
                    cbxDTSelectCampSpot.Visible = false;
                    lblSelectArticle.Visible = false;
                    cbxDTSelectArticle.Visible = false;
                }
                else if(cbxDTInfoType.SelectedIndex == 2)
                {
                    lblSelectCSpot.Visible = true;
                    cbxDTSelectCampSpot.Visible = true;
                    lblSelectEvent.Visible = false;
                    cbxDTSelectEvent.Visible = false;
                    lblPersonID.Visible = false;
                    tbxDTPErsonID.Visible = false;
                    lblSelectArticle.Visible = false;
                    cbxDTSelectArticle.Visible = false;
                }
                else if(cbxDTInfoType.SelectedIndex == 3)
                {
                    lblSelectArticle.Visible = true;
                    cbxDTSelectArticle.Visible = true;
                    lblSelectCSpot.Visible = false;
                    cbxDTSelectCampSpot.Visible = false;
                    lblSelectEvent.Visible = false;
                    cbxDTSelectEvent.Visible = false;
                    lblPersonID.Visible = false;
                    tbxDTPErsonID.Visible = false;
                }
        }

        private void btnSTSeeDetails_Click(object sender, EventArgs e)
        {
            double balance = db.WalletBalance(tbxRFID.Text);
            this.lbWallet.Text = balance.ToString();
        }

        

        private void tabSales_Click(object sender, EventArgs e)
        {

            cbxSortArticle.Items.Clear();
            cbxNameArticles.Items.Clear();
            List<string>[] listOfSortArticle = new List<string>[5];
            listOfSortArticle = db.InfoArticle();
            for (int i = 0; i < listOfSortArticle.Length - 1; i++)
            {
                Article A = new Article(Convert.ToInt32(listOfSortArticle[i][0]), listOfSortArticle[i][1], listOfSortArticle[i][2], Convert.ToInt32(listOfSortArticle[i][3]), Convert.ToDouble(listOfSortArticle[i][4]));
                articles.Add(A);
            }
            foreach (var item in articles)
            {
                cbxSortArticle.Items.Add(item.SoortArticle);
                cbxNameArticles.Items.Add(item.Name);
            }
        }
        private void btnSTCompleteOrder_Click(object sender, EventArgs e)
        {
            string s = tbxRFID.Text;
            int personalID = db.personalID(s);
            int transactionID = db.TransactionID();
            Double cost = 0;
            int articleID = 0;
             List<string>[] listOfSortArticle = new List<string>[5];
            listOfSortArticle = db.InfoArticle();
            for (int i = 0; i < listOfSortArticle.Length - 1; i++)
            {
                Article A = new Article(Convert.ToInt32(listOfSortArticle[i][0]), listOfSortArticle[i][1], listOfSortArticle[i][2], Convert.ToInt32(listOfSortArticle[i][3]), Convert.ToDouble(listOfSortArticle[i][4]));
                articles.Add(A);
            }
           
            foreach (var item in articles)
            {
              
              double costItem = item.Price;
                cost = costItem;
                articleID = item.ArticleID;
            }
            db.InsertToTransaction(transactionID, personalID, " article", cost, DateTime.Now.Date);
            db.InsertToTransactionarticle(transactionID, articleID,Convert.ToInt32( NUDSTArticleAmount.Value));
        }

        private void btnSTCancel_Click(object sender, EventArgs e)
        {
            tbxRFID.Clear();
            cbxNameArticles.Text = "";
            cbxSortArticle.Text = "";
            lbOrder.Items.Clear();
            lbWallet.Text = "";
            lblSTNewWalletCredit.Text = "Wallet Credit after purchase:";

            
        }
    }
}
