using System;
using MySql.Data.MySqlClient;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get a db connection object
            var dbCon = DBConnection.Instance();

            // Set the name of the database
            dbCon.DatabaseName = "csc164db_ron";

            // Try to connect to the database
            if (dbCon.IsConnect())
            {
                // If successful, try to read records from a table and display them
                string query = "SELECT * FROM StudentsX";
                var cmd = new MySqlCommand(query, dbCon.Connection);

                try
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string someStringFromColumnOne = reader.GetString(1);
                        string someStringFromColumnTwo = reader.GetString(2);
                        Console.WriteLine(someStringFromColumnOne + "," + someStringFromColumnTwo);
                    }
                }
                catch
                {
                    Console.WriteLine("Database query failed :(");
                }
                dbCon.Close();
            }
            else
            {
                Console.WriteLine("Database connection failed :(");
            }

            Console.Write("\nPress any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}
