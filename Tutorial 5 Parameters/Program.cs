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

                string sql = "SELECT firstName, LastName FROM Users WHERE UserID=@UserID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                Console.WriteLine("Enter a UserID e.g. '0','1','2': ");
                string user_input = Console.ReadLine();

                cmd.Parameters.AddWithValue("@UserID", user_input);

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr["firstName"] + " " + rdr["lastName"]);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }
}
