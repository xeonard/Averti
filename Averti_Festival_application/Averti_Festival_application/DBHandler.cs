using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

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

        public bool AssignRFID(String ticketNR, String rFID)
        {


            String sql = ("UPDATE person SET rfid = '"+ rFID+"', status = 'arrived'  WHERE personalID = "
                + "(SELECT personalID FROM transaction WHERE transactionID = " +
                "(SELECT transactionID FROM tickets WHERE ticketNr = " + Convert.ToInt32(ticketNR)+"))"); 
            MySqlCommand command = new MySqlCommand(sql, connection);

            try
            {
                connection.Open();

                if (command.ExecuteNonQuery() == 1)
                    return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
        public bool UnassignRFID(string rFID)
        {
            String sql = ("UPDATE person SET rfid = NULL, status = 'left' WHERE rfid = '"  + rFID + "'");
            MySqlCommand command = new MySqlCommand(sql, connection);

            try
            {
                connection.Open();

                if (command.ExecuteNonQuery() == 1)
                    return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return false;


        }
        public string GetName(string rFID)
        {

            String sql = ("SELECT name FROM person WHERE rfid = '" + rFID + "'");
            MySqlCommand command = new MySqlCommand(sql, connection);

            try
            {
                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return Convert.ToString(reader[0]);
                }
                else
                {
                    return string.Empty;
                }
            }
            catch
            {
                return string.Empty;
            }
            finally
            {
                connection.Close();
            }
            
        }
        public List<string> GetEvents()
        {
            String sql = "SELECT * FROM event";
            MySqlCommand command = new MySqlCommand(sql, connection);
            List<String> list = new List<string>();

            try
            {
                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(reader["eventID"].ToString());
                    list.Add(reader["eventName"].ToString());
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }

            return list;
        }

        //gets a list of 
        public List<string>[] InfoArticle()
        {
            String sql = ("SELECT * FROM atricle");
            MySqlCommand command = new MySqlCommand(sql, connection);


            List<string>[] list = new List<string>[5];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            list[4] = new List<string>();


            connection.Open();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                list[0].Add(reader["ArticleID"] + "");
                list[1].Add(reader["SortArticle"] + "");
                list[2].Add(reader["Name"] + "");
                list[3].Add(reader["Stock"] + "");
                list[4].Add(reader["Price"] + "");


            }
            reader.Close();

            //close Connection
            connection.Close();

            //return list to be displayed
            return list;

        }
        public void Insert(int personalID)
        {
            string query = "INSERT INTO tableinfo ";

            //open connection
            connection.Open();
            //create command and assign the query and connection from the constructor
            MySqlCommand cmd = new MySqlCommand(query, connection);

            //Execute command
            cmd.ExecuteNonQuery();

            //close connection
            connection.Close();
        }

        public DataTable GetDatatable(string table, string where)
        {
            String sql = "SELECT * FROM "+ table + " " + where;
            MySqlDataAdapter a = new MySqlDataAdapter(sql, connection);

            try
            {
                connection.Open();
                DataTable t = new DataTable();
                a.Fill(t);
                return t;
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        public List<string> GetInfoTable(string table, string key)
        {
            String sql = "SELECT * FROM " + table;
            MySqlCommand command = new MySqlCommand(sql, connection);
            List<String> list = new List<string>();

            try
            {
                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(reader[key].ToString());
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }

            return list;
        }

        public double WalletBalance(string rFID)
        {
            string sql = ("SELECT walletBalance FROM person WHERE rfid = '" + rFID + "'");
            MySqlCommand command = new MySqlCommand(sql, connection);
            try
            {
                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return Convert.ToInt32(reader[0]);
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

        
    }
}
