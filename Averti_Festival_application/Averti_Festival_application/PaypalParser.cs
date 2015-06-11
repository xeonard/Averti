using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;

namespace AvertiFestivalApplication
{
    /// <summary>
    /// This class continouosly check the paypal log file for updates. 
    /// The file should be located under C:/Festival/PayPalLog.txt
    /// </summary>
    class PaypalParser
    {
        private Timer t;
        private DBHandler db;
        private String organizationPayPal;
        private DateTime startDate;
        private DateTime endDate;

        public PaypalParser()
        {
            db = new DBHandler();
            startDate = default(DateTime);
            endDate = default(DateTime);
            organizationPayPal = db.getOrganizationPPid(); 
            if (organizationPayPal != null)
            {
                //t = new Timer(15 * 60 * 1000); // execute the code every 15 minutes
                t = new Timer(30 * 1000); // for testing, a 30 sec execution
                t.Elapsed += new ElapsedEventHandler(timerAction);
                t.Start();
            }
        }

        public void timerAction(object sender, ElapsedEventArgs e)
        {
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                fs = new FileStream("C:Festival/PayPal_Log.txt", FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);
                String payment; //for storing each payment read
                String[] ppidAndAmount = new String[2]; // for storing the paypalid and amount
                
                //read the ppid of the one who's received the transactions
                String receiversPPID = sr.ReadLine();
                //read start date of transactions
                DateTime currentStartDate = DateTime.ParseExact(sr.ReadLine(), "yyyy/MM/dd/HH:mm:ss", null);
                //read end date of transactions
                DateTime currentEndDate = DateTime.ParseExact(sr.ReadLine(), "yyyy/MM/dd/HH:mm:ss", null);
                //read the amount of deposits
                int depAmount = Convert.ToInt32(sr.ReadLine());

                //check the PayPalID if it's correct
                if (receiversPPID == organizationPayPal)
                {
                    //check if the start and end of transactions aren't the same as the last ones set
                    if (currentStartDate != startDate && currentEndDate != endDate)
                    {
                        //set the new start and end dates
                        startDate = currentStartDate;
                        endDate = currentEndDate;

                        //read depositor ppid and amount deposited, send to db
                        for(int x = 0; x < depAmount; x++)
                        {
                            payment = sr.ReadLine();
                            ppidAndAmount = payment.Split(); // [0] is ppid and [1] is amount
                            // update the db
                            db.UpdateWallet(ppidAndAmount[0], ppidAndAmount[1]); 
                        }
                    }
                }
            }
            catch(IndexOutOfRangeException)
            {
                //Something went wrong reading the sender's ppid or amount #test
                System.Console.Out.WriteLine("Something went wrong reading ppid or amount");
            }
            catch
            {
                //Think a better way to alert that something went wrong #test
                System.Console.Out.WriteLine("Something went wrong somewhere");
            }
            finally
            {
                sr.Close();
            }
        }
            
    }
}
