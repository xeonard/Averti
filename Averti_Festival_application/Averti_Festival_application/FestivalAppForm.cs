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
        double overallPrice = 0;
        double totalePrice = 0;
        List<Order> orders = new List<Order>();
        List<Article> articles = new List<Article>();
        List<Article> NameArticles = new List<Article>();
        private RFID RfidCheckin;
        Event newEvent;
        DBHandler db = new DBHandler();
        List<Article> Namearticle;
        List<Article> SortArticles;
        List<string>[] eventsq;
        List<Event> events = new List<Event>();


        public FestivalAppForm()
        {
            InitializeComponent();
            refreshEventsList();

            RfidCheckin = new RFID();
            RfidCheckin.Tag += new TagEventHandler(this.ShowPersonWallet);


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
                SortArticles = new List<Article>();
                SortArticles = db.SortArticle();

                foreach (var item in db.SortArticle())
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

                Namearticle = new List<Article>();
                //List<Article> Namearticle2 = new List<Article>();
                foreach (var item in Namearticle)
                {
                    int ArticleID = db.ArticleID();

                    if (ArticleID == 1)
                    {
                        this.cbxNameArticles.Items.Add(item.Name);
                    }
                    else if (ArticleID == 2)
                    {
                        this.cbxNameArticles.Items.Add(item.Name);
                    }

                }
                //Namearticle = db.NameArticle(ArticleID);
                //Namearticle2 = db.NameArticle(ArticleID);
                //foreach (var item in Namearticle)
                //{
                //    if (cbxSortArticle.SelectedText == "BBQ")
                //    {
                //        ArticleID = 1;

                //        this.cbxNameArticles.Items.Add(item.Name);
                //    }
                //}

                //foreach (var item in Namearticle2)
                //{
                //    if (cbxSortArticle.SelectedText == "Drink")
                //{
                //    ArticleID = 2;

                //     this.cbxNameArticles.Items.Add(item.Name);

                //}

                //	}      
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("There is no Articles in database");
            }
        }

        #region Login / CheckIn

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

        private static void LogInThread()
        {
            Application.Run(new LogInForm());
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
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            StartRFID();
            lbUnassigned.Visible = false;
            tabCheckIn.BackColor = this.BackColor;

            RfidCheckin.Tag -= new TagEventHandler(ProcessThisTag);
            RfidCheckin.Tag += new TagEventHandler(RemoveThisTag);


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
        #endregion

        #region Sales

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

        private void btnSTAddToOrder_Click(object sender, EventArgs e)
        {

            int counter = 0;
            int KindOfArticleID = db.KindOfArticleID();
            lbOrder.Items.Clear();
            int ArticleID = db.ArticleID();

            if (cbxSortArticle.SelectedItem != null && cbxNameArticles.SelectedItem != null && NUDSTArticleAmount.Value > 0)
            {
                articles = db.SortArticle();
                if (cbxSortArticle.SelectedItem.ToString() == "BBQ")
                {
                    ArticleID = 1;
                }
                if (cbxSortArticle.SelectedItem.ToString() == "Drink")
                {
                    ArticleID = 2;
                }
                NameArticles = db.NameArticle(ArticleID);



                foreach (var item in NameArticles)
                {
                    foreach (var items in articles)
                        if (item.Name == cbxNameArticles.SelectedItem.ToString() && items.SoortArticle == cbxSortArticle.SelectedItem.ToString())
                        {

                            Order order = new Order(item, Convert.ToInt32(NUDSTArticleAmount.Value));

                            orders.Add(order);
                            totalePrice = order.Article.Price * Convert.ToInt32(NUDSTArticleAmount.Value);
                            overallPrice = overallPrice + totalePrice;
                        }

                }


                lbOrder.Items.Clear();

                lbOrder.Items.Add("Your selected articles: ");
                foreach (var orderitem in orders)
                {
                    counter++;
                    lbOrder.Items.Add("");
                    lbOrder.Items.Add(counter.ToString() + ":   " + orderitem.Article.SoortArticle + "( " + orderitem.Article.Name + " ) " + "Stock:  " + Convert.ToString(orderitem.Quantity) + "   Price:  €" + Convert.ToString(orderitem.Article.Price));
                    lbOrder.Items.Add("");


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
                MessageBox.Show("Please choose an article or the quantity");
            }
            btnSTCompleteOrder.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            int result;
            if (int.TryParse(lbOrder.SelectedItem.ToString().Substring(0, 1), out result))
            {
                int item = Convert.ToInt32(lbOrder.SelectedItem.ToString().Substring(0, 1)) - 1;
                overallPrice = overallPrice - (orders[item].Article.Price * orders[item].Quantity);
                totalePrice = totalePrice + (orders[item].Article.Price * orders[item].Quantity);
                orders.RemoveAt(Convert.ToInt32(item));
                lbOrder.Items.Clear();
                lbOrder.Items.Add("Your selected articles: ");
                int counter = 0;
                foreach (var orderitem in orders)
                {
                    counter++;
                    lbOrder.Items.Add("");
                    lbOrder.Items.Add(counter.ToString() + ":   " + orderitem.Article.SoortArticle + "( " + orderitem.Article.Name + " ) " + "Stock:  " + Convert.ToString(orderitem.Quantity) + "   Price:  €" + Convert.ToString(orderitem.Article.Price));
                    lbOrder.Items.Add("");


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
                btnSTCompleteOrder.Enabled = true;
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

        private void tabSales_Click(object sender, EventArgs e)
        {

            btnSTCompleteOrder.Enabled = false;
            btnSTAddToOrder.Enabled = false;
        }

        #endregion

        #region Event

        private void refreshEventsList()
        {
            events = db.GetEvents();
            //    TabControl.TabPages.Remove(tabSales);
            this.listBoxEventSelect.Items.Clear();
            foreach (var item in events)
            {
                this.listBoxEventSelect.Items.Add(item.Name);
            }
        }

        private void cbxDTInfoType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxDTSelectEvent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Filllistbox()
        {

        }

        private void btnETSelectEvent_Click(object sender, EventArgs e)
        {
            listBoxEventSelect.Items.Clear();

            foreach (var item in events)
            {
                listBoxEventSelect.Items.Add(item.Name);
            }
        }

        private void btnETNewEvent_Click(object sender, EventArgs e)
        {

            this.tabNewEvent.Visible = !this.tabNewEvent.Visible;

            if (this.tabNewEvent.Visible == true)
            {
                this.btnETNewEvent.Text = "Hide New Event";
            }
            else
            {
                this.btnETNewEvent.Text = "New Event";
            }
        }

        private void tabEvent_Click(object sender, EventArgs e)
        {

        }


        private void cmbxEventSelectEvent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpETEventDate_ValueChanged(object sender, EventArgs e)
        {

        }


        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            newEvent = null;
            this.tbxETEventName.Text = "";
            this.tbxETLocation.Text = "";
            this.tbxETMaxTickets.Text = "";
            this.tbxETMaxCamp.Text = "";
            this.richTbxETDescription.Clear();
            this.tbxETdate.Value = DateTime.Now;
            this.tbxETEventMinage.Text = "";
        }

        private void btnETSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                string name = this.tbxETEventName.Text;
                string location = this.tbxETLocation.Text;
                int maxticket = Convert.ToInt32(this.tbxETMaxTickets.Text);
                int maxcamp = Convert.ToInt32(this.tbxETMaxCamp.Text);
                string descript = this.richTbxETDescription.Text;
                string date = this.tbxETdate.Value.ToString();
                int minage = Convert.ToInt32(this.tbxETEventMinage.Text);

                newEvent = new Event(minage, date, location, maxticket, name, maxcamp, descript);
                db.saveEvent(minage, date, location, maxticket, name, maxcamp, descript);

                this.tbxETEventName.Text = "";
                this.tbxETLocation.Text = "";
                this.tbxETMaxTickets.Text = "";
                this.tbxETMaxCamp.Text = "";
                this.richTbxETDescription.Clear();
                this.tbxETdate.Value = DateTime.Now;
                this.tbxETEventMinage.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("all fields should be filled");
            }
            if (newEvent != null)
            {
                MessageBox.Show("a new event has been created");
            }
            else
            {
                MessageBox.Show("no event has been created");
            }
        }

        private void btnETDeleteEvent_Click_1(object sender, EventArgs e)
        {
            foreach (var item in events)
            {
                if (this.listBoxEventSelect.SelectedItem == item.Name)
                {
                    if (1 == db.deleteEvent(item.Name))
                    {
                        MessageBox.Show("the event has been deleted");
                        events.Remove(item);
                    }
                }
            }
            refreshEventsList();
        }

        private void listBoxEventSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tabNewEvent.Visible = true;
            foreach (var item in events)
            {
                if (this.listBoxEventSelect.SelectedItem.ToString() == item.Name.ToString())
                {
                    this.tbxETEventName.Text = item.Name;
                    this.tbxETLocation.Text = item.Location;
                    this.tbxETMaxTickets.Text = item.Maxtickets.ToString();
                    this.tbxETMaxCamp.Text = item.Maxcamping.ToString();
                    this.richTbxETDescription.AppendText(item.Description);
                    DateTime myDate = DateTime.ParseExact(item.Date.ToString(), "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
                    this.tbxETdate.Value = myDate;
                    this.tbxETEventMinage.Text = item.Minage.ToString();
                }
            }
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


        #endregion

        #region DBView

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

        #endregion

        #region Article


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

            List<Article> NameOfarticle = new List<Article>();

            Article selectedSort = new Article("stub");

            foreach (Article a in SortArticles)
            {
                NameOfarticle.AddRange(db.NameArticle(a.ArticleID));

                if ((String)(cbxSortArticle.SelectedItem) == a.SoortArticle)
                {
                    selectedSort = a;
                }
            }

            this.cbxNameArticles.Items.Clear();
            foreach (var item in NameOfarticle)
            {
                if (selectedSort.ArticleID == item.ArticleID)
                {
                    this.cbxNameArticles.Items.Add(item.Name);
                }
            }


            //foreach (var item in Namearticle2)
            //{
            //    if (cbxSortArticle.SelectedText == "Drink")
            //    {
            //        ArticleID = 2;

            //        this.cbxNameArticles.Items.Add(item.Name);

            //    }
            //}
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

        private void btnOvRefresh_Click(object sender, EventArgs e)
        {
            //Things to add to the listbox sold, ppl at the festival, open camp spots and stocks
            lbxOvInfo.Items.Clear();
            //Add the tickets sold and # of visitors
            lbxOvInfo.Items.Add("Tickets sold: " + db.getTicketsSold());
            lbxOvInfo.Items.Add("Poeple at the festival: " + db.getPoepleAtFestival());
            //Add the open camp spots
            lbxOvInfo.Items.Add("Open camping spots: " + db.GetNrOfEmptyCamping());

            //Adding the stocks of articles
            lbxOvInfo.Items.Add("Remaining Stocks");

            // Get all the articles name and their stocks

            ///#TODO Make an article list refresh method

            NameArticles.Clear();

            foreach (Article a in SortArticles)
            {
                NameArticles.AddRange(db.NameArticle(a.ArticleID));
            }

            foreach (Article art in NameArticles)
            {
                lbxOvInfo.Items.Add(art.Name + ": " + art.Stock);
            }
        }

        private void tbxETdate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

        #endregion