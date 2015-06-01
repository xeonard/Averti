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
                connection.Close();
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
            catch(Exception e)
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
        public int ArticleID()
        {
            String sql = ("SELECT articleID FROM article");
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
        public int KindOfArticleID()
        {
            int KindOfArticleID;
            string quaryKindOfArticleID = "SELECT COUNT(KinOfArticleID) FROM kindofarticle ";
            try
            {

                connection.Open();

                MySqlCommand command = new MySqlCommand(quaryKindOfArticleID, connection);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    KindOfArticleID = Convert.ToInt32(reader[0]);
                    return KindOfArticleID + 1;

                }
                else
                {
                    return 0;
                }
            }

            catch
            {
                return 0;
            }

            finally
            {
                connection.Close();
            }
        }
        public List<Article> NameArticle ( int ArticleID)
        {
            String sql = ("SELECT * FROM kindofarticle where ArticleID = " + ArticleID);
            MySqlCommand command = new MySqlCommand(sql, connection);


            List<Article> list = new List<Article>();


            connection.Open();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                list.Add(new Article(Convert.ToInt32(reader["KinOfArticleID"]), Convert.ToInt32(reader["ArticleID"]), reader["Name"].ToString(), Convert.ToInt32(reader["Stock"]), Convert.ToDouble(reader["price"])));


            }
            reader.Close();

            //close Connection
            connection.Close();

            //return list to be displayed
            return list;

        }
        //gets a list of 
        public List<Article> InfoArticle( int ArticleID )
        {
            String sql = ("SELECT * FROM article where ArticleID = " + ArticleID);
            MySqlCommand command = new MySqlCommand(sql, connection);


            List<Article> list = new List<Article>();


            connection.Open();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                list.Add(new Article(Convert.ToInt32(reader["articleID"]), reader["soortArticle"].ToString()));


            }
            reader.Close();

            //close Connection
            connection.Close();

            //return list to be displayed
            return list;

        }
        public List<Article> SortArticle()
        {
            String sql = ("SELECT * FROM article");
            MySqlCommand command = new MySqlCommand(sql, connection);


            List<Article> list = new List<Article>();


            connection.Open();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                list.Add(new Article(Convert.ToInt32(reader["articleID"]), reader["sortArticle"].ToString()));


            }
            reader.Close();

            //close Connection
            connection.Close();

            //return list to be displayed
            return list;

        }
        public int personalID (string rFID)
        {
            int personalID;
            string quaryPersonalID = "SELECT personalID FROM person where rfid = '" + rFID + "' ";
            MySqlCommand command = new MySqlCommand(quaryPersonalID, connection);
           try
           {

               connection.Open();
               

               MySqlDataReader reader = command.ExecuteReader();

               if (reader.Read())
               {
                   personalID = Convert.ToInt32(reader[0]);
                   return personalID;

               }
               else
               {
                   return 0;
               }
           }

           catch
           {
               return 0;
           }
           finally
           {
               connection.Close();
           }
  
        }

        public int TransactionID()
        {
            int transactionID;
            string queryTransactionID = "SELECT COUNT(transactionID) FROM transaction ";
            try
            {

                connection.Open();

                MySqlCommand command = new MySqlCommand(queryTransactionID, connection);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    transactionID = Convert.ToInt32(reader[0]);
                    return transactionID + 1;

                }
                else
                {
                    return 0;
                }
            }

            catch
            {
                return 0;
            }

            finally
            {
                connection.Close();
            }
        }
        public int SumOrders(int personalID)
        {
            int SumOrders;
            string querySumOrders = "SELECT SUM(cost) FROM transaction where personalID = '" + personalID + "' ";
            try
            {

                connection.Open();

                MySqlCommand command = new MySqlCommand(querySumOrders, connection);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    SumOrders = Convert.ToInt32(reader[0]);
                    return SumOrders;

                }
                else
                {
                    return 0;
                }
            }

            catch
            {
                return 0;
            }

            finally
            {
                connection.Close();
            }
        }
        public bool InsertToTransactionarticle(int transactionID, int articleID, int quantity)
        {
             string quaryInsert = "INSERT INTO transactionarticle(transactionID, articleID, quantity) VALUES('" + transactionID + "','" + articleID + "','" + quantity + "')";
            try
            {
            //open connection
            connection.Open();
            MySqlCommand command = new MySqlCommand(quaryInsert, connection);
            //Execute command
            command.ExecuteNonQuery();
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
            //close connection
            
        }

        public bool InsertToTransaction(int transactionID, int personalID, string description, double cost, DateTime dataTime )
        {
         
            string quaryInsert = "INSERT INTO transaction(transactionID, personalID, description, cost, dateTime) VALUES('" + transactionID + "', " + personalID + ",'" + description + "','" + cost + "', '" + dataTime.ToString() +"')";
            try
            {
                //open connection
                connection.Open();
                MySqlCommand command = new MySqlCommand(quaryInsert, connection);
                //Execute command
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally { 
            //close connection
            connection.Close();
            }
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
                list = null;
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



        public int GetNrOfEmptyCamping()
        {
            String sql = "SELECT COUNT(*) FROM camp WHERE reserved = 'Free'";

            MySqlCommand command = new MySqlCommand(sql, connection);

            try
            {
                connection.Open();

                return Convert.ToInt32(command.ExecuteScalar());
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

        public int getPoepleAtFestival()
        {
            String sql = "SELECT COUNT(*) FROM person WHERE status = 'arrived'";

            MySqlCommand command = new MySqlCommand(sql, connection);

            try
            {
                connection.Open();

                return Convert.ToInt32(command.ExecuteScalar());
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
        /// Method for getting the total amount of tickets sold
        /// </summary>
        /// <returns>
        /// int tickets
        /// </returns>
        public int getTicketsSold()
        {
            String sql = "SELECT COUNT(*) FROM Tickets";

            MySqlCommand command = new MySqlCommand(sql, connection);

            try
            {
                connection.Open();

                return Convert.ToInt32(command.ExecuteScalar());

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
