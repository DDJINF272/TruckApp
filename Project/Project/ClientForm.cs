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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have been successfully logged out!");
            this.Close();
        }

        private void contactSupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form supportMail = new emailSupport(fname + " " + lname);
            supportMail.ShowDialog();
        }

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

           

            //Load All Values into truck
            string getTrucks = "SELECT BookingTruck.booking_date_made AS Creation_Date, BookingTruck.booking_departure_date AS Departure_Date, BookingTruck.booking_arrival_date AS Arrival_Date, BookingTruck.departure_street_number + ' ' + BookingTruck.departure_street_name + ', ' + BookingTruck.departure_street_area + ', ' + BookingTruck.departure_city AS Source_Address, BookingTruck.arrival_street_number + ' ' + BookingTruck.arrival_street_name + ', ' + BookingTruck.arrival_street_area + ', ' + BookingTruck.arrival_city AS Destination_Address, Trucks.truck_registration AS Truck, Staff.firstname + ' ' + Staff.lastname AS Staff_Member, BookingGoods.goods_type AS Goods,BookingTruck.booking_notes AS Notes FROM BookingTruck,Trucks,BookingGoods,Staff WHERE BookingTruck.client_id = @clientid AND BookingTruck.booking_arrival_date >= @currentDate AND BookingTruck.truck_id = Trucks.truck_id AND BookingTruck.staff_id = Staff.staff_id AND BookingTruck.goods_id = BookingGoods.goods_id";
            string current = DateTime.Today.ToString("yyyy-MM-dd");
            try
            {
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@clientid", client);
                cmd.Parameters.AddWithValue("@currentDate", current);
                cmd.CommandText = getTrucks; 
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adapt.Fill(ds);
                dataGridActiveBook.DataSource = ds;

                

            }
            catch(Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }

            string getTrucks2 = "SELECT BookingTruck.booking_date_made AS Creation_Date, BookingTruck.booking_departure_date AS Departure_Date, BookingTruck.booking_arrival_date AS Arrival_Date, BookingTruck.departure_street_number + ' ' + BookingTruck.departure_street_name + ', ' + BookingTruck.departure_street_area + ', ' + BookingTruck.departure_city AS Source_Address, BookingTruck.arrival_street_number + ' ' + BookingTruck.arrival_street_name + ', ' + BookingTruck.arrival_street_area + ', ' + BookingTruck.arrival_city AS Destination_Address, Trucks.truck_registration AS Truck, Staff.firstname + ' ' + Staff.lastname AS Staff_Member, BookingGoods.goods_type AS Goods,BookingTruck.booking_notes AS Notes FROM BookingTruck,Trucks,BookingGoods,Staff WHERE BookingTruck.client_id = @clientid AND BookingTruck.booking_arrival_date < @currentDate AND BookingTruck.truck_id = Trucks.truck_id AND BookingTruck.staff_id = Staff.staff_id AND BookingTruck.goods_id = BookingGoods.goods_id";
            string current2 = DateTime.Today.ToString("yyyy-MM-dd");
            try
            {
                cmd.Connection = conn;
                cmd.Parameters["@currentDate"].Value = current2;
                cmd.CommandText = getTrucks2;
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adapt.Fill(ds);
                dataGridInactiveBook.DataSource = ds;



            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
            finally
            {
                conn.Close();
            }


            //Load Old Values into truck

        }
        public string getTruckName(int id)
        {
            SqlConnection connection2 = new SqlConnection(Globals.DBConn);
            SqlCommand command4 = new SqlCommand();
            SqlDataReader reader2;
            string retName = "";
            string query = "SELECT * FROM Trucks WHERE truck_id = @id";
            command4.Parameters.AddWithValue("@id", id);
            command4.Connection = connection2;
            command4.CommandText = query;

            try
            {
                connection2.Open();
                reader2 = command4.ExecuteReader();

                while (reader2.Read())
                {
                    retName = reader2["truck_registration"].ToString();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
            finally
            {
                connection2.Close();
            }


            return retName;
        }

        public string getStaffName(int id)
        {
            SqlConnection connection2 = new SqlConnection(Globals.DBConn);
            SqlCommand command4 = new SqlCommand();
            SqlDataReader reader2;
            string retName = "";
            string query = "SELECT * FROM Staff WHERE staff_id = @id";
            command4.Parameters.AddWithValue("@id", id);
            command4.Connection = connection2;
            command4.CommandText = query;

            try
            {
                connection2.Open();
                reader2 = command4.ExecuteReader();

                while (reader2.Read())
                {
                    retName = reader2["firstname"] + " " + reader2["lastname"];
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
            finally
            {
                connection2.Close();
            }


            return retName;
        }

        public string getGoodsName(int id)
        {
            SqlConnection connection2 = new SqlConnection(Globals.DBConn);
            SqlCommand command4 = new SqlCommand();
            SqlDataReader reader2;
            string retName = "";
            string query = "SELECT * FROM BookingGoods WHERE goods_id = @id";
            command4.Parameters.AddWithValue("@id", id);
            command4.Connection = connection2;
            command4.CommandText = query;

            try
            {
                connection2.Open();
                reader2 = command4.ExecuteReader();

                while (reader2.Read())
                {
                    retName = reader2["goods_type"].ToString();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
            finally
            {
                connection2.Close();
            }


            return retName;
        }


        public string getDriverName(int id)
        {
            SqlConnection connection2 = new SqlConnection(Globals.DBConn);
            SqlCommand command2 = new SqlCommand();
            SqlDataReader reader2;
            int staffid = -1;
            string query = "SELECT * FROM TruckDrivers WHERE driver_id = @id";
            command2.Parameters.AddWithValue("@id", id);

            command2.Connection = connection2;
            command2.CommandText = query;

            try
            {
                connection2.Open();
                reader2 = command2.ExecuteReader();

                while (reader2.Read())
                {
                    staffid = (Int32)reader2["staff_id"];
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
            finally
            {
                connection2.Close();
            }



            //Next Query
            string query2 = "SELECT * FROM Staff WHERE staff_id = @id";
            command2.Parameters["@id"].Value = staffid;
            command2.Connection = connection2;
            command2.CommandText = query2;
            string retName = "";
            try
            {
                connection2.Open();
                reader2 = command2.ExecuteReader();

                while (reader2.Read())
                {
                    retName = reader2["firstname"] + " " + reader2["lastname"];
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
            finally
            {
                connection2.Close();
            }


            return retName;
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
