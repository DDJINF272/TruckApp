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
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Project
{


    public partial class Form1 : Form
    {
        string userName;
        private StreamWriter streamWriterSender;
        private StreamReader streamReaderRecieve;
        private TcpClient tcpServer;

        // Needed to update the form with messages from another thread
        private delegate void UpdateLogCallback(string strMessage);

        // Needed to set the form to a "disconnected" state from another thread
        private delegate void CloseConnectionCallback(string strReason);
        private Thread threadMessenger;
        private IPAddress ipAddr;
        private bool Connected;
        string current = DateTime.Today.ToString("yyyy-MM-dd");
        string getAllStaff = "SELECT Staff.staff_id AS ID , Staff.firstname + ' ' +  Staff.lastname AS Name, Staff.id_number AS ID_Number, StaffDepartments.department_name AS Working_Department FROM Staff, StaffDepartments WHERE Staff.department_id = StaffDepartments.department_id";
        string getBookedDrivers = "SELECT Staff.firstname + ' ' +  Staff.lastname AS Name, Staff.cellphone_number AS Contact_Number , BookingTruck.booking_id AS Booking_Number FROM Staff,BookingTruck ,TruckDrivers WHERE BookingTruck.driver_id = TruckDrivers.driver_id AND Staff.staff_id = TruckDrivers.staff_id";
        string getAvailableDrivers = "SELECT DISTINCT Staff.firstname + ' ' +  Staff.lastname AS Name, Staff.cellphone_number AS Contact_Number FROM Staff,BookingTruck ,TruckDrivers WHERE Staff.staff_id = TruckDrivers.staff_id EXCEPT SELECT Staff.firstname + ' ' +  Staff.lastname AS Name, Staff.cellphone_number AS Contact_Number FROM Staff,BookingTruck ,TruckDrivers WHERE BookingTruck.driver_id = TruckDrivers.driver_id AND Staff.staff_id = TruckDrivers.staff_id";
        string getAllClients = "SELECT Clients.client_id AS ID, Clients.business_name AS Business_Name, Clients.client_firstname + ' ' + Clients.client_lastname AS Name, Clients.client_cellphone AS Contact_Number FROM Clients";
        string getAllVehicles = "SELECT Trucks.truck_id AS ID,  Trucks.mode_type + '(' + Trucks.truck_registration + ')' AS Vehicle, Trucks.truck_type AS Vehicle_Type, TruckSleepTypes.type_name AS Vehicle_Cab FROM Trucks, TruckSleepTypes WHERE Trucks.sleeping_type_id = TruckSleepTypes.sleeping_type_id";
        string getAllVehicleServiceDates = "SELECT Trucks.mode_type + '(' + Trucks.truck_registration + ')' AS Vehicle, TruckMaintenance.date_last_service AS Date_Serviced, TruckMaintenance.date_tires_renewed AS Tires_Serviced FROM Trucks, TruckMaintenance  WHERE Trucks.maintenance_id = TruckMaintenance.maintenance_id";
        string getAllBookedVehicles = "SELECT Trucks.mode_type + '(' + Trucks.truck_registration + ')' AS Vehicle, BookingTruck.booking_departure_date AS Departure_Date, BookingTruck.booking_arrival_date AS Arrival_Date FROM Trucks, BookingTruck WHERE Trucks.truck_id = BookingTruck.truck_id";




        SqlConnection conn = new SqlConnection(Globals.DBConn);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter adapter = new SqlDataAdapter();

        public Form1(string usr)
        {
            InitializeComponent();
            tabControl2.DrawItem += new DrawItemEventHandler(tabControl2_DrawItem);
            userName = usr;
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
                string getAllClientsWithBookingsActive = "SELECT Clients.business_name AS Business_Name, Clients.client_firstname + ' ' + Clients.client_lastname AS Name, Clients.client_cellphone AS Contact_Number ,BookingTruck.booking_id AS Booking_ID, BookingTruck.booking_arrival_date AS Booking_Arrival FROM Clients, BookingTruck WHERE Clients.client_id = BookingTruck.client_id AND BookingTruck.booking_arrival_date >= '" + current + "'";
                cmd.CommandText = getAllClientsWithBookingsActive;
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

            try
            {

                cmd.Connection = conn;
                string getAllClientsWithBookingsInactive = "SELECT Clients.business_name AS Business_Name, Clients.client_firstname + ' ' + Clients.client_lastname AS Name, Clients.client_cellphone AS Contact_Number ,BookingTruck.booking_id AS Booking_ID, BookingTruck.booking_arrival_date AS Booking_Arrival FROM Clients, BookingTruck WHERE Clients.client_id = BookingTruck.client_id AND BookingTruck.booking_arrival_date <'" + current + "'";
                cmd.CommandText = getAllClientsWithBookingsInactive;
                //conn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adapt.Fill(ds);
                dgvPastBook.DataSource = ds;


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


            //Drivers Booked
            try
            {

                cmd.Connection = conn;
                cmd.CommandText = getBookedDrivers;
                //conn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adapt.Fill(ds);
                dgvBookedDrivers.DataSource = ds;


            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }

            //Drivers Available
            try
            {

                cmd.Connection = conn;
                cmd.CommandText = getAvailableDrivers;
                //conn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                adapt.Fill(ds);
                dgvAvailableDrivers.DataSource = ds;


            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }



            //Initialize Chat
            try
            {
                InitializeConnection();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message);
            }

        }
        private void InitializeConnection()
        {
            // Parse the IP address from the TextBox into an IPAddress object
            ipAddr = IPAddress.Parse("127.0.0.1");
            // Start a new TCP connections to the chat server
            tcpServer = new TcpClient();
            tcpServer.Connect(ipAddr, 1986);

            Connected = true;

            // Send the desired username to the server
            streamWriterSender = new StreamWriter(tcpServer.GetStream());
            streamWriterSender.WriteLine(userName);
            streamWriterSender.Flush();

            threadMessenger = new Thread(new ThreadStart(ReceiveMessages));
            threadMessenger.Start();
        }

        private void ReceiveMessages()
        {

            streamReaderRecieve = new StreamReader(tcpServer.GetStream());

            //response is 1,successful
            string ConResponse = streamReaderRecieve.ReadLine();

            // If the first character is a 1, connection was successful
            if (ConResponse[0] == '1')
            {
                // Update the form to tell it we are now connected
                this.Invoke(new UpdateLogCallback(this.sendToRichtextbox), new object[] { "Connected Successfully!" });
            }
            else
            {
                string infoReason = "Not Connected: ";

                // Extract the reason out of the response message. The reason starts at the 3rd character
                infoReason += ConResponse.Substring(2, ConResponse.Length - 2);

                // Update the form with the reason why we couldn't connect
                this.Invoke(new CloseConnectionCallback(this.CloseConnection), new object[] { infoReason });

                return;
            }
            // While we are successfully connected, read incoming lines from the server
            while (Connected)
            {
                // Show the messages in the richtextbox
                this.Invoke(new UpdateLogCallback(this.sendToRichtextbox), new object[] { streamReaderRecieve.ReadLine() });
            }
        }

        private void sendToRichtextbox(string strMessage)
        {

            rtbChat.AppendText(strMessage + "\r\n");
        }

        private void SendMessage()
        {
            if (tbSend.Lines.Length >= 1)
            {
                streamWriterSender.WriteLine(tbSend.Text);
                streamWriterSender.Flush();
                tbSend.Lines = null;
            }
            tbSend.Text = "";
        }


        private void CloseConnection(string Reason)
        {

            rtbChat.AppendText(Reason + "\r\n");

            // Close the objects
            Connected = false;
            streamWriterSender.Close();
            streamReaderRecieve.Close();
            tcpServer.Close();

            //End thread
            threadMessenger.Abort();
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

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {

        }

        private void emailClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form sendMail = new emailClient();
            sendMail.ShowDialog();
        }

        private void dgvAllVehicles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String truckID = "";

            if(dgvAllVehicles.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dgvAllVehicles.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvAllVehicles.Rows[selectedRowIndex];
                truckID = Convert.ToString(selectedRow.Cells["ID"].Value);
            }

            String values = "SELECT Trucks.mode_type, Trucks.truck_type, Trucks.truck_registration, DriversLiscenceCodes.code_type,  Trucks.truck_weight, Trucks.truck_capacity, Trucks.truck_kilos, Trucks.horse_power, Trucks.fuel_tank_litre, Trucks.fuel_usage_kilo, TruckMaintenance.kilos_serviced, TruckMaintenance.date_last_service, TruckMaintenance.date_tires_renewed FROM Trucks, DriversLiscenceCodes, TruckMaintenance WHERE Trucks.truck_id = " + truckID + " AND DriversLiscenceCodes.licence_code_id = Trucks.licence_code_id AND Trucks.maintenance_id =  TruckMaintenance.maintenance_id";

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = values;
                conn.Open();

                reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    txtVehicleMake.Text = reader["mode_type"].ToString();
                    txtVehicleType.Text = reader["truck_type"].ToString();
                    txtRegistrationNumber.Text = reader["truck_registration"].ToString();
                    txtDriversCodeNeeded.Text = reader["code_type"].ToString();
                    txtLoadFreeWeight.Text = reader["truck_weight"].ToString();
                    txtLoadMaxWeight.Text = reader["truck_capacity"].ToString();
                    txtTotalKm.Text = reader["truck_kilos"].ToString();
                    txtHorsePower.Text = reader["horse_power"].ToString();
                    txtFuelTankSize.Text = reader["fuel_tank_litre"].ToString();
                    txtLiterPer100Km.Text = reader["fuel_usage_kilo"].ToString();
                    txtKMLastService.Text = reader["kilos_serviced"].ToString();
                    txtxDateLastService.Text = reader["date_last_service"].ToString();
                    txtTireLastChange.Text = reader["date_tires_renewed"].ToString();
                }


                reader.Close();
                conn.Close();
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

        private void dgvAllVehicles_Click(object sender, EventArgs e)
        {
            String truckID = "";

            if (dgvAllVehicles.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dgvAllVehicles.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvAllVehicles.Rows[selectedRowIndex];
                truckID = Convert.ToString(selectedRow.Cells["ID"].Value);

                String values = "SELECT Trucks.mode_type, Trucks.truck_type, Trucks.truck_registration, DriversLiscenceCodes.code_type,  Trucks.truck_weight, Trucks.truck_capacity, Trucks.truck_kilos, Trucks.horse_power, Trucks.fuel_tank_litre, Trucks.fuel_usage_kilo, TruckMaintenance.kilos_serviced, TruckMaintenance.date_last_service, TruckMaintenance.date_tires_renewed FROM Trucks, DriversLiscenceCodes, TruckMaintenance WHERE Trucks.truck_id = " + truckID + " AND DriversLiscenceCodes.licence_code_id = Trucks.licence_code_id AND Trucks.maintenance_id =  TruckMaintenance.maintenance_id";

                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = values;
                    conn.Open();

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        txtVehicleMake.Text = reader["mode_type"].ToString();
                        txtVehicleType.Text = reader["truck_type"].ToString();
                        txtRegistrationNumber.Text = reader["truck_registration"].ToString();
                        txtDriversCodeNeeded.Text = reader["code_type"].ToString();
                        txtLoadFreeWeight.Text = reader["truck_weight"].ToString();
                        txtLoadMaxWeight.Text = reader["truck_capacity"].ToString();
                        txtTotalKm.Text = reader["truck_kilos"].ToString();
                        txtHorsePower.Text = reader["horse_power"].ToString();
                        txtFuelTankSize.Text = reader["fuel_tank_litre"].ToString();
                        txtLiterPer100Km.Text = reader["fuel_usage_kilo"].ToString();
                        txtKMLastService.Text = reader["kilos_serviced"].ToString();
                        txtxDateLastService.Text = reader["date_last_service"].ToString();
                        txtTireLastChange.Text = reader["date_tires_renewed"].ToString();
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

        private void AllClientsBindingSource_Click(object sender, EventArgs e)
        {
            String id = "";

            if (dgvAllVehicles.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dgvAllVehicles.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvAllVehicles.Rows[selectedRowIndex];
                id = Convert.ToString(selectedRow.Cells["ID"].Value);

                String values = "SELECT Clients.client_firstname, Clients.client_lastname, Clients.client_landline, Clients.client_cellphone, Clients.client_address_street, Clients.client_address_number, Clients.client_address_area, Clients.client_address_areacode FROM Clients WHERE Clients.client_id = " + id;

                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = values;
                    conn.Open();

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        txtName.Text = reader["client_firstname"].ToString() + " " + reader["client_lastname"].ToString();
                        txtLandline.Text = reader["client_landline"].ToString();
                        txtCellphoneNumber.Text = reader["client_cellphone"].ToString();
                        txtStreetName.Text = reader["client_address_street"].ToString();
                        txtStreetNumber.Text = reader["client_address_number"].ToString();
                        txtSuburb.Text = reader["client_address_area"].ToString();
                        txtAreaCode.Text = reader["client_address_areacode"].ToString();

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

        private void dgvAllStaff_Click(object sender, EventArgs e)
        {
            String id = "";

            if (dgvAllStaff.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dgvAllStaff.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvAllStaff.Rows[selectedRowIndex];
                id = Convert.ToString(selectedRow.Cells["ID"].Value);

                String values = "SELECT Staff.firstname, Staff.lastname, Staff.id_number, Staff.cellphone_number, Staff.street_name, Staff.street_number, Staff.street_area, Staff.address_city, Staff.address_province, StaffBankingDetails.bank_name, StaffBankingDetails.branch_name, StaffBankingDetails.account_type, StaffBankingDetails.account_number, StaffBankingDetails.branch_code, StaffDepartments.department_description, StaffDepartments.department_name FROM Staff, StaffBankingDetails, StaffDepartments WHERE Staff.staff_id = " + id + " AND Staff.department_id = StaffDepartments.department_id AND StaffBankingDetails.banking_id = Staff.banking_id";

                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = values;
                    conn.Open();

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        txtFullname.Text = reader["firstname"].ToString() + " " + reader["lastname"].ToString();
                        txtID.Text = reader["id_number"].ToString();
                        txtCellphone.Text = reader["cellphone_number"].ToString();
                        txtAddress.Text = reader["street_number"].ToString() + " " + reader["street_name"].ToString() + "       " + reader["street_area"].ToString() + "     " + reader["address_city"].ToString() + ", " + reader["address_province"].ToString();
                        txtBankName.Text = reader["bank_name"].ToString();
                        txtBranchName.Text = reader["branch_name"].ToString();
                        txtAccountType.Text = reader["account_type"].ToString();
                        txtAccountNumber.Text = reader["account_number"].ToString();
                        txtBranchCode.Text = reader["branch_code"].ToString();
                        txtDepartment.Text = reader["department_name"].ToString();
                        txtDepartmentDescription.Text = reader["department_description"].ToString();


                    }


                    
                }
                catch (Exception error)
                {

                    MessageBox.Show("Error: " + error.Message);
                }
                finally
                {
                    reader.Close();
                    conn.Close();
                }
            }
        }

        private void AllClientsBindingSource_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String id = "";

            if (AllClientsBindingSource.SelectedCells.Count > 0)
            {
                int selectedRowIndex = AllClientsBindingSource.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = AllClientsBindingSource.Rows[selectedRowIndex];
                id = Convert.ToString(selectedRow.Cells["ID"].Value);
                int loginId = -1;
                String values = "SELECT Clients.client_firstname, Clients.client_lastname, Clients.client_landline, Clients.client_cellphone, Clients.client_address_street, Clients.client_address_number, Clients.client_address_area, Clients.client_address_areacode,Clients.client_login FROM Clients WHERE Clients.client_id = " + id;

                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = values;
                    conn.Open();

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        txtName.Text = reader["client_firstname"].ToString() + " " + reader["client_lastname"].ToString();
                        txtLandline.Text = reader["client_landline"].ToString();
                        txtCellphoneNumber.Text = reader["client_cellphone"].ToString();
                        txtStreetName.Text = reader["client_address_street"].ToString();
                        txtStreetNumber.Text = reader["client_address_number"].ToString();
                        txtSuburb.Text = reader["client_address_area"].ToString();
                        txtAreaCode.Text = reader["client_address_areacode"].ToString();
                        loginId = (Int32)reader["client_login"];

                    }


                }
                catch (Exception error)
                {

                    MessageBox.Show("Error: " + error.Message);
                }
                finally
                {
                    reader.Close();
                    conn.Close();

                    //Get profile picture
                    byte[] img = null;
                    string exe = "SELECT * FROM ClientLogin WHERE clientLogin_id = " + loginId;

                    try
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = exe;
                        conn.Open();
                        reader = cmd.ExecuteReader();

                        while(reader.Read())
                        {
                            img = (byte[])reader["clientProfilePicture"];
                        }

                    }
                    catch(Exception error)
                    {
                        MessageBox.Show("Error: " + error.Message);
                    }
                    finally
                    {
                        ProfilePicture.Image = byteArrayToImage(img);
                        reader.Close();
                        conn.Close();
                    }
                }
            }
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

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void tbSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendMessage();
            }
        }

       

        private void logoutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                CloseConnection("User Disconnect");

            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message);
            }
            finally
            {
                this.Close();
            }
        }

        private void groupBox12_Enter(object sender, EventArgs e)
        {

        }



  



       

       
    }
    
}
