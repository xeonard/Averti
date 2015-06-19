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
                RfidLogin.waitForAttachment(1000);
                RfidLogin.Antenna = true;
                RfidLogin.LED = true;
                RfidLogin.Tag += new TagEventHandler(ProcessThisTag);
                lblInfo.Text = ("RFID is connected");
            }
            catch (PhidgetException)
            {
                lblInfo.Text = ("No RFID connection");
            }
        }

        private void closeMe(LogInForm me)
        {
            this.Close();
        }

        private void ProcessThisTag(object sender, TagEventArgs e)
        {
            System.Console.Out.WriteLine(e.Tag);
            int id = db.personalID(e.Tag);
            if (id != -1)
            {
                lblInfo.Text = this.Login(id, false);
            }
            else
            {
                lblInfo.Text = "No such RFID found";
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void FestivalThread(object description)
        {
            Application.Run(new FestivalAppForm((String)description, this.RfidLogin));
        }

        private void btnNormalLog_Click(object sender, EventArgs e)
        {
            this.lblInfo.Text = this.Login( Convert.ToInt32(tbPersID.Text) , true);
        }

        private String Login(int id, bool checkPass)
        {
            if (db.GetPersonDescription(id) == "visitor")
            {
                return ("Visitors have no access");
            }
            else
            {
                if ((db.PasswordLogin(id, tbPass.Text) != -1) || !checkPass)
                {
                    try
                    {
                        Thread thread = new Thread(new ParameterizedThreadStart(FestivalThread));
                        thread.Start((db.GetPersonDescription(id)).ToLower());

                        this.Close();
                        return "Logged in";
                    }
                    catch (Exception) { return ("Error with Login"); }
                }
                else
                {
                    return ("Login incorrect");
                }
            }
        }

        private void tbPass_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.lblInfo.Text = this.Login(Convert.ToInt32(tbPersID.Text), true);
            }
        }

        private void tbPersID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.lblInfo.Text = this.Login(Convert.ToInt32(tbPersID.Text), true);
            }
        }


    }
}
