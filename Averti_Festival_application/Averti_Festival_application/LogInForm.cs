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

            tbPass.UseSystemPasswordChar = true;

            db = new DBHandler();
            try
            {
                RfidLogin = new RFID();
                RfidLogin.open();
                RfidLogin.waitForAttachment(1500);
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
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (db.GetPersonDescription(Convert.ToInt32(tbPersID.Text)) == "visitor")
            {
                MessageBox.Show("Visitors have no access!");
            }
            else
            {

                if (db.PasswordLogin(Convert.ToInt32(tbPersID.Text), tbPass.Text) != -1)
                {
                    try
                    {
                        Thread thread = new Thread(new ParameterizedThreadStart(FestivalThread));
                        thread.Start(db.GetPersonDescription(Convert.ToInt32(tbPersID.Text)));
                        this.Close();

                    }
                    catch (Exception) { MessageBox.Show("Error with Login"); }

                }
                else
                {
                    MessageBox.Show("Login incorrect");
                }

            }
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit(); //was this really necessary?

        }
        //thread with parameter
        public void FestivalThread(object description)
        {
            Application.Run(new FestivalAppForm((String)description));
        }
        //normal thread
        public static void FestivalThread()
        {
            Application.Run(new FestivalAppForm());
        }

        private void btnNormalLog_Click(object sender, EventArgs e)
        {
            if (db.GetPersonDescription(Convert.ToInt32(tbPersID.Text)) == "visitor")
            {
                MessageBox.Show("Visitors have no access");

            }
            else
            {


                if (db.PasswordLogin(Convert.ToInt32(tbPersID.Text), tbPass.Text) != -1)
                {
                    try
                    {
                        Thread thread = new Thread(new ParameterizedThreadStart(FestivalThread));
                        thread.Start(db.GetPersonDescription(Convert.ToInt32(tbPersID.Text)));
                        this.Close();

                    }
                    catch (Exception) { MessageBox.Show("Error with Login"); }

                }
                else
                {
                    MessageBox.Show("Login incorrect");
                }

            }



        }

        private void LogInForm_Load(object sender, EventArgs e)
        {

        }

        private void LogInForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //check if there is no rfid attached
            if (RfidLogin.Attached)
            {
                RfidLogin.Antenna = false;
                RfidLogin.LED = false;
                RfidLogin.close();
            }
        }

    }
}
