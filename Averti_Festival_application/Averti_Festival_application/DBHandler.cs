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
            String connectInfo = "server=athena01.fhict.local;" +
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
                return ("Error with DB");
            }
            finally
            {
                connection.Close();
            }

            return names;
        }



        #region Pyapalparser
        /// <summary>
        /// Get the organization's paypal id from the database
        /// </summary>
        /// <returns>
        /// null if something goes wrong retrieving the information
        /// </returns>
        public String getOrganizationPPid()
        {
            String sql = ("SELECT paypalID FROM person WHERE description = 'admin'"); // assumes the admin has the organizations ppid
            MySqlCommand command = new MySqlCommand(sql, connection);

            try
            {
                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // check status
                    return Convert.ToString(reader[0]);
                }
                else
                {
                    return null;
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
        }

        public String getPPid(int personalId)
        {
            String sql = "SELECT paypalID FROM person WHERE personalID = " + personalId + ";";
            MySqlCommand command = new MySqlCommand(sql, connection);

            try
            {
                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return reader[0].ToString();
                }
                else
                {
                    return String.Empty;
                }
            }
            catch
            {
                return String.Empty;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// A method
        /// </summary>
        /// <param name="ppid"> paypal id</param>
        /// <param name="amount">amount of money deposited</param>
        /// <returns>true if succesful and false if failed or if nothing changed in the db</returns>
        public bool UpdateWallet(int personalID, double amount)
        {
            String sql = ("UPDATE `person` SET `walletBalance` = " + amount + " WHERE `person`.`personalID` = " + personalID + ";");
            MySqlCommand command = new MySqlCommand(sql, connection);
            try
            {
                connection.Open();

                int updatedRows = command.ExecuteNonQuery();

                return (updatedRows == 0);  // check if one row was updated and return it
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
        /// <summary>
        /// A method
        /// </summary>
        /// <param name="ppid"> paypal id</param>
        /// <param name="amount">amount of money deposited</param>
        /// <returns>true if succesful and false if failed or if nothing changed in the db</returns>
        public bool UpdateWallet(String ppid, String amount)
        {
            String sql = ("UPDATE `person` SET `walletBalance` = " + amount + " WHERE `person`.`paypalID` = " + ppid + ";");
            MySqlCommand command = new MySqlCommand(sql, connection);
            try
            {
                connection.Open();

                int updatedRows = command.ExecuteNonQuery();

                return (updatedRows == 0);  // check if one row was updated and return it
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
        #endregion

        #region accounts 

        private int getNextNewId(String description)
        {
            String sql = "SELECT MAX(personalID) FROM person WHERE description = '" + description + "';" ;

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

        public bool insertNewAccount(String description, String name, String email, string pass)
        {
            int id = getNextNewId(description);

            if( id == -1 )
                return false;

            String sql = "INSERT INTO `dbi252284`.`person`"
                + "(`personalID`, `name`, `Sex`, `address`, `email`, `status`, `birthday`"
                + ", `telephoneNumber`, `arrivalTime`, `departureTime`, `tiwitterAcc`"
                + ", `paypalID`, `walletBalance`, `description`, `rfid`, `username`, `password`)"
                + "VALUES ('"+ id +"', '" + name +"', NULL, NULL, '" + email + "'"
                + ", NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '" 
                + description + "', NULL, '" + name + "', '"+ pass + "');";

            MySqlCommand command = new MySqlCommand(sql, connection);

            try
            {
                connection.Open();

                return command.ExecuteNonQuery() > 0;
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

        public bool updateAccount(int id, String description, String name, String email, string pass)
        {
            String sql = "UPDATE `dbi252284`.`person` SET `description` = '"
                + description + "',`name`='" + name + ", `email`= "+ email
                + "', `password`= '" + pass + "' WHERE `person`.`personalID` = " + id + ";";

            MySqlCommand command = new MySqlCommand(sql, connection);

            try
            {
                connection.Open();

                return command.ExecuteNonQuery() > 0;
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

        public List<int> getNonVisitors()
        {
            List<int> ids = new List<int>();

            String sql = "SELECT personalID FROM person WHERE description != 'visitor';";
            MySqlCommand command = new MySqlCommand(sql, connection);

            try
            {
                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ids.Add(Convert.ToInt32(reader[0]));
                }

                return ids;
            }
            catch
            {
                return ids;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<String> getAccountData(int personalID)
        {
            List<String> result = new List<String>();
            String sql = "SELECT description, name, email, password FROM person WHERE personalID = " + personalID + ";";

            MySqlCommand command = new MySqlCommand(sql, connection);

            try
            {
                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    result.Add(reader[0].ToString());
                    result.Add(reader[1].ToString());
                    result.Add(reader[2].ToString());
                    result.Add(reader[3].ToString());
                }

                return result;
            }
            catch
            {
                return result;
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion

        /// <summary>
        /// To check the state of the ticket
        /// -1 if the ticket isn't found in the db.
        /// 1 if the ticket is found and the person isn't inside
        /// 2 if the ticket is found and the person is already in
        /// 3 if the ticket is found and the person left the event
        /// </summary>
        /// <returns></returns>

        #region CheckIN

        public int CheckTicket(String ticket)
        {
            String sql = ("SELECT status FROM person WHERE personalID = " +
                "(SELECT personalID FROM transaction WHERE transactionID = " +
                "(SELECT transactionID FROM tickets WHERE ticketNr = " + Convert.ToInt32(ticket) + "))");
            MySqlCommand command = new MySqlCommand(sql, connection);

            String temp = String.Empty;

            try
            {
                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
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
                return (-1);
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
            catch (Exception)
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


            String sql = ("UPDATE person SET rfid = '" + rFID + "', status = 'arrived'  WHERE personalID = "
                + "(SELECT personalID FROM transaction WHERE transactionID = " +
                "(SELECT transactionID FROM tickets WHERE ticketNr = " + Convert.ToInt32(ticketNR) + "))");
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
            String sql = ("UPDATE person SET rfid = NULL, status = 'left' WHERE rfid = '" + rFID + "'");
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

        public string GetPersonDescription(int personalID)
        {
            String sql = ("SELECT description FROM person WHERE personalID = '" + personalID + "'");
            MySqlCommand command = new MySqlCommand(sql, connection);

            try
            {
                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
                
                if (reader.Read())
                {
                    
                    return Convert.ToString(reader[0]).Trim();
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
        public int personalID(string rFID)
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
        #endregion

        #region Event

        public List<Event> GetEvents()
        {
            String sql = "SELECT * FROM Event";
            MySqlCommand command = new MySqlCommand(sql, connection);
            List<Event> eventid = new List<Event>();

            try
            {
                connection.Open();
                int i = 0;
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Event newevent = new Event(Convert.ToInt32(reader["minimumage"]), Convert.ToString(reader["date"]).Trim(),
                        reader["location"].ToString(), Convert.ToInt32(reader["nrOfParticipants"]),
                        reader["eventname"].ToString(), Convert.ToInt32(reader["maxcamping"]), reader["description"].ToString());
                    eventid.Add(newevent);
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
            String sql = ("INSERT INTO EVENT (minimumAge, date, location, nrOfParticipants, eventName, maxCamping, description) VALUES (" + minage + " ,'" + date.ToString() + " ' ,'" + location.ToString() + "' ," + nrofpeople + " ,'" + name.ToString() + "' ," + maxcamping + " ,'" + des.ToString() + "')");
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



        public int deleteEvent(string EventName)
        {
            String sql = ("DELETE FROM EVENT WHERE eventName = '" + EventName + "'");
            MySqlCommand command = new MySqlCommand(sql, connection);

            try
            {
                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
                return 1;
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



        #endregion

        #region Article

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
        public List<int> TwoArticleID()
        {
            String sql = ("SELECT articleID FROM article");
            MySqlCommand command = new MySqlCommand(sql, connection);
            List<int> articlesID = new List<int>();
            try
            {
                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    articlesID.Add( Convert.ToInt32(reader[0]));
                }
                return articlesID;
            }
            catch
            {
                return articlesID;
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
        public List<Article> NameArticle(int ArticleID)
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
        public List<Article> AllInformaiton ()
        {
            String sql = ("SELECT * FROM kindofarticle");
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
        public List<Article> NameAndSortArticle(int ArticleID)
        {
            String sql = ("SELECT a.SortArticle, k.Name FROM kindofarticle k INNER JOIN article a ON a.ArticleID = k.ArticleID AND a.ArticleID  = " + ArticleID);
            
            MySqlCommand command = new MySqlCommand(sql, connection);


            List<Article> list = new List<Article>();


            connection.Open();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                list.Add(new Article(reader["SortArticle"].ToString(), reader["Name"].ToString()));


            }
            reader.Close();

            //close Connection
            connection.Close();

            //return list to be displayed
            return list;

        }
        //gets a list of 
        public List<Article> InfoArticle(int ArticleID)
        {
            String sql = ("SELECT * FROM article where ArticleID = " + ArticleID);
            MySqlCommand command = new MySqlCommand(sql, connection);


            List<Article> list = new List<Article>();


            connection.Open();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                list.Add(new Article(Convert.ToInt32(reader["articleID"]), reader["SortArticle"].ToString()));


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
        #endregion

        #region Sales

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
        public bool InsertToTransactionarticle(int transactionID, int kinOfArticleID,int articleID, int quantity)
        {
            String sql = "INSERT INTO `transactionarticle`(`transactionID`, `KinOfArticleID`, `articleID`, `quantity`)"
            + "VALUES (" + transactionID + "," + kinOfArticleID + "," + articleID + "," + quantity + ")";

            try
            {
                //open connection
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
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

        public bool InsertToTransaction(int transactionID, int personalID, string description, double cost, DateTime dataTime)
        {
            string sql = "INSERT INTO `transaction`(`transactionID`, `personalID`, `description`, `cost`, `dateTime`)"
            + "VALUES (" + transactionID + "," + personalID + ", " + description + "," + cost + "," + dataTime.ToString() + ")";
            try
            {
                //open connection
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
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
                //close connection
                connection.Close();
            }
        }

        public DataTable GetDatatable(string table, string where)
        {
            String sql = "SELECT * FROM " + table + " " + where;
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
        public int getPeopleLeftFestival()
        {
            String sql = "SELECT COUNT(*) FROM person WHERE status = 'left'";

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
        #endregion

    }
}
