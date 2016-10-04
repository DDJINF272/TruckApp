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
    public partial class AddClient : Form
    {
        SqlConnection conn = new SqlConnection(Globals.DBConn);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter adapter = new SqlDataAdapter();

        string clientID = "";

        public AddClient()
        {
            InitializeComponent();
        }



        private void tabControl1_Click(object sender, EventArgs e)
        {
            txtSumBusinessName.Text = txtBusinessName.Text;
            txtSumCellphone.Text = txtCellphone.Text;
            txtSumCity.Text = txtCityAddress.Text;
            txtSumFirstname.Text = txtFirstname.Text;
            txtSumLastname.Text = txtLastname.Text;
            txtSumLandline.Text = txtLandline.Text;
            txtSumProvince.Text = txtAddressProvince.Text;
            txtSumStreet.Text = txtStreetName.Text;
            txtSumStreetNum.Text = txtStreetNumber.Text;
            txtSumSuburb.Text = txtAddressSuburb.Text;

        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveClient_Click(object sender, EventArgs e)
        {
            string checkforDuplicates = "SELECT client_id FROM Clients WHERE client_firstname = @client_firstname AND " +
                                        "client_lastname = @client_lastname AND business_name = @business_name AND client_cellphone = @client_cellphone";
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = checkforDuplicates;

                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@client_firstname", txtSumFirstname.Text));
                cmd.Parameters.Add(new SqlParameter("@client_lastname", txtSumLastname.Text));
                cmd.Parameters.Add(new SqlParameter("@business_name", txtSumBusinessName.Text));
                cmd.Parameters.Add(new SqlParameter("@client_landline", txtSumLandline.Text));
                cmd.Parameters.Add(new SqlParameter("@client_cellphone", txtSumCellphone.Text));
                cmd.Parameters.Add(new SqlParameter("@client_address_street", txtSumStreet.Text));
                cmd.Parameters.Add(new SqlParameter("@client_address_number", txtSumStreetNum.Text));
                cmd.Parameters.Add(new SqlParameter("@client_address_area", txtSumSuburb.Text));
                cmd.Parameters.Add(new SqlParameter("@client_address_areacode", txtSumProvince.Text));
                cmd.Parameters.Add(new SqlParameter("@client_city", txtSumCity.Text));

                conn.Open();

                reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    reader.Close();
                    conn.Close();

                    try
                    {
                        string insertClient = "INSERT INTO Clients (client_firstname,client_lastname,business_name,client_landline,client_cellphone,client_address_street,client_address_number,client_address_area,client_address_areacode,client_city) " + 
                                            "VALUES(@client_firstname,@client_lastname,@business_name,@client_landline,@client_cellphone,@client_address_street,@client_address_number,@client_address_area,@client_address_areacode,@client_city)";
                        cmd.Connection = conn;
                        cmd.CommandText = insertClient;

                        cmd.Parameters["@client_firstname"].Value = txtSumFirstname.Text;
                        cmd.Parameters["@client_lastname"].Value = txtSumLastname.Text;
                        cmd.Parameters["@business_name"].Value = txtSumBusinessName.Text;
                        cmd.Parameters["@client_landline"].Value = txtSumLandline.Text;
                        cmd.Parameters["@client_cellphone"].Value = txtSumCellphone.Text;
                        cmd.Parameters["@client_address_street"].Value = txtSumStreet.Text;
                        cmd.Parameters["@client_address_number"].Value = txtSumStreetNum.Text;
                        cmd.Parameters["@client_address_area"].Value = txtSumProvince.Text;
                        cmd.Parameters["@client_address_areacode"].Value = txtSumSuburb.Text;
                        cmd.Parameters["@client_city"].Value = txtSumCity.Text;

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successfully Added The New Client");
                        conn.Close();

                        tabControl1.SelectedTab = tabDetails;
                        this.Refresh();

                        clientID = "";
                        txtBusinessName.Text = "";
                        txtCellphone.Text = "";
                        txtCityAddress.Text = "";
                        txtFirstname.Text = "";
                        txtLastname.Text = "";
                        txtLandline.Text = "";
                        txtAddressProvince.Text = "";
                        txtStreetName.Text = "";
                        txtStreetNumber.Text = "";
                        txtAddressSuburb.Text = "";
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error: " + error.Message);
                    }
                }
                else
                {
                    MessageBox.Show("This person is already a client.");
                    conn.Close();
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
        }

        private void btnUpdateClient_Click(object sender, EventArgs e)
        {
            try
            {
                string updateClient = "UPDATE Clients SET client_firstname = @client_firstname, client_lastname = @client_lastname, " +
                                      "business_name = @business_name, client_landline = @client_landline, client_cellphone = @client_cellphone, " +
                                      "client_address_street = @client_address_street, client_address_number = @client_address_number, client_address_area = @client_address_area, " +
                                      "client_address_areacode = @client_address_areacode, client_city = @client_city " +
                                      "WHERE client_id = " + clientID;

                cmd.Connection = conn;

                cmd.Parameters.Clear();

                cmd.Parameters.Add(new SqlParameter("@client_firstname", txtSumFirstname.Text));
                cmd.Parameters.Add(new SqlParameter("@client_lastname", txtSumLastname.Text));
                cmd.Parameters.Add(new SqlParameter("@business_name", txtSumBusinessName.Text));
                cmd.Parameters.Add(new SqlParameter("@client_landline", txtSumLandline.Text));
                cmd.Parameters.Add(new SqlParameter("@client_cellphone", txtSumCellphone.Text));
                cmd.Parameters.Add(new SqlParameter("@client_address_street", txtSumStreet.Text));
                cmd.Parameters.Add(new SqlParameter("@client_address_number", txtSumStreetNum.Text));
                cmd.Parameters.Add(new SqlParameter("@client_address_area", txtSumSuburb.Text));
                cmd.Parameters.Add(new SqlParameter("@client_address_areacode", txtSumProvince.Text));
                cmd.Parameters.Add(new SqlParameter("@client_city", txtSumCity.Text));

                cmd.CommandText = updateClient;

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Client info successfully updated.");
                reader.Close();
                conn.Close();

                clientID = "";
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
        }

        private void cbxClientID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string populateFields = "SELECT * FROM Clients WHERE client_id = " + cbxClientID.Text;

            if (cbxClientID.Text == "**New Client**" || cbxClientID.Text == "")
            {
                txtBusinessName.Text = "";
                txtCellphone.Text = "";
                txtCityAddress.Text = "";
                txtFirstname.Text = "";
                txtLastname.Text = "";
                txtLandline.Text = "";
                txtAddressProvince.Text = "";
                txtStreetName.Text = "";
                txtStreetNumber.Text = "";
                txtAddressSuburb.Text = "";
            }
            else
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = populateFields;
                    conn.Open();
                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtFirstname.Text = reader["client_firstname"].ToString();
                        txtLastname.Text = reader["client_lastname"].ToString();
                        txtBusinessName.Text = reader["business_name"].ToString();
                        txtLandline.Text = reader["client_landline"].ToString();
                        txtCellphone.Text = reader["client_cellphone"].ToString();
                        txtStreetName.Text = reader["client_address_street"].ToString();
                        txtStreetNumber.Text = reader["client_address_number"].ToString();
                        txtAddressProvince.Text = reader["client_address_area"].ToString();
                        txtAddressSuburb.Text = reader["client_address_areacode"].ToString();
                        txtCityAddress.Text = reader["client_city"].ToString();
                    }

                    reader.Close();
                    conn.Close(); 
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: " + error.Message);
                }
            }
        }

        private void AddClient_Load(object sender, EventArgs e)
        {
            string getClient = "SELECT client_id FROM Clients";

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = getClient;
                conn.Open();

                reader = cmd.ExecuteReader();

                cbxClientID.Items.Add("**New Client**");

                while (reader.Read())
                {
                    cbxClientID.Items.Add(reader["client_id"].ToString());
                }

                cbxClientID.SelectedIndex = 0;

                reader.Close();
                conn.Close();
            }
            catch (Exception error)
            {

                MessageBox.Show("Error: " + error.Message);
            }
        }

        private void tabSummary_Click(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxClientID.Text != "**New Client**")
            {
                clientID = cbxClientID.Text;
            }
            else
            {
                clientID = "";
            }

            if (clientID == "")
            {
                btnSaveClient.Enabled = true;
                btnUpdateClient.Enabled = false;
                btnDeleteClient.Enabled = false;
            }
            else
            {
                btnSaveClient.Enabled = false;
                btnUpdateClient.Enabled = true;
                btnDeleteClient.Enabled = true;
            }
        }

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            try
            {
                string DeleteClient = "DELETE FROM Clients WHERE client_id = " + clientID;

                cmd.Connection = conn;

                cmd.CommandText = DeleteClient;

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Client info successfully deleted.");
                reader.Close();
                conn.Close();

                clientID = "";
                cbxClientID.Items.RemoveAt(cbxClientID.SelectedIndex);
                txtBusinessName.Text = "";
                txtCellphone.Text = "";
                txtCityAddress.Text = "";
                txtFirstname.Text = "";
                txtLastname.Text = "";
                txtLandline.Text = "";
                txtAddressProvince.Text = "";
                txtStreetName.Text = "";
                txtStreetNumber.Text = "";
                txtAddressSuburb.Text = "";
                tabControl1.SelectedTab = tabDetails;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
        }
    }
}
