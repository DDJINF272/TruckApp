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

    public partial class AddStaff : Form
    {
        //Instantiate Database things...
        SqlConnection conn = new SqlConnection(Globals.DBConn);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter adapter = new SqlDataAdapter();


        public AddStaff()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            txtSumAccountNumber.Text     = txtAccountNumber.Text;
            txtSumAccountType.Text       = txtAccountType.Text;
            txtSumBank.Text              = txtBankName.Text;
            txtSumBranchCode.Text        = txtBranchCode.Text;
            txtSumBranchname.Text        = txtBranchName.Text;
            txtSumCellphone.Text         = txtCellphone.Text;
            txtSumCity.Text              = txtCityAddress.Text;
            txtSumDepartment.Text        = txtSumDepartment.Text;
            txtSumDrivers.Text           = txtSumDrivers.Text;
            txtSumFirstname.Text         = txtFirstname.Text;
            txtSumID.Text                = txtID.Text;
            txtSumLastname.Text          = txtLastname.Text;
            txtSumProvince.Text          = txtAddressProvince.Text;
            txtSumStreet.Text            = txtStreetName.Text;
            txtSumStreetNum.Text         = txtStreetNumber.Text;
            txtSumSuburb.Text            = txtAddressSuburb.Text;


            try
            {
                txtSumDrivers.Text = cmbLiscence.SelectedItem.ToString();
                txtSumDepartment.Text = cmbDepartment.SelectedItem.ToString();
            }
            catch (Exception)
            {

                txtSumDrivers.Text = "";
                txtSumDepartment.Text = "";
            }

           

        }

        private void AddStaff_Load(object sender, EventArgs e)
        {
            loadDepartmentData();
            loadDriversCodes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd.Parameters.AddWithValue("@staff_id", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@firstname", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@lastname", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@id_number", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@cellphone_number", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@street_number", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@street_name", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@street_area", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@address_province", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@address_city", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@department_id", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@login_id", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@banking_id", SqlDbType.VarChar);

            string checkforDuplicates = "SELECT id_number FROM Staff WHERE id_number = @id_number";
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = checkforDuplicates;
                cmd.Parameters["@staff_id"].Value = txtSumID.Text;
                cmd.Parameters["@firstname"].Value = txtSumID.Text;
                cmd.Parameters["@lastname"].Value = txtSumID.Text;
                cmd.Parameters["@id_number"].Value = txtSumID.Text;
                cmd.Parameters["@cellphone_number"].Value = txtSumID.Text;
                cmd.Parameters["@street_number"].Value = txtSumID.Text;
                cmd.Parameters["@street_name"].Value = txtSumID.Text;
                cmd.Parameters["@street_area"].Value = txtSumID.Text;
                cmd.Parameters["@address_province"].Value = txtSumID.Text;
                cmd.Parameters["@address_city"].Value = txtSumID.Text;
                cmd.Parameters["@department_id"].Value = txtSumID.Text;
                cmd.Parameters["@licence_code_id"].Value = txtSumID.Text;
                cmd.Parameters["@banking_id"].Value = txtSumID.Text;
                cmd.Parameters["@login_id"].Value = txtSumID.Text;

                conn.Open();

                reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    

                    //Continue
                    reader.Close();
                    conn.Close();

                    addLoginDetails();
                    string loginID = getUserLogin();
                    addBankingDetails();
                    string bankID = getUserBank();
                    



                    try
                       {
                           string insertDept = "INSERT INTO Staff (firstname,lastname,id_number,cellphone_number,street_number,street_name,street_area,address_province,address_city,department_id,licence_code_id,banking_id,login_id) VALUES(@firstname,@lastname,@id_number,@cellphone_number,@street_number,@street_name,@street_area,@address_province,@address_city,@department_id,@licence_code_id,@banking_id,@login_id)";
                           cmd.Connection = conn;
                           cmd.CommandText = insertDept;

                              cmd.Parameters["@firstname"].Value = txtSumFirstname.Text;
                              cmd.Parameters["@lastname"].Value = txtSumLastname.Text;
                              cmd.Parameters["@id_number"].Value = txtSumID.Text;
                              cmd.Parameters["@cellphone_number"].Value = txtSumCellphone.Text;
                              cmd.Parameters["@street_number"].Value = txtSumStreetNum.Text;
                              cmd.Parameters["@street_name"].Value = txtSumStreet.Text;
                              cmd.Parameters["@street_area"].Value = txtSumSuburb.Text;
                              cmd.Parameters["@address_province"].Value = txtSumProvince.Text;
                              cmd.Parameters["@address_city"].Value = txtSumCity.Text;

                          Departments dep = (Departments)cmbDepartment.SelectedItem;
                          Departments lic = (Departments)cmbLiscence.SelectedItem;
                          Departments bank = (Departments)cmbDepartment.SelectedItem;

                          cmd.Parameters["@department_id"].Value = dep.value;
                          cmd.Parameters["@licence_code_id"].Value = lic.value;
                          cmd.Parameters["@banking_id"].Value = bankID;
                          cmd.Parameters["@login_id"].Value = loginID;
                          conn.Open();
                           cmd.ExecuteNonQuery();
                           MessageBox.Show("Successfully Added The New Staff Member");
                           reader.Close();
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
                    MessageBox.Show("This person is already employed by you.");
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

        
        // This function is responsible for loading the departments into the department Combo Box when adding a client
        private void loadDepartmentData()
        {
            string populateDepartments = "SELECT * FROM StaffDepartments";
            cmd.Parameters.AddWithValue("@dept_name", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@dept_descript", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@dept_id", SqlDbType.Int);
            //Populate current departments
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = populateDepartments;
                conn.Open();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cmbDepartment.Items.Add(new Departments { name = reader["department_name"].ToString(), value = reader["department_id"].ToString() });
                }


                reader.Close();
                conn.Close();
            }
            catch (Exception error)
            {

                MessageBox.Show("Error: " + error.Message);
            }
        }

        private void loadDriversCodes()
        {
            string populateDepartments = "SELECT * FROM DriversLiscenceCodes";
            cmd.Parameters.AddWithValue("@code_type", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@code_description", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@licence_code_id", SqlDbType.Int);

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = populateDepartments;
                conn.Open();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cmbLiscence.Items.Add(new Departments { name = reader["code_type"].ToString(), value = reader["licence_code_id"].ToString() });
                }


                reader.Close();
                conn.Close();
            }
            catch (Exception error)
            {

                MessageBox.Show("Error: " + error.Message);
            }
        }

        private void addLoginDetails()
        {
            cmd.Parameters.AddWithValue("@username", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@password", SqlDbType.VarChar);
            try
            {
                    try
                    {
                        string insertDept = "INSERT INTO StaffLogin (username,password) VALUES(@username,@password)";
                        cmd.Connection = conn;
                        cmd.CommandText = insertDept;
                        cmd.Parameters["@username"].Value = txtUsername.Text;
                        cmd.Parameters["@password"].Value = s.Text;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        reader.Close();
                        conn.Close();
                }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error: " + error.Message);
                    }
                


                reader.Close();
                conn.Close();
            }
            catch (Exception error)
            {

                MessageBox.Show("Error: " + error.Message);
            }
        }

        private string getUserLogin()
        {
            string populateFields = "SELECT login_id FROM StaffLogin WHERE username = @username";
          
                cmd.Connection = conn;
                cmd.CommandText = populateFields;
                cmd.Parameters["@username"].Value = txtUsername.Text;
                 conn.Open();
                 string val = "";
                reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    val = reader["login_id"].ToString();
                 }

                 reader.Close();
                conn.Close();
                return val ;
            
            }

        private void addBankingDetails()
        {
            cmd.Parameters.AddWithValue("@bank_name", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@account_type", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@account_number", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@branch_name", SqlDbType.VarChar);
            cmd.Parameters.AddWithValue("@branch_code", SqlDbType.VarChar);

            try
            {
                try
                {
                    string insertDept = "INSERT INTO StaffBankingDetails (bank_name,account_type,account_number,branch_name,branch_code) VALUES(@bank_name,@account_type,@account_number,@branch_name,@branch_code)";
                    cmd.Connection = conn;
                    cmd.CommandText = insertDept;
                    cmd.Parameters["@bank_name"].Value = txtBankName.Text;
                    cmd.Parameters["@account_type"].Value = txtAccountType.Text;
                    cmd.Parameters["@account_number"].Value = txtAccountNumber.Text;
                    cmd.Parameters["@branch_name"].Value = txtBranchName.Text;
                    cmd.Parameters["@branch_code"].Value = txtBranchCode.Text;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    reader.Close();
                    conn.Close();

                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: " + error.Message);
                }



                reader.Close();
                conn.Close();
            }
            catch (Exception error)
            {

                MessageBox.Show("Error: " + error.Message);
            }
        }

        private string getUserBank()
        {
            string populateFields = "SELECT banking_id FROM StaffBankingDetails WHERE account_number = @account_number";

            cmd.Connection = conn;
            cmd.CommandText = populateFields;
            cmd.Parameters["@account_number"].Value = txtAccountNumber.Text;
            conn.Open();
            string val = "";
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                val = reader["banking_id"].ToString();
            }

            reader.Close();
            conn.Close();
            return val;
        }


       

    }
}
