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
    public partial class UserLogin : Form
    {
        SqlConnection conn = new SqlConnection(Globals.DBConn);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter adapter = new SqlDataAdapter();
        public UserLogin()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddStaff newUser = new AddStaff();
            newUser.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
        }

        private void btnClientLogon_Click(object sender, EventArgs e)
        {
            int clientlogon = -1;
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please enter the fields provided");
            }
            string user = txtUsername.Text;
            string pass = txtPassword.Text;
            string query = "SELECT * FROM StaffLogin WHERE username = @user AND password = @pass";

            try
            {
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Connection = conn;
                cmd.CommandText = query;
                conn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    clientlogon = (Int32)reader["login_id"];
                }

                if (clientlogon == -1)
                {
                    MessageBox.Show("Incorrect details or user does not exist");
                }
                else
                {
                    Form main = new Form1();
                    main.ShowDialog();

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
    }
}
