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
using System.IO;

namespace Project
{
    
    public partial class ClientForm : Form
    {
        SqlConnection conn = new SqlConnection(Globals.DBConn);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter adapter = new SqlDataAdapter();

        public ClientForm()
        {
            InitializeComponent();
        }

        private int clientid;
        int client;
        byte[] image;
        string fname, lname, busname, cellnum, addrStreet, addrNumber, addrArea, addrCity, email;

        private void tabControl2_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;
            TabPage _tabPage = tabControl2.TabPages[e.Index];
            Rectangle _tabBounds = tabControl2.GetTabRect(e.Index);
            if (e.State == DrawItemState.Selected)
            {
                _textBrush = new SolidBrush(Color.Orange);
                g.FillRectangle(Brushes.White, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            Font _tabFont = new Font("Arial", (float)15.0, FontStyle.Bold, GraphicsUnit.Pixel);
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        public int ClientNumber
        {
            get { return clientid; }
            set { clientid = value; }
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM ClientLogin WHERE clientLogin_id = @id";
           

            try
            {
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@id",clientid);
                cmd.CommandText = query;
                conn.Open();

                reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    image = (byte[])reader["clientProfilePicture"];
                    email = reader["clientMail"].ToString();

                }
            }
            catch(Exception error)
            {
                MessageBox.Show("Error:" + error.Message);
            }
            finally
            {
                
                conn.Close();
                
            }

           

            string query2 = "SELECT * FROM Clients WHERE client_login = @id";

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = query2;
                conn.Open();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    fname = reader["client_firstname"].ToString();
                    lname = reader["client_lastname"].ToString();
                    busname = reader["business_name"].ToString();
                    cellnum = reader["client_cellphone"].ToString();
                    addrStreet = reader["client_address_street"].ToString();
                    addrNumber = reader["client_address_number"].ToString();
                    addrArea = reader["client_address_area"].ToString();
                    addrCity = reader["client_city"].ToString();
                    client = (Int32)reader["client_id"];
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


            cmd.Parameters["@id"].Value = client;

            


            //Set all Values
            ProfilePicture.Image = byteArrayToImage(image);
            lblName.Text = fname;
            lblSurname.Text = lname;
            lblBusname.Text = busname;
            lblStreetNumber.Text = addrNumber;
            lblStreetName.Text = addrStreet;
            lblArea.Text = addrArea;
            lblCity.Text = addrCity;
            lblEmail.Text = email;
            lblCellNum.Text = cellnum;
            lblWelcome.Text = "Welcome, " + fname + " " + lname;

        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            Image returnImage = null;
            try
            {
                MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
                ms.Write(byteArrayIn, 0, byteArrayIn.Length);
                returnImage = Image.FromStream(ms, true);//Exception occurs here
            }
            catch { }
           
            return returnImage;
        }
    }
}
