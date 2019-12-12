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
                Console.WriteLine("Connecint to MySQL...");
                conn.Open();

                string sql = "INSERT INTO users (firstName, lastName) VALUES ('Buddy Dog', 'Swindell')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }
}
