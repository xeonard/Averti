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
        Order currentOrder;
        List<Article> articles = new List<Article>();
        List<Article> NameArticles = new List<Article>();
        private RFID RfidCheckin;
        Event newEvent;
        DBHandler db = new DBHandler();
        List<Article> SortArticles;
        List<Event> events = new List<Event>();


        public FestivalAppForm()
        {
            InitializeComponent();
            refreshEventsList();
            this.RfidCheckin = new RFID();
        }

        public FestivalAppForm(String description, RFID rfid)
            : this() // call the normal constructor for this class
        {
            this.StopRFID(rfid);
            // check id to see which tabs to remove
            switch (description)
            {
                case "sales":
                    this.TabControl.TabPages.Remove(tabEvent);
                    this.TabControl.TabPages.Remove(tabDBView);
                    this.TabControl.TabPages.Remove(tabCheckIn);
                    this.TabControl.TabPages.Remove(tabAccounts);
                    currentOrder = new Order();
                    this.StartRFID(this.RfidCheckin);
                    this.RfidCheckin.Tag += new TagEventHandler(this.ShowPersonWallet);
                    // Sales
                    // Fill Sort dropbox
                    try
                    {
                        this.SortArticles = this.db.SortArticle();

                        foreach (var item in this.db.SortArticle())
                        {
                            this.cbxSortArticle.Items.Add(item.SoortArticle);
                        }
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("There is no Articles in database");
                    }
                    break;

                case "admin":
                    new PaypalParser();
                    // #TODO uncomment
                    TabControl.TabPages.Remove(tabSales);
                    TabControl.TabPages.Remove(tabCheckIn);

                    // Fill the accounts list
                    this.refreshAccountListBox();

                    // dbView filling dropboxes
                    // Event dropbox
                    try
                    {
                        foreach (string a in db.GetInfoTable("event", "eventID"))
                        {
                            this.cbxDTSelectEvent.Items.Add(a);
                        }
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("There is no campings in database");
                    }
                    // Camp dropbox
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
                    // Article dropbox
                    try
                    {
                        foreach (string a in db.GetInfoTable("kindofarticle", "Name"))
                        {
                            this.cbxDTSelectArticle.Items.Add(a);
                        }
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("There is no Articles in database");
                    }
                    break;

                case "entrance":
                    this.TabControl.TabPages.Remove(tabEvent);
                    this.TabControl.TabPages.Remove(tabDBView);
                    this.TabControl.TabPages.Remove(tabSales);
                    this.TabControl.TabPages.Remove(tabOv);
                    this.TabControl.TabPages.Remove(tabAccounts);
                    break;

                default: // on default just leave the overview tab
                    this.TabControl.TabPages.Remove(tabSales);
                    this.TabControl.TabPages.Remove(tabEvent);
                    this.TabControl.TabPages.Remove(tabDBView);
                    this.TabControl.TabPages.Remove(tabCheckIn);
                    this.TabControl.TabPages.Remove(tabAccounts);
                    break;
            }
        }

        private void FestivalAppForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.StopRFID(this.RfidCheckin);
            Thread thread = new Thread(new ThreadStart(LogInThread));
            thread.Start();
        }

        #region Login / CheckIn




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
                    StartRFID(this.RfidCheckin);
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
                    StartRFID(this.RfidCheckin);
                    RfidCheckin.Tag -= new TagEventHandler(RemoveThisTag);
                    RfidCheckin.Tag += new TagEventHandler(ProcessThisTag);


                    break;
            }
        }

        private static void LogInThread()
        {
            Application.Run(new LogInForm());
        }
        private void StartRFID(RFID rfid)
        {
            try
            {
                this.StopRFID(rfid);
                rfid.open();
                rfid.waitForAttachment(1500);
                rfid.Antenna = true;
                rfid.LED = true;

            }
            catch (PhidgetException)
            {
                MessageBox.Show("No RFID connection");
            }
        }
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            StartRFID(this.RfidCheckin);
            lbUnassigned.Visible = false;
            tabCheckIn.BackColor = this.BackColor;

            RfidCheckin.Tag -= new TagEventHandler(ProcessThisTag);
            RfidCheckin.Tag += new TagEventHandler(RemoveThisTag);


        }
        private void StopRFID(RFID rfid)
        {

            if (rfid.Attached)
            {
                rfid.Antenna = false;
                rfid.LED = false;
                rfid.close();
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
            string s = e.Tag;
            tbxRFID.Text = e.Tag;

            double balance = db.WalletBalance(s);
            int personalID = db.personalID(s);
            int sumPriceOfOrders = db.SumOrders(personalID);
            double newBalance = balance - sumPriceOfOrders;
            currentOrder.PersonID = personalID;
            if (newBalance > 2.5)
            {
                this.lbWallet.Text = newBalance.ToString();
            }

            if (newBalance < 2.5)
            {
                this.lbWallet.Text = Convert.ToString(db.WalletBalance(s));
                btnSTAddToOrder.Enabled = false;
                btnSTCompleteOrder.Enabled = false;
                MessageBox.Show(" You don't have enough credit to buy an article. You can charge your credit via our website");
                tbxRFID.Text = "";
                lbWallet.Text = "";
                btnSTCompleteOrder.Enabled = true;
                btnSTAddToOrder.Enabled = true;
            }
        }

        private void btnSTAddToOrder_Click(object sender, EventArgs e)
        {

            int KindOfArticleID = db.KindOfArticleID();
            lbOrder.Items.Clear();

            int ArticleID = db.ArticleID();

            if (cbxSortArticle.SelectedItem != null && cbxNameArticles.SelectedItem != null && NUDSTArticleAmount.Value > 0)
            {
                // check which article it is
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
                            currentOrder.AddToOrder(item, Convert.ToInt32(NUDSTArticleAmount.Value));
                        }
                }

                this.UpdateLbOrder();

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
                currentOrder.Articles.RemoveAt(Convert.ToInt32(item));
                currentOrder.updateCost();

                this.UpdateLbOrder();

                btnSTCompleteOrder.Enabled = true;
            }
        }

        private void UpdateLbOrder()
        {
            lbOrder.Items.Clear();
            lbOrder.Items.Add("Your selected articles: ");
            int counter = 0;
            foreach (var orderitem in currentOrder.Articles)
            {
                counter++;
                lbOrder.Items.Add("");
                lbOrder.Items.Add(counter.ToString() + ":   " + orderitem.SoortArticle
                    + "( " + orderitem.Name + " ) " + "Stock:  " + Convert.ToString(orderitem.Stock)
                    + "   Price:  €" + Convert.ToString(orderitem.Price * orderitem.Stock));
                lbOrder.Items.Add("");
                lbOrder.Items.Add("\n");
            }

            lbOrder.Items.Add("***********************");
            lbOrder.Items.Add("Totale Price:   € " + Convert.ToString(currentOrder.Cost));
            lbOrder.Items.Add("\n");
            if (currentOrder.Cost > Convert.ToInt32(lbWallet.Text))
            {
                btnSTCompleteOrder.Enabled = false;
                MessageBox.Show("your credit is not enough to buy your orders");
            }
            double newWalletCredit = Convert.ToInt32(lbWallet.Text) - currentOrder.Cost;
            lblSTNewWalletCredit.Text = "Your new balance is: " + Convert.ToString(newWalletCredit);
        }

        private void btnSTCompleteOrder_Click(object sender, EventArgs e)
        {
            int articleID = db.ArticleID();
            int transactionID = db.TransactionID();

            List<Article> listOfSortArticle = new List<Article>();
            listOfSortArticle = db.InfoArticle(articleID);
            articles.Clear();

            db.InsertToTransaction(transactionID, currentOrder.PersonID, "article", currentOrder.Cost, DateTime.Now);


            foreach(var article in currentOrder.Articles)
            {
                db.InsertToTransactionarticle(transactionID, article.KindOfArticleID, article.ArticleID, article.Stock);
                db.LowerArticleStock(article.KindOfArticleID, article.Stock);
            }

            if (!db.UpdateWallet(currentOrder.PersonID, currentOrder.Cost))
            {
                MessageBox.Show("Error with updating wallet, order not complete!");
            }
            

            tbxRFID.Text = "";
            lbOrder.Items.Clear();
            lblSTNewWalletCredit.Text = "";
            lbWallet.Text = "";
            currentOrder = new Order();
        }

        private void btnSTCancel_Click(object sender, EventArgs e)
        {
            tbxRFID.Clear();
            cbxNameArticles.Text = "";
            cbxSortArticle.Text = "";
            lbOrder.Items.Clear();
            currentOrder = new Order();
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
            this.listBoxEventSelect.Items.Clear();
            foreach (var item in events)
            {
                this.listBoxEventSelect.Items.Add(item.Name);
            }
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
            this.tbxETEventName.Text = "";
            this.tbxETLocation.Text = "";
            this.tbxETMaxTickets.Text = "";
            this.tbxETMaxCamp.Text = "";
            this.richTbxETDescription.Clear();
            this.tbxETdate.Value = DateTime.Now;
            this.tbxETEventMinage.Text = "";
            this.richTbxETDescription.Text = "";

            if (this.tabNewEvent.Visible == true)
            {
                this.btnETNewEvent.Text = "Hide New Event";
            }
            else
            {
                this.btnETNewEvent.Text = "New Event";
            }
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
                string date = this.tbxETdate.Value.ToString("yyyy-MM-dd");
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
                this.richTbxETDescription.Text = "";
                this.refreshEventsList();

            }
            catch (Exception)
            {
                MessageBox.Show("all fields should be filled");
                newEvent = null;
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
                if (this.listBoxEventSelect.SelectedItem.ToString() == item.Name)
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
                    this.richTbxETDescription.Text = item.Description;
                    DateTime myDate = new DateTime();
                    myDate = DateTime.ParseExact(item.Date, "yyyy-MM-dd", null);
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
                            string where = "Where Name = '" + cbxDTSelectArticle.SelectedItem.ToString() + "' ";
                            dataGridView1.DataSource = db.GetDatatable("kindofarticle", where);
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

        #endregion

        #region Overview tab

        private void btnOvRefresh_Click(object sender, EventArgs e)
        {
            //Things to add to the listbox sold, ppl at the festival, open camp spots and stocks
            lbxOvInfo.Items.Clear();
            //Add the tickets sold and # of visitors
            lbxOvInfo.Items.Add("Tickets sold: " + db.getTicketsSold());
            lbxOvInfo.Items.Add("People at the festival: " + db.getPoepleAtFestival());
            lbxOvInfo.Items.Add("People that left the festival: " + db.getPeopleLeftFestival());
            //Add the open camp spots
            lbxOvInfo.Items.Add("Open camping spots: " + db.GetNrOfEmptyCamping());

            //Adding the stocks of articles
            lbxOvInfo.Items.Add("Remaining Stocks");

            // Get all the articles name and their stocks

            SortArticles = db.SortArticle();

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

        #endregion 

        #region Accounts

        private void refreshAccountListBox()
        {
            lbxAccounts.Items.Clear();

            foreach (int i in db.getNonVisitors())
            {
                lbxAccounts.Items.Add(i);
            }
        }

        private void accountsClearInfo()
        {
            lblAccPID.Text = "";
            tbxAccName.Text = "";
            tbxAccEmail.Text = "";
            tbxAccPass.Text = "";
        }

        private void btnNewAccount_Click(object sender, EventArgs e)
        {
            String descr;

            switch (cbxAccDesc.SelectedIndex)
            {
                case 0:
                    descr = "sales";
                    break;
                case 1:
                    descr = "entrance";
                    break;
                case 2:
                    descr = "admin";
                    break;
                default:
                    MessageBox.Show("Invalid department chosen");
                    return;
            }

            String name = tbxAccName.Text;
            String email = tbxAccEmail.Text;
            String pass = tbxAccPass.Text;

            if (!this.db.insertNewAccount(descr, name, email, pass))
            {
                MessageBox.Show("Failed creating new account");
            }

            this.refreshAccountListBox();
        }

        private void btnAccSave_Click(object sender, EventArgs e)
        {
            int pid = -1;
            try
            {
                pid = Convert.ToInt32(lblAccPID.Text);
            }
            catch
            {

            }

            String descr;

            switch (cbxAccDesc.SelectedIndex)
            {
                case 0:
                    descr = "sales";
                    break;
                case 1:
                    descr = "entrance";
                    break;
                case 2:
                    descr = "admin";
                    break;
                default:
                    MessageBox.Show("Invalid department chosen");
                    return;
            }

            String name = tbxAccName.Text;
            String email = tbxAccEmail.Text;
            String pass = tbxAccPass.Text;

            if (!this.db.updateAccount(pid, descr, name, email, pass))
            {
                MessageBox.Show("Failed updating account");
            }

            this.refreshAccountListBox();
        }

        private void btnAccCancel_Click(object sender, EventArgs e)
        {
            this.accountsClearInfo();
        }
        
        private void lbxAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pid = Convert.ToInt32(this.lbxAccounts.SelectedItem);

            lblAccPID.Text = pid.ToString();

            List<String> info = db.getAccountData(pid);
            try
            {
                String descr = info[0];
                String name = info[1];
                String email = info[2];
                String pass = info[3];

                switch (descr)
                {
                    case "sales":
                        cbxAccDesc.SelectedIndex = 0;
                        break;
                    case "entrance":
                        cbxAccDesc.SelectedIndex = 1;
                        break;
                    case "admin":
                        cbxAccDesc.SelectedIndex = 2;
                        break;
                }

                tbxAccName.Text = name;
                tbxAccEmail.Text = email;
                tbxAccPass.Text = pass;
            }
            catch
            {
                MessageBox.Show("Something went wrong loading from the database");
            }


        }

        #endregion

    }
}
