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
        List<Order> orders = new List<Order>();
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
            RfidCheckin.Tag += new TagEventHandler(this.ShowPersonWallet);
            int ArticleID = db.ArticleID();
          

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
                List<Article> SortArticles = new List<Article>();
                SortArticles = db.SortArticle(ArticleID);
               
                foreach (var item in  db.SortArticle(ArticleID))
                {
                    this.cbxSortArticle.Items.Add(item.SoortArticle);
                }
                
                
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("There is no Articles in database");
            }
            //name dropbox
            try
            {
                List <Article> Namearticle = new List<Article>();
                Namearticle = db.NameArticle(ArticleID);
                
                foreach (var item in  Namearticle)
                {
                    this.cbxNameArticles.Items.Add(item.Name);
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
        private void ShowPersonWallet(Object sender, TagEventArgs e)
        {
            string s = tbxRFID.Text;
            double balance = db.WalletBalance(s);
            int personalID = db.personalID(s);
            int sumPriceOfOrders = db.SumOrders(personalID);
            double newBalance = balance - sumPriceOfOrders;
            if (newBalance > 2.5)
            {
                this.lbWallet.Text = newBalance.ToString();
            }

            if (newBalance < 2.5)
            {
                this.lbWallet.Text = Convert.ToString(db.WalletBalance(s));
                btnSTAddToOrder.Enabled = false;
                btnSTCompleteOrder.Enabled = false;
                MessageBox.Show(" You have not enough credit to by a article. You can charge your credit via our website");
                tbxRFID.Text = "";
                lbWallet.Text = "";
                btnSTCompleteOrder.Enabled = true;
                btnSTAddToOrder.Enabled = true;
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
            lbOrder.Items.Clear();
            int ArticleID = db.ArticleID();
            lbOrder.Items.Add("Your selected articles: ");
            if (cbxSortArticle.SelectedItem != null && cbxNameArticles.SelectedItem != null && NUDSTArticleAmount.Value > 0)
            {
                articles = db.InfoArticle( ArticleID);

                int counter = 0;
                double totalePrice = 0;
                foreach (var item in articles)
                {

                    if (item.Name == cbxNameArticles.SelectedItem.ToString() && item.SoortArticle == cbxSortArticle.SelectedItem.ToString())
                    {
                        Order order = new Order(item, Convert.ToInt32(NUDSTArticleAmount.Value));
                        orders.Add(order);
                        

                    }
                    
                }
                foreach (var orderitem in orders)
                {
                    counter++;
                    lbOrder.Items.Add("");
                    lbOrder.Items.Add(counter.ToString() + ":   " + orderitem.Article.SoortArticle + "( " + orderitem.Article.Name + " ) " + "Stock:  " + Convert.ToString(orderitem.Quantity) + "   Price:  €" + Convert.ToString(orderitem.Article.Price));
                    lbOrder.Items.Add("");
                    
                    totalePrice = orderitem.Article.Price * Convert.ToInt32(NUDSTArticleAmount.Value);
                    overallPrice = overallPrice + totalePrice;
                    lbOrder.Items.Add("\n");
                }
                lbOrder.Items.Add("***********************");
                lbOrder.Items.Add("Totale Price:   € " + Convert.ToString(overallPrice));
                lbOrder.Items.Add("\n");
                if (overallPrice > Convert.ToInt32(lbWallet.Text))
                {
                    btnSTCompleteOrder.Enabled = false;
                    MessageBox.Show("your credit is not enough to buy your orders");
                    
                }


                double newWalletCredit = Convert.ToInt32(lbWallet.Text) - overallPrice;
                lblSTNewWalletCredit.Text = "Your new balance is: " + Convert.ToString(newWalletCredit);


            }

            else
            {
                MessageBox.Show("Pleas choose a article or the quantity");
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
                    // this.tbxETEventDate.Text = item.Date.ToString();
                    // this.tbxETEventMinage.Text = item.Minage.ToString();

                }
            }
        }

        private void btnETNewEvent_Click(object sender, EventArgs e)
        {
            string name = this.tbxETEventName.Text;
            string location = this.tbxETLocation.Text;
            int maxticket = Convert.ToInt32(this.tbxETMaxTickets.Text);
            int maxcamp = Convert.ToInt32(this.tbxETMaxCamp.Text);
            string descript = this.richTbxETDescription.Text;
            // string date = this.tbxETEventDate.Text;
            // int minage = Convert.ToInt32( this.tbxETEventMinage.Text);
            try
            {
                //newEvent = new Event(minage,date,location,maxticket,name,maxcamp,descript);

            }
            catch (Exception)
            {

                MessageBox.Show("all fields should be filled");
            }


        }

        private void tabEvent_Click(object sender, EventArgs e)
        {
            List<string>[] eventsq = db.GetEvents();


            for (int i = 0; i < eventsq.Length - 1; i++)
            {
                Event newevent = new Event(Convert.ToInt32(eventsq[i][0]), Convert.ToInt32(eventsq[i][1]), eventsq[i][2], eventsq[i][3], Convert.ToInt32(eventsq[i][4]), eventsq[i][5], Convert.ToInt32(eventsq[i][6]), eventsq[i][7]);

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
            this.richTbxETDescription.Clear();
            //how to complete this? 
            //this.tbxETEventDate.Text = "";

            //this.tbxETEventMinage.Text = "";
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
            string s = tbxRFID.Text;
            double balance = db.WalletBalance(s);
            int personalID = db.personalID(s);
            int sumPriceOfOrders = db.SumOrders(personalID);
            double newBalance = balance - sumPriceOfOrders;
            if (newBalance > 2.5)
            {
                this.lbWallet.Text = newBalance.ToString();
            }

            if (newBalance < 2.5)
            {
                this.lbWallet.Text = Convert.ToString(db.WalletBalance(s));
                btnSTAddToOrder.Enabled = false;
                btnSTCompleteOrder.Enabled = false;
                MessageBox.Show(" You have not enough credit to by a article. You can charge your credit via our website");
                tbxRFID.Text = "";
                lbWallet.Text = "";
                btnSTCompleteOrder.Enabled = true;
                btnSTAddToOrder.Enabled = true;
            }

        }



        private void btnSTCompleteOrder_Click(object sender, EventArgs e)
        {
            string s = tbxRFID.Text;
            int personalID = db.personalID(s);
            int transactionID = db.TransactionID();
            Double cost = 0;
            int articleID = 0;
            int ArticleID = db.ArticleID();
            List<Article> listOfSortArticle = new List<Article>();
            listOfSortArticle = db.InfoArticle(ArticleID);

            foreach (var item in articles)
            {
                if (item.Name == cbxNameArticles.SelectedItem.ToString() && item.SoortArticle == cbxSortArticle.SelectedItem.ToString())
                {
                    double costItem = item.Price;
                    cost = costItem;

                    articleID = item.ArticleID;
                }
            }

            db.InsertToTransaction(transactionID, personalID, " article", cost, DateTime.Now);
            db.InsertToTransactionarticle(transactionID, articleID, Convert.ToInt32(NUDSTArticleAmount.Value));
            tbxRFID.Text = "";
            lbOrder.Items.Clear();
            lblSTNewWalletCredit.Text = "";
            lbWallet.Text = "";

        }

        private void btnSTCancel_Click(object sender, EventArgs e)
        {
            tbxRFID.Clear();
            cbxNameArticles.Text = "";
            cbxSortArticle.Text = "";
            lbOrder.Items.Clear();
            lbWallet.Text = "";
            lblSTNewWalletCredit.Text = "";


        }



        private void btnShowSQL_Click(object sender, EventArgs e)
        {
            switch (cbxDTInfoType.SelectedIndex)
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
                        catch (NullReferenceException)
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
                        catch (NullReferenceException)
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

        private void tabSales_Click(object sender, EventArgs e)
        {

            btnSTCompleteOrder.Enabled = false;
            btnSTAddToOrder.Enabled = false;
        }

        private void FestivalAppForm_Load(object sender, EventArgs e)
        {

            btnSTCompleteOrder.Enabled = false;
            btnSTAddToOrder.Enabled = false;

        }

        private void cbxSortArticle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSortArticle.SelectedItem != null && cbxNameArticles.SelectedItem != null && NUDSTArticleAmount.Value > 0)
            {
                btnSTAddToOrder.Enabled = true;
                btnSTCompleteOrder.Enabled = true;
            }
        }

        private void cbxNameArticles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSortArticle.SelectedItem != null && cbxNameArticles.SelectedItem != null && NUDSTArticleAmount.Value > 0)
            {
                btnSTAddToOrder.Enabled = true;
                btnSTCompleteOrder.Enabled = true;
            }
        }

        private void NUDSTArticleAmount_ValueChanged(object sender, EventArgs e)
        {
            if (cbxSortArticle.SelectedItem != null && cbxNameArticles.SelectedItem != null && NUDSTArticleAmount.Value > 0)
            {
                btnSTAddToOrder.Enabled = true;
                btnSTCompleteOrder.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //foreach (var item in lbOrder.SelectedItems)
            //{
            //    if (item)
            //}
        }
    }
}
