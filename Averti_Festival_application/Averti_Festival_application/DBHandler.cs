using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace AvertiFestivalApplication
{
    class DBHandler
    {
        private MySqlConnection connection;

        public DBHandler()
        {
            String connectInfo =    "server=athena01.fhict.local;" +
                                    "database=dbi252284;" +
                                    "user id=dbi252284;" +
                                    "password=fCPIXLUNGi;" +
                                    "connect timeout=30;";

            connection = new MySqlConnection(connectInfo);
        }

        public String GetAllNames()
        {
            //another test method
            String sql = "SELECT * FROM Person";
            MySqlCommand command = new MySqlCommand(sql, connection);
            String names = String.Empty;

            try
            {
                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    names += reader["Name"] + "\n";
                }
            }
            catch
            {
                return("Error with DB");
            }
            finally
            {
                connection.Close();
            }

            return names;
        }

        /// <summary>
        /// To check the state of the ticket
        /// -1 if the ticket isn't found in the db.
        /// 1 if the ticket is found and the person isn't inside
        /// 2 if the ticket is found and the person is already in
        /// 3 if the ticket is found and the person left the event
        /// </summary>
        /// <returns></returns>
        public int CheckTicket(String ticket)
        {
            String sql = ("SELECT status FROM person WHERE personalID = " + 
                "(SELECT personalID FROM transaction WHERE transactionID = " +
                "(SELECT transactionID FROM tickets WHERE ticketNr = " + Convert.ToInt32(ticket)+"))");
            MySqlCommand command = new MySqlCommand(sql, connection); 
            
            String temp = String.Empty;

            try
            {
                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    // check status
                    temp = Convert.ToString(reader["status"]);
                    if (temp == "arrived")
                    {
                        return 2;
                    }
                    else if (temp == "not arrived")
                    {
                        return 1;
                    }
                    else 
                    {
                        return 3;
                    }
                }
                else
                {
                    return -1;
                }
            }
            catch
            {
                return(-1);
            }
            finally
            {
                connection.Close();
            }
        }
        
        /// <summary>
        /// Gets a persons personalId from a rfid tag
        /// </summary>
        /// <param name="rFID"></param>
        /// <returns></returns>
        public int CheckRFID(string rFID)
        {
            String sql = ("SELECT * FROM person WHERE rfid = '" + rFID + "'");
            MySqlCommand command = new MySqlCommand(sql, connection); 
            
             try
            {
                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    return Convert.ToInt32(reader["personalID"]);
                }
                else
                {
                    return -1;
                }
            }
            catch
            {
                return -1;
            }
            finally
            {
                connection.Close();
            }
          
        }

        /// <summary>
        /// Checks the db for a matching personalId and password
        /// </summary>
        /// <param name="personalID"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int PasswordLogin(int personalID, string password)
        {
            
            String sql = ("SELECT * FROM person WHERE personalID = " + personalID 
                + " AND password = '" + password + "'"); // password = 8 chars
            MySqlCommand command = new MySqlCommand(sql, connection);

            try
            {
                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return Convert.ToInt32(reader["personalID"]);
                }
                else
                {
                    return -1;
                }
            }
            catch
            {
                return -1;
            }
            finally
            {
                connection.Close();
            }
        }

        public void AssignRFID(String ticketNR, String rFID)
        {

        }

    }
}
