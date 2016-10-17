using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project
{
    public partial class emailClient : Form
    {
        SqlConnection conn = new SqlConnection(Globals.DBConn);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        public emailClient()
        {
            InitializeComponent();
        }

        private void emailClient_Load(object sender, EventArgs e)
        {
            string arg = "SELECT Clients.client_firstname + ' ' + Clients.client_lastname AS Name,ClientLogin.clientMail AS Email FROM Clients,ClientLogin WHERE Clients.client_login = ClientLogin.clientLogin_id";
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = arg;
                conn.Open();
                reader = cmd.ExecuteReader();

                while(reader.Read())
                {

                    cmbClients.Items.Add(new ComboBoxItems { name = reader["Name"].ToString(), value = reader["Email"].ToString() });
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);

            }
            finally
            {
                conn.Close();
            }
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            if(txtBxMessage.Text == "" || txtBxSubject.Text == "")
            {
                MessageBox.Show("Please provide information to send.");
            }
            else
            {
                ComboBoxItems item = (ComboBoxItems)cmbClients.SelectedItem;
                string toSend = item.value;
                
                string subject = txtBxSubject.Text;
                string message = txtBxMessage.Text;

                
                email.sendMail(toSend, message, subject);
            }
        }
    }
}
