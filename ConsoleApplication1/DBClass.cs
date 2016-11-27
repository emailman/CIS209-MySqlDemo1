using System;
using MySql.Data.MySqlClient;

namespace ConsoleApplication1
{
    public class DBConnection
    {
        private DBConnection()
        {
        }

        private string databaseName = string.Empty;
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string Password { get; set; }
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static DBConnection _instance = null;
        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }

        public bool IsConnect()
        {
            bool result = true;
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(databaseName))
                    result = false;
                else
                {
                    // Strings with connection information
                    string serverName = "phpmyadmin.cdgwdgkn5fuv.us-west-2.rds.amazonaws.com";
                    string uidName = "csc164db_ron";
                    string passwordName = "ra0965";

                    // Build the connection string
                    string connstring = string.Format
                        ("SERVER={0}; PORT=3306; DATABASE={1}; UID={2}; PASSWORD={3};",
                        serverName, databaseName, uidName, passwordName);

                    // Create a connection
                    connection = new MySqlConnection(connstring);

                    // Try to open the connection
                    try
                    {
                        connection.Open();
                        result = true;
                    }
                    catch
                    {
                        result = false;
                    }
                }
            }
            return result;
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
