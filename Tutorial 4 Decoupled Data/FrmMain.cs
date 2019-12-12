using System;
using System.Data;
using MySql.Data.MySqlClient;
using LearnMySQLConnectorClassLibrary;
using System.Windows.Forms;

namespace LearnMySql
{
    public partial class Form1 : Form
    {
        MySqlDataAdapter daUsers;
        DataSet dsUsers;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HelperClass helperClass = new HelperClass("username", "password", "localhost", "database name", "3306", HelperClass.ServerType.SQLServer);
            MySqlConnection conn = new MySqlConnection(helperClass.connectionString);
            try
            {
                lblStatus.Text = "Connecting to MySQL...";

                string sql = "SELECT userID, firstName, lastName FROM Users WHERE active = '1'";
                daUsers = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(daUsers);

                // Create the dataset
                dsUsers = new DataSet();
                // Fill the data apater with the data set
                daUsers.Fill(dsUsers, "Users");

                // Lets display it
                dataGridView.DataSource = dsUsers;
                dataGridView.DataMember = "Users";
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            daUsers.Update(dsUsers, "Users");
            lblStatus.Text = "MySQL Database Updated!";
        }
    }
}
