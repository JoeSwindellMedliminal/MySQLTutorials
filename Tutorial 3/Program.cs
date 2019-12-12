using System;
using MySql.Data.MySqlClient;
using LearnMySQLConnectorClassLibrary;

namespace LearnMySql
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HelperClass helperClass = new HelperClass("username", "password", "localhost", "database name", "3306", HelperClass.ServerType.SQLServer);
            MySqlConnection conn = new MySqlConnection(helperClass.connectionString);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT COUNT(*) FROM users";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                object result = cmd.ExecuteScalar();

                if(result != null)
                {
                    int r = Convert.ToInt32(result);
                    Console.WriteLine("Number of users in the database is: " + r);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
