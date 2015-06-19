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
                t = new Timer(15 * 60 * 1000); // execute the code every 15 minutes

                t.Elapsed += new ElapsedEventHandler(timerAction);
                t.Start();
            }
        }

        public void timerAction(object sender, ElapsedEventArgs eea)
        {
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                fs = new FileStream("‪../../../../PayPalLog/PayPal_Log.txt", FileMode.Open, FileAccess.Read);
                //#NOTE need a more standarized path location!!
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
                        for (int x = 0; x < depAmount; x++)
                        {
                            payment = sr.ReadLine();
                            ppidAndAmount = payment.Split(); // [0] is ppid and [1] is amount
                            // update the db
                            db.UpdateWallet(ppidAndAmount[0], ppidAndAmount[1]);
                            System.Console.Out.WriteLine("db updated");
                        }
                    }
                    else { System.Console.Out.WriteLine("File already checked!"); }
                }
            }
            catch(IndexOutOfRangeException)
            {
                //Something went wrong reading the sender's ppid or amount #test
                System.Console.Out.WriteLine("Something went wrong reading ppid or amount");
            }
            catch(Exception ex)
            {
                //Is there a better way to alert the user?
                System.Console.Out.WriteLine("Something went wrong somewhere\n" + ex.Message);
            }
            finally
            {
                //Check if the streamreader has been initiated and close it.
                if(sr != null)
                    sr.Close();
            }
        }

        //~PaypalParser()
        //{
        //    System.Console.Out.WriteLine("Exited paypal parser....");
        //}
    }
}
