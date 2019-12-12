using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMySQLConnectorClassLibrary
{
    public class HelperClass
    {
        private string userName;
        private string password;
        private string serverAddress;
        private string database;
        private string port;
        private ServerType sType;

        /// <summary>
        /// <para>MySQL</para>
        /// <para>SQLServer</para>
        /// <para>SQLServerTrusted</para>
        /// <para>SQLServerNamedInstance</para>
        /// </summary>
        public enum ServerType
        {
            MySQL,
            SQLServer,
            SQLServerTrusted,
            SQLServerNamedInstance
        }

        public string connectionString = "";

        public string UserName
        {
            get { return userName;  }
            set { userName = UserName; }
        }

        public string Password
        {
            get { return password; }
            set { password = Password; }
        }

        public string ServerAddress
        {
            get { return serverAddress; }
            set { serverAddress = ServerAddress; }
        }

        public string Database
        {
            get { return database; }
            set { database = Database; }
        }

        public string Port
        {
            get { return port; }
            set { port = Port; }
        }

        public ServerType SType
        {
            get { return sType; }
            set { sType = SType; }
        }

        public void CreateMySQLConnectionString()
        {
            connectionString = String.Format("server={0};user={1};database={2};port={3};password={4}", serverAddress, userName, database, port, password);            
        }

        public void CreateSQLServerConnectionString()
        {
            connectionString = String.Format("Server={0};Database={1};User Id={2};Password={3}", serverAddress, database, userName, password);
        }

        public void CreateSQLServerTrustedConnectionString()
        {
            connectionString = String.Format("Server={0};Database={1};Trusted_Connection=True;", serverAddress, database);
        }

        public void CreateSQLServerInstanceConnectionString()
        {
            connectionString = String.Format("Server={0};Database={1};User Id={2};Password={3}", serverAddress, database, userName, password);
        }

        public HelperClass(string UserName, string Password, string ServerAddress, string Database, string Port, ServerType SType)
        {
            userName = UserName;
            password = Password;
            serverAddress = ServerAddress;
            database = Database;
            port = Port;
            sType = SType;

            switch (sType)
            {
                case ServerType.MySQL:
                    CreateMySQLConnectionString();
                    break;

                case ServerType.SQLServer:
                    CreateSQLServerConnectionString();
                    break;
            }

        }

        public 
    }
}
