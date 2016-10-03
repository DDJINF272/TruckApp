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
    public partial class AddDepartment : Form
    {
        //Instantiate Database things...
        SqlConnection conn = new SqlConnection(Globals.DBConn);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter adapter = new SqlDataAdapter();
        public AddDepartment()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void AddDepartment_Load(object sender, EventArgs e)
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
               
                while(reader.Read())
                {
                    cmbDepartmentSelect.Items.Add(new Departments { name = reader["department_name"].ToString(), value = reader["department_id"].ToString() });
                }


                reader.Close();
                conn.Close();
            }
            catch (Exception error)
            {

                MessageBox.Show("Error: " + error.Message);
            }
            

        }

        private void btnUpdateDepatment_Click(object sender, EventArgs e)
        {
            if (txtDepartmentDescription.Text == "" || txtDepartmentName.Text == "")
            {
                MessageBox.Show("To update department, you must select a department and provide a value");
            }
            else
            {
                string newDescript = txtDepartmentDescription.Text;
                string deptName = txtDepartmentName.Text;
                
                string str = "UPDATE StaffDepartments SET department_name = @dept_name, department_description = @dept_descript WHERE department_id = @dept_id";

                try
                {

                    cmd.Connection = conn;
                    cmd.CommandText = str;

                    Departments var = (Departments)cmbDepartmentSelect.SelectedItem;
                  
                    cmd.Parameters["@dept_name"].Value = deptName;
                    cmd.Parameters["@dept_descript"].Value =  newDescript;
                    cmd.Parameters["@dept_id"].Value = var.value;
                    conn.Open();

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Department: " + deptName + " has been updated successfully");
                   

                    conn.Close();
                    this.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: " + error.Message);
                }

            }
        }

        private void cmbDepartmentSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Populate textboxes
           
            string populateFields = "SELECT * FROM StaffDepartments WHERE department_id = @dept_id";
            //Populate current departments
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = populateFields;
                Departments var = (Departments)cmbDepartmentSelect.SelectedItem;
                cmd.Parameters["@dept_id"].Value =  var.value;
                conn.Open();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    txtDepartmentName.Text = reader["department_name"].ToString();
                    txtDepartmentDescription.Text = reader["department_description"].ToString();
                }


                reader.Close();
                conn.Close();
            }
            catch (Exception error)
            {

                MessageBox.Show("Error: " + error.Message);
            }


        }

        private void btnRemoveDepartment_Click(object sender, EventArgs e)
        {

            Departments varo = (Departments)cmbDepartmentSelect.SelectedItem;
            if (varo == null)
            {
                MessageBox.Show("Please select an item to delete");
            }
            else
            {
                string populateFields = "DELETE FROM StaffDepartments WHERE department_id = @dept_id";

                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = populateFields;
                    Departments var = (Departments)cmbDepartmentSelect.SelectedItem;
                    cmd.Parameters["@dept_id"].Value = var.value;
                    conn.Open();

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Deleted Department");
                    conn.Close();
                    this.Close();
                }
                catch (Exception error)
                {

                    MessageBox.Show("Error: " + error.Message);
                }
            }
        }

        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
            if(txtAddDepartmentDescription.Text == "" || txtAddDepartmentName.Text == "")
            {
                MessageBox.Show("Please provide a valid field to add a new department");
            }
            else
            {
                //Check for duplicate name
                string checkforDuplicates = "SELECT department_name FROM StaffDepartments WHERE department_name = @dept_name";
                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = checkforDuplicates;
                    cmd.Parameters["@dept_name"].Value = txtAddDepartmentName.Text;
                    conn.Open();

                    reader = cmd.ExecuteReader();

                    if(!reader.HasRows)
                    {
                        //Continue
                        reader.Close();
                        conn.Close();
                        try
                        {
                            string insertDept = "INSERT INTO StaffDepartments (department_name,department_description) VALUES(@dept_name,@dept_descript)";
                            cmd.Connection = conn;
                            cmd.CommandText = insertDept;
                            cmd.Parameters["@dept_descript"].Value = txtAddDepartmentDescription.Text;
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Successfully Added New Department");
                            reader.Close();
                            conn.Close();
                            this.Close();

                        }
                        catch(Exception error)
                        {
                            MessageBox.Show("Error: " + error.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("There already exists a department by the name given");
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
        }
    }
}
