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
        private RFID RfidCheckin;

        DBHandler db = new DBHandler();

        public FestivalAppForm()
        {
            InitializeComponent();

            TabControl.TabPages.Remove(tabSales);
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
    }
}
