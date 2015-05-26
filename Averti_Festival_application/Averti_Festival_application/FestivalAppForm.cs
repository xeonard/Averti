using System;
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
        Event newEvent;
        DBHandler db = new DBHandler();
        List<Event> events;
        public FestivalAppForm()
        {
           events = new List<Event>();
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
        //    TabControl.TabPages.Remove(tabSales);

            //dbView filling dropboxes

            //event dropbox
            try
            {
                //foreach (Article a in db.InfoArticle())
                //{
                //    this.cbxNameArticles.Items.Add(a.Name);
                //}

                foreach (string a in db.GetInfoTable("event", "eventID"))
                {
                    this.cbxDTSelectEvent.Items.Add(a);
                }

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("There is no events in database");
            }

            //camp dropbox
            try
            {
                foreach (string a in db.GetInfoTable("camp", "campID"))
                {
                    this.cbxDTSelectCampSpot.Items.Add(a);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("There is no events in database");
            }

            //article dropbox
            try
            {
                foreach (string a in db.GetInfoTable("article", "ArticleID"))
                {
                    this.cbxDTSelectArticle.Items.Add(a);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("There is no Articles in database");
            }

            //sort dropbox
            try
            {
                foreach (string a in db.GetInfoTable("article", "SortArticle"))
                {
                    this.cbxSortArticle.Items.Add(a);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("There is no Articles in database");
            }
            //name dropbox
            try
            {
                foreach (string a in db.GetInfoTable("article", "name"))
                {
                    this.cbxNameArticles.Items.Add(a);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("There is no Articles in database");
            }
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
                    if (item.Name == cbxNameArticles.SelectedItem.ToString() && item.SoortArticle == cbxSortArticle.SelectedItem.ToString())
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
                        lblSTNewWalletCredit.Text = "Your new balance is: " + Convert.ToString(newWalletCredit);
                    }



                }
            }
        }

        private void btnETSelectEvent_Click(object sender, EventArgs e)
        {
            foreach (var item in events)
            {
                if (this.cbxDTSelectEvent.SelectedItem == item.Name)
                {
                    this.tbxETEventName.Text = item.Name;
                    this.tbxETLocation.Text = item.Location;
                    this.tbxETMaxTickets.Text = item.Maxtickets.ToString();
                    this.tbxETMaxCamp.Text = item.Maxcamping.ToString();
                    this.richTbxETDescription.AppendText(item.Description);
                    this.tbxETEventDate.Text = item.Date.ToString();
                    this.tbxETEventMinage.Text = item.Minage.ToString();
                    
                }
            }
        }

        private void btnETNewEvent_Click(object sender, EventArgs e)
        {
            string name =  this.tbxETEventName.Text;
            string location = this.tbxETLocation.Text;
            int maxticket = Convert.ToInt32( this.tbxETMaxTickets.Text);
            int maxcamp = Convert.ToInt32(this.tbxETMaxCamp.Text);
            string descript = this.richTbxETDescription.Text;
            string date = this.tbxETEventDate.Text;
            int minage = Convert.ToInt32( this.tbxETEventMinage.Text);
            try 
	{	        
		newEvent = new Event(minage,date,location,maxticket,name,maxcamp,descript);
               
	}
	catch (Exception)
	{
		
		MessageBox.Show("all fields should be filled");
	}
            

        }

        private void tabEvent_Click(object sender, EventArgs e)
        {
            List<string>[] eventsq = db.GetEvents();

      
            for (int i = 0; i < eventsq.Length -1; i++)
            {
                Event newevent = new Event(Convert.ToInt32( eventsq[i][0]), Convert.ToInt32(eventsq[i][1]), eventsq[i][2], eventsq[i][3], Convert.ToInt32(eventsq[i][4]), eventsq[i][5], Convert.ToInt32(eventsq[i][6]), eventsq[i][7]);

                events.Add(newevent);
            }
            foreach (var item in events)
            {
                this.cmbxEventSelectEvent.Items.Add(item.Name);
            }
            

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void btnETDeleteEvent_Click(object sender, EventArgs e)
        {

            foreach (var item in events)
            {
                if (this.cbxDTSelectEvent.SelectedItem == item.Name)
                {
                    db.deleteEvent(item.Eventid);
                }
            }
        }

        private void cmbxEventSelectEvent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpETEventDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            newEvent = null;
            this.tbxETEventName.Text = "";
            this.tbxETLocation.Text = "";
            this.tbxETMaxTickets.Text = "";
            this.tbxETMaxCamp.Text = "";
            //check this pls
            this.richTbxETDescription.Clear() ;
            //how to complete this? 
            this.tbxETEventDate.Text = "";

            this.tbxETEventMinage.Text = "";
        }

        private void btnETSave_Click(object sender, EventArgs e)
        {
            if (newEvent != null)
            {
                db.saveEvent(newEvent.Minage, newEvent.Date, newEvent.Location, newEvent.Maxtickets, newEvent.Name, newEvent.Maxcamping, newEvent.Description);
            }
        }

        private void btnGoToDetails_Click(object sender, EventArgs e)
        {
            MessageBox.Show("" + "" + "");
        }

        private void hide()
        {
            lblPersonID.Visible = false;
            tbxDTPErsonID.Visible = false;
            lblSelectEvent.Visible = false;
            cbxDTSelectEvent.Visible = false;
            lblSelectCSpot.Visible = false;
            cbxDTSelectCampSpot.Visible = false;
            lblSelectArticle.Visible = false;
            cbxDTSelectArticle.Visible = false;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            int index = cbxDTInfoType.SelectedIndex;
            switch (index)
            {
                case 1:
                    {
                        hide();
                        lblPersonID.Visible = true;
                        tbxDTPErsonID.Visible = true;
                        break;
                    }
                case 0:
                    {
                        hide();
                        lblSelectEvent.Visible = true;
                        cbxDTSelectEvent.Visible = true;
                        break;
                    }
                case 2:
                    {
                        hide();
                        lblSelectCSpot.Visible = true;
                        cbxDTSelectCampSpot.Visible = true;
                        break;
                    }
                case 3:
                    {
                        hide();
                        lblSelectArticle.Visible = true;
                        cbxDTSelectArticle.Visible = true;
                        break;
                    }
            }
        }

        private void btnSTSeeDetails_Click(object sender, EventArgs e)
        {
            double balance = db.WalletBalance(tbxRFID.Text);
            this.lbWallet.Text = balance.ToString();
        }

        

        private void tabSales_Click(object sender, EventArgs e)
        {

            //cbxSortArticle.Items.Clear();
            //cbxNameArticles.Items.Clear();
            //articles = db.InfoArticle();
            //foreach (var item in articles)
            //{
            //    cbxSortArticle.Items.Add(item.SoortArticle);
            //    cbxNameArticles.Items.Add(item.Name);
            //}
        }
        private void btnSTCompleteOrder_Click(object sender, EventArgs e)
        {
        //    string s = tbxRFID.Text;
        //    int personalID = db.personalID(s);
        //    int transactionID = db.TransactionID();
        //    Double cost = 0;
        //    int articleID = 0;
        //     List<Article> listOfSortArticle = new List<Article>;
        //    listOfSortArticle = db.InfoArticle();
        //    for (int i = 0; i < listOfSortArticle.Length - 1; i++)
        //    {
        //        Article A = new Article(Convert.ToInt32(listOfSortArticle[i][0]), listOfSortArticle[i][1], listOfSortArticle[i][2], Convert.ToInt32(listOfSortArticle[i][3]), Convert.ToDouble(listOfSortArticle[i][4]));
        //        articles.Add(A);
        //    }
           
        //    foreach (var item in articles)
        //    {
              
        //      double costItem = item.Price;
        //        cost = costItem;
        //        articleID = item.ArticleID;
        //    }
        //    db.InsertToTransaction(transactionID, personalID, " article", cost, DateTime.Now.Date);
        //    db.InsertToTransactionarticle(transactionID, articleID,Convert.ToInt32( NUDSTArticleAmount.Value));
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

        private void FestivalAppForm_Load(object sender, EventArgs e)
        {

        }

        private void btnShowSQL_Click(object sender, EventArgs e)
        {
            switch(cbxDTInfoType.SelectedIndex)
            {
                case 0:
                    { 
                        try
                        {
                            // event table
                            string where = "Where eventID = " + cbxDTSelectEvent.SelectedItem.ToString() + " ";
                            dataGridView1.DataSource = db.GetDatatable("event", where);
                        }
                        catch (NullReferenceException)
                        {

                        }
                        break;
                    }
                case 1:
                    {
                        try
                        {
                        //person table
                        string where = "Where personalID = " + tbxDTPErsonID.Text + " ";
                        dataGridView1.DataSource = db.GetDatatable("person", where);
                        break;
                            }
                        catch(NullReferenceException)
                        {

                        }
                        break;
                    }
                case 2:
                    {
                        try
                        {
                            //camping table
                            string where = "Where campID = " + cbxDTSelectCampSpot.SelectedItem.ToString() + " ";
                            dataGridView1.DataSource = db.GetDatatable("camp", where);
                            break;
                        }
                        catch(NullReferenceException)
                        {

                        }
                        break;
                    }
                case 3:
                    {
                        try
                        {
                            //article table
                            string where = "Where ArticleID = " + cbxDTSelectArticle.SelectedItem.ToString() + " ";
                            dataGridView1.DataSource = db.GetDatatable("article", where);
                            break;
                        }
                        catch (NullReferenceException)
                        {

                        }
                        break;
                    }
            }
        }
    }
}
