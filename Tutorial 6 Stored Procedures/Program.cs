using System;
using System.Data;
using MySql.Data.MySqlClient;
using LearnMySQLConnectorClassLibrary;

namespace LearnMySql
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Stored Procedure being called
            // DELIMITER //
            // CREATE PROCEDURE users_active
            // (IN isActive int(1))
            // BEGIN
            // SELECT firstName, lastName from Users
            // WHERE active = isActive;
            // END //
            // DELIMITER;


            HelperClass helperClass = new HelperClass("username", "password", "localhost", "database name", "3306", HelperClass.ServerType.SQLServer);
            MySqlConnection conn = new MySqlConnection(helperClass.connectionString);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "users_active";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@isActive", "1");

                MySqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " " + rdr[1]);
                }
                rdr.Close();

            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
            Console.ReadLine();        
        }
    }
}
