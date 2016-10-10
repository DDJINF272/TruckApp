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
    public partial class ClientLogon : Form
    {
        SqlConnection conn = new SqlConnection(Globals.DBConn);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter adapter = new SqlDataAdapter();
        public ClientLogon()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form newClient = new clientRegistration();
            newClient.ShowDialog();
        }

        private void btnClientLogon_Click(object sender, EventArgs e)
        {
            int clientlogon = -1;
            if(txtClientName.Text == "" || txtClientPassword.Text == "")
            {
                MessageBox.Show("Please enter the fields provided");
            }
            string user = txtClientName.Text;
            string pass = txtClientPassword.Text;
            string query = "SELECT * FROM ClientLogin WHERE clientUser = @user AND clientPass = @pass";

            try
            {
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Connection = conn;
                cmd.CommandText = query;
                conn.Open();


                reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    clientlogon = (Int32)reader["clientLogin_id"];
                }

                if(clientlogon == -1)
                {
                    MessageBox.Show("Incorrect details or user does not exist");
                }
                else
                {
                    //Continue
                    ClientForm client = new ClientForm();
                    client.ClientNumber = clientlogon;
                    client.ShowDialog();
                    
           

                }


            }
            catch(Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
