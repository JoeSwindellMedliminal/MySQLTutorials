using System;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Common;
using MySqlX.XDevAPI.CRUD;

namespace Tutorial_7_Basic_CRUD_with_X_Protocol
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string schemaName = "world_x";
            string connectionURI = "mysqlx://password:user@localhost:3306";
            Session session = MySQLX.GetSession(connectionURI);
            Schema schema = session.GetSchema(schemaName);

            // Use the collection 
            var myCollection = schema.GetCollection("countryinfo");
            var docParams = new DbDoc(new { name1 = "Albania", _id1 = "ALB" });

            // Find a document
            DocResult foundDocs = myCollection.Find("Name = :name1 || _id= :_id1").Bind(docParams).Execute();

            while(foundDocs.Next())
            {
                Console.WriteLine(foundDocs.Current["Name"]);
                Console.WriteLine(foundDocs.Current["_id"]);
            }

            // Insert a new document with an id
            var obj = new { _id = "UKN", Name = "Unknown" };
            Result r = myCollection.Add(obj).Execute();

            // Update an existing Document
            docParams = new DbDoc(new { name1 = "Unknown", _id1 = "UKN" });
            r = myCollection.Modify("_id = :Id").Bind("id", "UKN").Set("GNP", "3308").Execute();
            if (r.AffectedItemsCount == 1)
            {
                foundDocs = myCollection.Find("Name = :name1|| _id = :_id1").Bind(docParams).Execute();
                while (foundDocs.Next())
                {
                    Console.WriteLine(foundDocs.Current["Name"]);
                    Console.WriteLine(foundDocs.Current["_id"]);
                    Console.WriteLine(foundDocs.Current["GNP"]);
                }
            }

            // Delete a row in a document
            r = myCollection.Remove("_id = :id").Bind("id", "UKN").Execute();
            // Close the session
            session.Close();
            Console.ReadKey();
        }
    }
}
