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
        Event newEvent;
        DBHandler db = new DBHandler();
        List<Event> events;
        public FestivalAppForm()
        {
           events = new List<Event>();
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
    }
}
