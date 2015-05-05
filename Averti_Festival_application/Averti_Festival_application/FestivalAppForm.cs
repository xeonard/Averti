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

namespace AvertiFestivalApplication
{
    public partial class FestivalAppForm : Form
    {

        DBHandler db = new DBHandler();

        public FestivalAppForm()
        {
            InitializeComponent();
        }

        private void FestivalAppForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            Thread thread = new Thread(new ThreadStart(LogInThread));
            thread.Start();
        }

        private static void LogInThread()
        {
            Application.Run(new LogInForm());
        }

        private void btnCheckTicket_Click(object sender, EventArgs e)
        {
            db.CheckTicket(this.tbxCheckInID.Text);
        }
    }
}
