﻿using System;
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
                                    "password= fCPIXLUNGi;" +
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


            String sql = ("UPDATE person SET rfid = '"+ rFID+"' WHERE personalID = "
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
        public List<string>[] GetEvents(){
            String sql = "SELECT * FROM Event";
            MySqlCommand command = new MySqlCommand(sql, connection);
            List<String>[] eventid = new List<string>[8];

            try
            {
                connection.Open();
                int i = 0;
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    eventid[i].Add(reader["minimumage"].ToString());
                    eventid[i].Add(reader["eventid"].ToString());
                    eventid[i].Add(reader["date"].ToString());
                    eventid[i].Add(reader["location"].ToString());
                    eventid[i].Add(reader["nrOfParticipants"].ToString());
                    eventid[i].Add(reader["eventname"].ToString());
                    eventid[i].Add(reader["maxcamping"].ToString());
                    eventid[i].Add(reader["description"].ToString());
                    i++;
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

            return eventid;
        }

        public bool saveEvent(int minage, string date, string location, int nrofpeople, string name, int maxcamping, string des)
        {
             String sql = ("INSERT INTO EVENT (minimumAge, date, location, nrOfParticipants, eventName, maxCamping, description) VALUES (" + minage.ToString() + date.ToString() + location.ToString() + nrofpeople.ToString() + name.ToString() + maxcamping.ToString() + des.ToString() + ");"   );
                       MySqlCommand command = new MySqlCommand(sql, connection);

            try
            {
                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

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
        } 
        


        public int deleteEvent(int Eventid)
        {
                       String sql = ("DELETE FROM EVENT WHERE eventID = "  + Eventid);
                       MySqlCommand command = new MySqlCommand(sql, connection);
            try
            {
                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return Convert.ToInt32(reader["Eventid"]);
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
        

        public List<Article> GetArticles()
        {
            String sql = "SELECT * FROM article";
            MySqlCommand command = new MySqlCommand(sql, connection);

            List<Article> temp;
            temp = new List<Article>();

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                int id;
                string sort;
                string name;
                int stock;

                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["ArticleID"]);
                    sort = Convert.ToString(reader["SoortArticle"]);
                    stock = Convert.ToInt32(reader["Stock"]);
                    name = Convert.ToString(reader["Name"]);

                    temp.Add(new Article(id, sort, name, stock));
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
            return temp;
        }
    }
}
