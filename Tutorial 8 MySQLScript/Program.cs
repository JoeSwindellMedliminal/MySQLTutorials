using System;
using LearnMySQLConnectorClassLibrary;
using MySql.Data.MySqlClient;

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

                string sql = "INSERT INTO Users(firstName, lastName) VALUES ('Robert','Swindell'); " +
                                "INSERT INTO Users(firstName, lastName) VALUES ('Barbara','Swindell'); " +
                                "INSERT INTO Users(firstName, lastName) VALUES ('Robert','Swindell'); " +
                                "INSERT INTO Users(firstName, lastName) VALUES ('Amanda','Swindell'); " +
                                "INSERT INTO Users(firstName, lastName) VALUES ('Abigail','Swindell'); ";

                MySqlScript script = new MySqlScript(conn, sql);

                script.Error += new MySqlScriptErrorEventHandler(script_Error);
                script.ScriptCompleted += new EventHandler(script_ScriptCompleted);
                script.StatementExecuted += new MySqlStatementExecutedEventHandler(script_StatementExecuted);

                int count = script.Execute();

                Console.WriteLine("Executed" + count + " statement(s).");
                Console.WriteLine("Delimiter: " + script.Delimiter);

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }            
        }

        static void script_StatementExecuted(object sender, MySqlScriptEventArgs args)
        {
            Console.WriteLine("script_StatementExecuted");
        }

        static void script_ScriptCompleted(object sender, EventArgs e)
        {
            // EventArgs e will be EventArgs.Empty for this method
            Console.WriteLine("script_ScriptCompleted!");
        }

        static void script_Error(Object sender, MySqlScriptErrorEventArgs args)
        {
            Console.WriteLine("script_Error" + args.Exception.ToString());
        }


    }
}
