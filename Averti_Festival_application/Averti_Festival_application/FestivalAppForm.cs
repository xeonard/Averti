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
        private RFID RfidCheckin;

        DBHandler db = new DBHandler();

        public FestivalAppForm()
        {
            InitializeComponent();

        //    TabControl.TabPages.Remove(tabSales);

            //code for sales page
            try
            {
                foreach (Article a in db.GetArticles())
                {
                    this.cbxSTArticles.Items.Add(a.Name);
                }
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("There is no Articles in database");
            }

            dataGridView1.DataSource = db.GetDatatable("event");
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
                    break;
                case 1:
                  //  lbStatus.Text = "Ticket info: visitor hasnt arrived";
                    tabCheckIn.BackColor = Color.Green;
                    StartRFID();
                    break;
                case 2:
                   // lbStatus.Text = "Ticket info: visitor has arrived";
                    tabCheckIn.BackColor = Color.Red;
                    break;
                case 3:
                  //  lbStatus.Text = "Ticket info: visitor left";
                    tabCheckIn.BackColor = Color.Green;
                    StartRFID();
                    break;
            }
        }

        private void btnCheckInSubmit_Click(object sender, EventArgs e)
        {

        }

        private void StartRFID()
        {
            try
            {
                RfidCheckin = new RFID();
                RfidCheckin.open();
                RfidCheckin.waitForAttachment(1500);
                RfidCheckin.Antenna = true;
                RfidCheckin.LED = true;
                RfidCheckin.Tag += new TagEventHandler(ProcessThisTag);
            }
            catch (PhidgetException)
            {
                MessageBox.Show("No RFID connection");
            }
        }

        private void StopRFID()
        {
            //try
            //{
                if (RfidCheckin.Attached)
                {
                    RfidCheckin.Antenna = false;
                    RfidCheckin.LED = false;
                    RfidCheckin.close();
                }
            //}
            //catch
            //{

            //}
        }

        private void ProcessThisTag(Object sender, TagEventArgs e) 
        {
            if (db.AssignRFID(this.tbxCheckInID.Text, e.Tag))
            {
                lbAssigned.Text = "RFID: Assigned to " + db.GetName(e.Tag);
                lbAssigned.Visible = true;
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
            foreach (Article a in db.GetArticles())
            {
                if (a.Name == db.GetArticles()[this.cbxSTArticles.SelectedIndex].Name && this.NUDSTArticleAmount.Value > 0)
                {
                    lbOrder.Items.Add(a.Name + " | Amount: " + this.NUDSTArticleAmount.Value + " | Amount in stock: " + a.Stock);
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

        private void label17_Click(object sender, EventArgs e)
        {
            
        }

        private void cbxDTInfoType_SelectedIndexChanged_1(object sender, EventArgs e)
        {

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
    }
}
