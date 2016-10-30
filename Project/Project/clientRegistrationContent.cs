using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project
{

   
    public partial class clientRegistrationContent : Form
    {
        SqlConnection conn = new SqlConnection(Globals.DBConn);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter adapter = new SqlDataAdapter();
        public int currentTab = 0;
        string fname, sname, busname, cellnum, landnum,streetname,streetnumber,city,suburb,province,username,password,cemail;
        Image thumbnail;

        private void btnFinish_Click(object sender, EventArgs e)
        {
            //Convert image into binary
            byte[] image = toBinary(thumbnail);
            if (checkIfUserExists(username))
            {
                MessageBox.Show("User Already Exists");
            }
            else
            {
                int clientlogon = insertIntoClientLogon(username, password, cemail, image);
                insertIntoClients(fname, sname, busname, landnum, cellnum, streetname, streetnumber, city, suburb, province, clientlogon);
                email.handleEmail("registration", cemail, "", "");

                
            }

            this.Close();

        }

        private byte[] toBinary(Image file)
        {
            byte[] arr;
            using (MemoryStream ms = new MemoryStream())
            {
                file.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr = ms.ToArray();
            }
            return arr;
        }

        private int insertIntoClientLogon(string user,string pass,string email,byte[] img)
        {
            int toRet = -1;
            string insert = "INSERT INTO ClientLogin (clientUser,clientPass,clientMail,clientProfilePicture) VALUES(@user,@pass,@email,@image) SELECT CAST(SCOPE_IDENTITY() AS int)";
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@image", img);
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = insert;
                conn.Open();
                toRet = (Int32)cmd.ExecuteScalar();
                

            }
            catch(Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
            finally
            {
                conn.Close();
                
            }
            return toRet;
        }

        private Boolean checkIfUserExists(string username)
        {
            int testVal = -1;
            string test = "SELECT * FROM ClientLogin WHERE clientUser = @username";
            try
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Connection = conn;
                cmd.CommandText = test;
                conn.Open();

                reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    testVal = 1;
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

            if (testVal == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void insertIntoClients(string fname, string sname, string busname, string landnum, string cellnum, string streetname, string streetnumber, string city, string suburb, string province, int clientlogon)
        {
            string insert = "INSERT INTO Clients(client_firstname,client_lastname,business_name,client_landline,client_cellphone,client_address_street,client_address_number,client_address_area,client_address_areacode,client_city,client_login) VALUES(@fname, @sname, @busname, @landnum, @cellnum, @streetname, @streetnumber, @city, @suburb, @province,@clientlogon)";
            try
            {
                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@sname", sname);
                cmd.Parameters.AddWithValue("@busname", busname);
                cmd.Parameters.AddWithValue("@landnum", landnum);
                cmd.Parameters.AddWithValue("@cellnum", cellnum);
                cmd.Parameters.AddWithValue("@streetname", streetname);
                cmd.Parameters.AddWithValue("@streetnumber", streetnumber);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@suburb", suburb);
                cmd.Parameters.AddWithValue("@province", province);
                cmd.Parameters.AddWithValue("@clientLogon", clientlogon);

                cmd.Connection = conn;
                cmd.CommandText = insert;
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Added to our database, please login");
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

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Choose Image";
            dlg.Filter = "jpg files (*.jpg)|*.jpg";

            if(dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                Image original = Image.FromFile(dlg.FileName);
                thumbnail = original.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
                thumbnail.Save(Path.ChangeExtension(dlg.FileName, "thumb"));

                pictureBox1.Image = thumbnail;

                
            }

        }

        private void btnPhase4_Click(object sender, EventArgs e)
        {
            if(txtbxUsername.Text == "" || txtbxPassword.Text == "" || txtbxEmail.Text == "")
            {
                MessageBox.Show("Please complete the fields");
            }
            else
            {
                username = txtbxUsername.Text;
                password = txtbxPassword.Text;
                cemail = txtbxEmail.Text;

                currentTab++;

                disableTabs(currentTab);
                rbnPhase4.Checked = true;
                lblPhase4.ForeColor = Color.Blue;
                tabControl1.SelectTab(currentTab);





            }
        }

        public clientRegistrationContent()
        {
            InitializeComponent();
        }

        private void chkbxPhase1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabPhase1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPhase3_Click(object sender, EventArgs e)
        {
            if (txtbxStreetName.Text == ""|| txtbxStreetNumber.Text == "" || txtbxSuburb.Text == "" || txtbxCity.Text == "" || txtbxProvince.Text == "")
            {
                MessageBox.Show("Please complete the fields");
            }
            else
            {
                streetname = txtbxStreetName.Text;
                streetnumber = txtbxStreetNumber.Text;
                suburb = txtbxSuburb.Text;
                city = txtbxCity.Text;
                province = txtbxProvince.Text;

                currentTab++;

                disableTabs(currentTab);
                rbnPhase3.Checked = true;
                lblPhase3.ForeColor = Color.Blue;
                tabControl1.SelectTab(currentTab);





            }
        }
   
        private void clientRegistrationContent_Load(object sender, EventArgs e)
        {
            rbtnPhase1.Checked = true;
            rbtnPhase1.ForeColor = Color.Blue;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(!e.TabPage.Enabled)
            {
                e.Cancel = true;
            }
        }

        private void btnPhase2_Click(object sender, EventArgs e)
        {
            if(txtbxFirstname.Text == "" || txtbxLastname.Text == "" || txtbxLandNum.Text == "" || txtbxCellNum.Text == "" || txtbxBussName.Text == "")
            {
                MessageBox.Show("Please complete the fields");
            }
            else
            {
                fname = txtbxFirstname.Text;
                sname = txtbxLastname.Text;
                busname = txtbxBussName.Text;
                cellnum = txtbxCellNum.Text;
                landnum = txtbxLandNum.Text;


                currentTab++;

                disableTabs(currentTab);
                rbnPhase2.Checked = true;
                lblPhase2.ForeColor = Color.Blue;
                tabControl1.SelectTab(currentTab);





            }
        }

        private void disableTabs(int index)
        {
            foreach (TabPage tab in tabControl1.TabPages)
            {
                tab.Enabled = false;
            }
            (tabControl1.TabPages[currentTab] as TabPage).Enabled = true;


            
        }
    }
}
