using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Machelle_Bakker_Code_Challenge_TKB_April_2020.Model
{
    class DatabaseAccess //this actually should be a singleton
    {
        private SqlConnection OpenConnDB()
        {
            try
            {
                string sourceItem = AppDomain.CurrentDomain.BaseDirectory + "TKB_DB.mdf; Integrated Security = True";

                SqlConnection sqlconn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + sourceItem);


                sqlconn.Open();

                return sqlconn;

            }

            catch (SqlException e)
            {
                SqlConnection sqlconn = null;
                //exception message needs to be passed to controller layer here
                return sqlconn;
            }
        }

        private void CloseConnDB(SqlConnection sqlconn) //Machelle
        {
            sqlconn.Close();
        }

        //added a dummydata insertion to test if data could be inserted at all 
        public void insertDummyDataIntoDatabase()
        {
            string number = "2001";
            string name = "test test";
            string telephone = "09999999";
            string mobile = "99900909";
            string email = "blablabla";
            bool isClosed = false;

            SqlConnection conn = OpenConnDB();
            string query = $"INSERT INTO Debtors (Number, Name, Telephone, Mobile, Email, IsClosed)" +
                           $"VALUES (@number, @name, @telephone, @mobile, @email, @isClosed)";


            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@number", number);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@telephone", telephone);
            command.Parameters.AddWithValue("@mobile", mobile);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@isClosed", isClosed);

            command.ExecuteNonQuery(); //this does not return any rows

            conn.Close();

        }

        //For some reason this doesnt work, yet it does not throw an error. Connection with the database is not the issue as the 
        //pullAllDebtorsFromDatabaseObjects() works when there is dummy data entered in the database manually. Data manipulation
        //methods could not be tested due to this issue.
        public void updateXMLtoDatabase(String filename)
        {
            XMLProcessing xmlproc = new XMLProcessing();
            List<ListDictionary> debtors = xmlproc.readXMLFile(filename);

            //to count any changes, and which type of change specifically;
            int newEntries = 0;
            int updatedEntries = 0;
            int removedEntries = 0;

            foreach (var item in debtors)
            {
                string number = "";
                string name = "";
                string telephone = null;
                string mobile = null;
                string email = null;
                bool isClosed = false; //Default = 0

         

                foreach (DictionaryEntry de in item) //gathering all information needed to update one field in the database
                {
                    string attributeName = de.Key.ToString();
                    string attributeContent = de.Value.ToString();

      

                    switch (attributeName)
                    {
                        case "Number":
                            number = attributeContent;
                            break;

                        case "Name":
                            name = attributeContent;
                            break;

                        case "Telephone":
                            telephone = attributeContent;
                            break;

                        case "Mobile":
                            mobile = attributeContent;
                            break;

                        case "Email":
                            email = attributeContent;
                            break;

                        case "isClosed":
                            isClosed = bool.Parse(attributeContent);
                            break;
                            

                    }
                }

                //check if the debtor number exists in the current database content, if so, check if it requires updating, else,
                //debtor remains null and unchanged
                Debtor debtor = null;

                SqlConnection conn = OpenConnDB();
                string query = $"SELECT Number, Name, Telephone, Mobile, Email, isClosed" +
                               $"FROM Debtors" +
                               $"WHERE Number = @number";
               
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@number", number);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    debtor = readSpecificDebtorFromDatabaseObject(reader);

                    //If one or more attribute(s) from the XML file do(es) not hold the same value as the database debtor attribute,
                    //the database entry gets updated
                    if(debtor.getName() != name || !debtor.getTelephone().Equals(telephone) || !debtor.getMobile().Equals(mobile) || 
                        !debtor.getEmail().Equals(email) || debtor.getIsClosed() != isClosed)
                    {
                        updateDebtor(number, name, telephone, mobile, email, isClosed);
                        updatedEntries++;
                    }
                    
                }
                else
                {
                    insertNewDebtor(number, name, telephone, mobile, email, isClosed);
                    newEntries++;
                }

                conn.Close();
            }


        }

        private Debtor readSpecificDebtorFromDatabaseObject(SqlDataReader reader)
        {
            string number = reader.GetString(0);
            string name = reader.GetString(1);

            string telephone;
            if (reader.IsDBNull(2))
            {
                telephone = null;
            }
            else
            {
                telephone = reader.GetString(2);
            }

            string mobile;
            if (reader.IsDBNull(3))
            {
                mobile = null;
            }
            else
            {
                mobile = reader.GetString(3);
            }

            string email;
            if (reader.IsDBNull(4))
            {
                email = null;
            }
            else
            {
                email = reader.GetString(4);
            }

            bool isClosed = reader.GetBoolean(5);

            Debtor debtor = new Debtor(number, name, telephone, mobile, email, isClosed);

            return debtor;
        }

        private void updateDebtor(string number, string name, string telephone, string mobile, string email, bool isClosed)
        {
            SqlConnection conn = OpenConnDB();
            string query = $"UPDATE Debtors" +
                $"SET Name = @name, Telephone = @telephone, Mobile = @mobile, Email = @email, IsClosed = @isClosed" +
                $"WHERE Number = @number";

            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@number", number);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@telephone", telephone);
            command.Parameters.AddWithValue("@mobile", mobile);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@isClosed", isClosed);

            command.ExecuteNonQuery(); //this does not return any rows


            conn.Close();

        }

        private void insertNewDebtor(string number, string name, string telephone, string mobile, string email, bool isClosed)
        {
            SqlConnection conn = OpenConnDB();
            string query = $"INSERT INTO Debtors VALUES (@number, @name, @telephone, @mobile, @email, @isClosed)";



            SqlCommand command = new SqlCommand(query, conn);

            //This prevents SQL injection
            command.Parameters.AddWithValue("@number", number);
            command.Parameters.AddWithValue("@name", name);

            //parameters can't be just a regular null, it needs to be a DBNull.Value or it won't accept it
            if (telephone == null)
            {
                command.Parameters.AddWithValue("@telephone", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@telephone", telephone);
            }

            if (mobile == null)
            {
                command.Parameters.AddWithValue("@mobile", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@mobile", mobile);
            }

            if (email == null)
            {
                command.Parameters.AddWithValue("@email", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@email", email);
            }

            command.Parameters.AddWithValue("@isClosed", isClosed);


            command.ExecuteNonQuery(); //this does not return any rows


            conn.Close();
        }

        public List<Debtor> pullAllDebtorsFromDatabaseObjects()
        {
            SqlConnection conn = OpenConnDB();
            List<Debtor> debtors = new List<Debtor>();

            string query = $"SELECT Number, Name, Telephone, Mobile, Email, isClosed " +
              $"FROM Debtors";


            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
               Debtor debtor = readSpecificDebtorFromDatabaseObject(reader);
                               
               debtors.Add(debtor);
            }

            conn.Close();

            return debtors;
        }

        }
    }

