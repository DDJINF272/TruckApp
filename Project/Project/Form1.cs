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


    public partial class Form1 : Form
    {

        String getAllStaff = "SELECT Staff.firstname + ' ' +  Staff.lastname AS Name, Staff.id_number AS ID_Number, StaffDepartments.department_name AS Working_Department FROM Staff, StaffDepartments WHERE Staff.department_id = StaffDepartments.department_id";
        String getAllDrivers = "SELECT Staff.firstname + ' ' +  Staff.lastname AS Name, Staff.cellphone_number AS Contact_Number FROM Staff, StaffDepartments WHERE Staff.department_id = StaffDepartments.department_id AND StaffDepartments.department_name = 'Driver'";
        String getAllClients = "SELECT Clients.business_name AS Business_Name, Clients.client_firstname + ' ' + Clients.client_lastname AS Name, Clients.client_cellphone AS Contact_Number FROM Clients";
        String getAllClientsWithBookings = "SELECT Clients.business_name AS Business_Name, Clients.client_firstname + ' ' + Clients.client_lastname AS Name, Clients.client_cellphone AS Contact_Number , BookingTruck.booking_arrival_date AS Booking_Arrival FROM Clients, BookingTruck WHERE Clients.client_id = BookingTruck.client_id";
        String getAllVehicles = "SELECT Trucks.mode_type + '(' + Trucks.truck_registration + ')' AS Vehicle, Trucks.truck_type AS Vehicle_Type, TruckSleepTypes.type_name AS Vehicle_Cab FROM Trucks, TruckSleepTypes WHERE Trucks.sleeping_type_id = TruckSleepTypes.sleeping_type_id";
        String getAllVehicleServiceDates = "SELECT Trucks.mode_type + '(' + Trucks.truck_registration + ')' AS Vehicle, TruckMaintenance.date_last_service AS Date_Serviced, TruckMaintenance.date_tires_renewed AS Tires_Serviced FROM Trucks, TruckMaintenance  WHERE Trucks.maintenance_id = TruckMaintenance.maintenance_id";
        String getAllBookedVehicles = "SELECT Trucks.mode_type + '(' + Trucks.truck_registration + ')' AS Vehicle, BookingTruck.booking_departure_date AS Departure_Date, BookingTruck.booking_arrival_date AS Arrival_Date FROM Trucks, BookingTruck WHERE Trucks.truck_id = BookingTruck.truck_id";




        SqlConnection conn = new SqlConnection(Globals.DBConn);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter adapter = new SqlDataAdapter();

        public Form1()
        {
            InitializeComponent();
            tabControl2.DrawItem += new DrawItemEventHandler(tabControl2_DrawItem);
        }

        private void tabControl2_DrawItem(Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;
            TabPage _tabPage = tabControl2.TabPages[e.Index];
            Rectangle _tabBounds = tabControl2.GetTabRect(e.Index);
            if(e.State == DrawItemState.Selected)
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

        
        private void Form1_Load(object sender, EventArgs e)
        {

            Form booking = new Bookings();
            booking.TopLevel = false;
            booking.Visible = true;
            booking.FormBorderStyle = FormBorderStyle.None;
            booking.Dock = DockStyle.Top;
 
            tabPage6.Controls.Add(booking);
            getDriversActiveData();
            //Bind Staff
            try
            {
                
                cmd.Connection = conn;
                cmd.CommandText = getAllStaff;
                //conn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd); 
                DataTable ds = new DataTable();
                adapt.Fill(ds);
                dgvAllStaff.DataSource = ds;




            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }


            //Bind Clients
            try
            {

                cmd.Connection = conn;
                cmd.CommandText = getAllClients;
                //conn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adapt.Fill(ds);
                AllClientsBindingSource.DataSource = ds;


            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }

            //Bind Clients with bookings

            try
            {

                cmd.Connection = conn;
                cmd.CommandText = getAllClientsWithBookings;
                //conn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adapt.Fill(ds);
                dgvBookedClients.DataSource = ds;


            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }

            //Bind Vehicles
            try
            {

                cmd.Connection = conn;
                cmd.CommandText = getAllVehicles;
                //conn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adapt.Fill(ds);
               dgvAllVehicles.DataSource = ds;


            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }

            //Bind Vehicle Service Dates
            try
            {

                cmd.Connection = conn;
                cmd.CommandText = getAllVehicleServiceDates;
                //conn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adapt.Fill(ds);
                dgvServiceTrucks.DataSource = ds;


            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }

            //Vehicle Booked
            try
            {

                cmd.Connection = conn;
                cmd.CommandText = getAllBookedVehicles;
                //conn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adapt.Fill(ds);
                dgvBookedTrucks.DataSource = ds;


            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }


        }
        private void button6_Click_2(object sender, EventArgs e)
        {
           
        }


        private void button4_Click_2(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AddDepartment d = new AddDepartment();
            d.ShowDialog();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            UserLogin login = new UserLogin();
            login.ShowDialog();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddStaff s = new AddStaff();
            s.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AddClient client = new AddClient();
            client.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Bookings book = new Bookings();
            book.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Trucks addS = new Trucks();
            addS.ShowDialog();
        }

        private void getDriversActiveData()
        {
            string query = "SELECT firstname, lastname, cellphone_number FROM Staff WHERE department_id = @id";
          
            try
            {

                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@id", 3);
                cmd.CommandText = query;
                conn.Open();

                
                
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                adapter.SelectCommand = cmd;
                adapter.Fill(table);
                AvailableDriversBindingSource.DataSource = table;

                dgvAvailableDrivers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
                
              
            }
            catch (Exception error)
            {
                MessageBox.Show("Error:" + error.Message);
            }
            finally
            {
                conn.Close();
            }
          
        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
