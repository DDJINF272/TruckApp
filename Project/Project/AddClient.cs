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
            cmd.Parameters.AddWithValue("@client_firstname", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@client_lastname", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@business_name", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@client_landline", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@client_cellphone", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@client_address_street", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@client_address_number", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@client_address_area", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@client_address_areacode", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@client_city", SqlDbType.VarChar);

            string checkforDuplicates = "SELECT client_id FROM Clients WHERE client_firstname = @client_firstname AND " +
                                        "client_lastname = @client_lastname AND business_name = @business_name AND client_cellphone = @client_cellphone";
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = checkforDuplicates;
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
                        this.Close();

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

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
