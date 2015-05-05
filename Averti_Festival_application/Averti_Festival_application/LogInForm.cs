using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidgets;
using Phidgets.Events;
using System.Threading;

namespace AvertiFestivalApplication
{
    public partial class LogInForm : Form
    {
        private RFID RfidLogin;
        private DBHandler db;
        public LogInForm()
        {
            InitializeComponent();

            db = new DBHandler();
            try
            {
                RfidLogin = new RFID();
                RfidLogin.open();
                RfidLogin.waitForAttachment(3000);
                RfidLogin.Antenna = true;
                RfidLogin.LED = true;
                RfidLogin.Tag += new TagEventHandler(ProcessThisTag);

            }
            catch (PhidgetException)
            {
                MessageBox.Show("No RFID connection");
            }

                 
        }

        private void ProcessThisTag(object sender, TagEventArgs e)
        {
            this.tbxLoginID.Text = e.Tag;
            if (this.tbxLoginID.Text != string.Empty)
            {
                btnLogin.Enabled = true; 
            };
        }
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
             Thread thread = new Thread(new ThreadStart(FestivalThread));
             thread.Start();
             RfidLogin.Antenna = false;
             RfidLogin.LED = false;
             RfidLogin.close();
             this.Close();
             
            }
            catch(Exception) { MessageBox.Show("Error with Login"); }
            
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public static void FestivalThread()
        {
            Application.Run(new FestivalAppForm());
        }
    }
}
