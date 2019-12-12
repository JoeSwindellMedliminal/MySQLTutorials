using System;
using MySql.Data.MySqlClient;
using LearnMySQLConnectorClassLibrary;

namespace LearnMySql
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // HelperClass to hide some stuff
            HelperClass helperClass = new HelperClass("username", "password", "localhost", "database name", "3306", HelperClass.ServerType.SQLServer);         
            MySqlConnection conn = new MySqlConnection(helperClass.connectionString);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open(); // This can fail and will generate an exception
                //preform db operations here
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
            conn.Close();
            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
