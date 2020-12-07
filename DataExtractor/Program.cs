using Npgsql;
using System;

namespace ExtractDataFromPostgre
{
    class Program
    {
        static void Main(string[] args)
        {
            // Call Function
            SelectData();

            // Listen to key event to close console
            Console.WriteLine("Press any key to close the application");
            Console.ReadKey();

        }

        private static void SelectData()
        {
            using (NpgsqlConnection con = GetConnection())
            {
                // Write your query
                string query = @"Select * from public.person ORDER BY id ASC ;";

                // Call instance of query
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);



                try
                {
                    // Open connection
                    con.Open();

                    // Execute query
                    NpgsqlDataReader col = cmd.ExecuteReader();

                    // Read data
                    while (col.Read())
                    {
                        // Print to console
                        Console.Write("{0}\t{1} \n", col[0], col[1]);
                    }

                    // Close connection
                    con.Close();
                }
                catch
                {
                    Console.WriteLine("ERROR! Something wrong with your connection");
                }


            }
        }
        private static NpgsqlConnection GetConnection()
        {
            // This is where you set up your connection to your database
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=m3OReBzC;Database=test");
        }
    }
}
