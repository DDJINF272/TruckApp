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
    public partial class Bookings : Form
    {

        SqlConnection conn = new SqlConnection(Globals.DBConn);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter adapter = new SqlDataAdapter();
        public Bookings()
        {
            InitializeComponent();
        }

        private void Bookings_Load(object sender, EventArgs e)
        {
           
            string populateBookingID = "SELECT * FROM BookingGoods";
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = populateBookingID;
                conn.Open();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbxGoodsID.Items.Add(reader["goods_id"].ToString());
                }


                reader.Close();
                conn.Close();
            }
            catch (Exception error)
            {

                MessageBox.Show("Error: " + error.Message);
            }



            DateTime today = DateTime.Today.Date;

            tbxBookingDateMade.Text = today.ToString("yyy-MM-dd");
            tbxBookingDateMade.Enabled = false;
            //----------------------------------------------------------------------------------------//
            //                           Populate the Truck Booking                                    //
            string fetchDelID = "SELECT * FROM BookingTruck";

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = fetchDelID;

                conn.Open();
                reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    cbxDeliveryID.Items.Add(reader["booking_id"]);
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

            //----------------------------------------------------------------------------------------//
            //                           Populate the Truck ID                                    //

            string fetchTruckID = "SELECT * FROM Trucks";

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = fetchTruckID;

                conn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    
                    cbxBookingTruckID.Items.Add(new ComboBoxItems { name = reader["truck_registration"].ToString(), value = reader["truck_id"].ToString() });
                   
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

            //----------------------------------------------------------------------------------------//
            //                           Populate the Staff ID                                    //


            string fetchStaffID = "SELECT * FROM Staff";

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = fetchStaffID;

                conn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbxBookingStaffID.Items.Add(new ComboBoxItems { name = reader["firstname"] + " " + reader["lastname"], value = reader["staff_id"].ToString() });
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


            //----------------------------------------------------------------------------------------//
            //                           Populate the Client ID                                  //
            string fetchClientID = "SELECT * FROM Clients";

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = fetchClientID;

                conn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbxBookingClientID.Items.Add(new ComboBoxItems { name = reader["client_firstname"] + " " + reader["client_lastname"], value = reader["client_id"].ToString() });
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


            
            //----------------------------------------------------------------------------------------//
            //                           Populate the Goods ID                                   //
            string fetchGoodsID = "SELECT * FROM BookingGoods";

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = fetchGoodsID;

                conn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbxBookingGoodsID.Items.Add(new ComboBoxItems { name = reader["goods_type"].ToString(), value = reader["goods_id"].ToString() });
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

            //----------------------------------------------------------------------------------------//
            //                           Populate the Driver ID                                    //
            string fetchDriverID = "SELECT * FROM TruckDrivers";

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = fetchDriverID;

                conn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string queryDriver = "SELECT * FROM Staff WHERE staff_id = @idstaff";
                    SqlConnection connection = new SqlConnection(Globals.DBConn);
                    SqlCommand command = new SqlCommand();
                    SqlDataReader read;
                    command.Parameters.AddWithValue("@idstaff", reader["staff_id"]);
                    
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = queryDriver;
                        connection.Open();

                        read = command.ExecuteReader();

                        while(read.Read())
                        {
                            cbxBookingDriverID.Items.Add(new ComboBoxItems { name = read["firstname"] + " " + read["lastname"], value = reader["driver_id"].ToString() });
                        }

                    }
                    catch(Exception error)
                    {
                        MessageBox.Show("Error: " + error.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                    
                    
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

        private void cbxGoodsID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxGoodsID.SelectedItem.ToString() == "New...")
            {
                tbxGoodsType.Text = "";
                rtbGoodsDesciption.Text = "";
            }
            else
            {
                string populateFields = "SELECT * FROM BookingGoods WHERE goods_id = @goods_id";
                //Populate current departments
                try
                {

                    cmd.Connection = conn;
                    int var = Convert.ToInt32(cbxGoodsID.SelectedItem);
                    cmd.Parameters.AddWithValue("@goods_id",var);
                    cmd.CommandText = populateFields;


                    conn.Open();

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        tbxGoodsType.Text = reader["goods_type"].ToString();
                        rtbGoodsDesciption.Text = reader["goods_description"].ToString();
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

        private void btnAddGoodsBooking_Click(object sender, EventArgs e)
        {
            if(cbxGoodsID.SelectedItem.ToString() == "New..." && tbxGoodsType.Text != "" && rtbGoodsDesciption.Text != "")
            {
                cmd.Parameters.Add("@goods_type", SqlDbType.VarChar);
                cmd.Parameters.Add("@goods_description", SqlDbType.VarChar);

                string addGoods = "INSERT INTO BookingGoods (goods_type,goods_description) VALUES(@goods_type,@goods_description)";

                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = addGoods;
                    cmd.Parameters["@goods_type"].Value = tbxGoodsType.Text;
                    cmd.Parameters["@goods_description"].Value = rtbGoodsDesciption.Text;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch(Exception error)
                {
                    MessageBox.Show("Error: " + error.Message);
                }
                finally
                {
                    conn.Close();
                    MessageBox.Show("Successfully Added Goods");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please choose 'New...' from Goods ID to create a new item before trying to save.");
            }
        }

        private void btnDeleteGoodsBooking_Click(object sender, EventArgs e)
        {
            if(tbxGoodsType.Text != "" && rtbGoodsDesciption.Text != "" && cbxGoodsID.SelectedItem.ToString() != "New...")
            {
                string deleteGoods = "DELETE FROM BookingGoods WHERE goods_id = @goods_id";
               
                try
                {
                    cmd.Connection = conn;
                    cmd.Parameters["@goods_id"].Value = cbxGoodsID.SelectedItem;
                    cmd.CommandText = deleteGoods;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Deleted Item from Database");


                }
                catch(Exception error)
                {
                    MessageBox.Show("Error: " + error.Message);
                }
                finally
                {
                    conn.Close();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Unable to delete a good with an ID that doesnt exist yet. First add item, then delete it");
            }
        }

        private void btnUpdateGoodsBooking_Click(object sender, EventArgs e)
        {
            cmd.Parameters.Add("@goods_type", SqlDbType.VarChar);
            cmd.Parameters.Add("@goods_description", SqlDbType.VarChar);
            string updateGood = "UPDATE BookingGoods SET goods_type = @goods_type,goods_description = @goods_description WHERE goods_id = @goods_id";

            try
            {
                cmd.Connection = conn;
                cmd.Parameters["@goods_id"].Value = cbxGoodsID.SelectedItem;
                cmd.Parameters["@goods_type"].Value = tbxGoodsType.Text;
                cmd.Parameters["@goods_description"].Value = rtbGoodsDesciption.Text;
                cmd.CommandText = updateGood;
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated Good");
               

            }
            catch(Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
            finally
            {
                conn.Close();
                this.Close();
            }
        }

        private void cbxDeliveryID_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            resetDeliveryTab();
            if (cbxDeliveryID.SelectedItem.ToString() != "New...")
            {

                int idWanted = (Int32)cbxDeliveryID.SelectedItem;
                if (!cmd.Parameters.Contains("@delivery"))
                {
                    cmd.Parameters.AddWithValue("@delivery", idWanted);
                }
                else
                {
                    cmd.Parameters["@delivery"].Value = idWanted;
                }
               

                string readData = "SELECT * FROM BookingTruck WHERE booking_id = @delivery";
                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = readData;

                    conn.Open();
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        cbxBookingTruckID.SelectedText = getTruckRegistration((Int32)reader["truck_id"]);
                        cbxBookingStaffID.SelectedText = getStaffName((Int32)reader["staff_id"]);
                        cbxBookingDriverID.SelectedText = getDriverName((Int32)reader["driver_id"]);
                        cbxBookingClientID.SelectedText = getClientName((Int32)reader["client_id"]);
                        tbxBookingDateMade.Text = Convert.ToDateTime(reader["booking_date_made"]).ToString("yyyy-MM-dd"); 
                        tbxDeliveryDistance.Text = reader["delivery_distance"].ToString();
                        cbxBookingGoodsID.SelectedText = getGoodsName((Int32)reader["goods_id"]);
                        rtbBookingNotes.Text = reader["booking_notes"].ToString();
                        tbxDepartureDate.Text = Convert.ToDateTime(reader["booking_departure_date"]).ToString("yyyy-MM-dd");
                        tbxDepartureStreetName.Text = reader["departure_street_name"].ToString();
                        tbxDepartureAdrNumber.Text = reader["departure_street_number"].ToString();
                        tbxDepartureAdrArea.Text = reader["departure_street_area"].ToString();
                        tbxDepartureCity.Text = reader["departure_city"].ToString();
                        tbxArrivalDate.Text = Convert.ToDateTime(reader["booking_arrival_date"]).ToString("yyyy-MM-dd");
                        tbxArrivalStreetName.Text = reader["arrival_street_name"].ToString();
                        tbxArrivalAdrNumber.Text = reader["arrival_street_number"].ToString();
                        tbxArrivalAdrArea.Text = reader["arrival_street_area"].ToString();
                        tbxArrivalCity.Text = reader["arrival_city"].ToString();

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

            }

        }
        private string getDriverName(int id)
        {
            SqlConnection connection2 = new SqlConnection(Globals.DBConn);
            SqlCommand command2 = new SqlCommand();
            SqlDataReader reader2;
            int staffid = -1;
            string query = "SELECT * FROM TruckDrivers WHERE driver_id = @id";
            command2.Parameters.AddWithValue("@id",id);
 
            command2.Connection = connection2;
            command2.CommandText = query;

            try
            {
                connection2.Open();
                reader2 = command2.ExecuteReader();

                while(reader2.Read())
                {
                    staffid = (Int32)reader2["staff_id"];
                }
            }
            catch(Exception error)
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

        private string getTruckRegistration(int id)
        {
            SqlConnection connection2 = new SqlConnection(Globals.DBConn);
            SqlCommand command3 = new SqlCommand();
            SqlDataReader reader2;
            string retName = "";
            string query = "SELECT * FROM Trucks WHERE truck_id = @id";
            command3.Parameters.AddWithValue("@id", id);
            command3.Connection = connection2;
            command3.CommandText = query;

            try
            {
                connection2.Open();
                reader2 = command3.ExecuteReader();

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

        private string getGoodsName(int id)
        {
            SqlConnection connection2 = new SqlConnection(Globals.DBConn);
            SqlCommand command6 = new SqlCommand();
            SqlDataReader reader2;
            string retName = "";
            string query = "SELECT * FROM BookingGoods WHERE goods_id = @id";
            command6.Parameters.AddWithValue("@id", id);
            command6.Connection = connection2;
            command6.CommandText = query;

            try
            {
                connection2.Open();
                reader2 = command6.ExecuteReader();

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

        private string getStaffName(int id)
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
                    retName = reader2["firstname"].ToString() + " " + reader2["lastname"];
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

        private string getClientName(int id)
        {
            SqlConnection connection2 = new SqlConnection(Globals.DBConn);
            SqlCommand command5 = new SqlCommand();
            SqlDataReader reader2;
            string retName = "";
            string query = "SELECT * FROM Clients WHERE client_id = @id";
            command5.Parameters.AddWithValue("@id", id);
            command5.Connection = connection2;
            command5.CommandText = query;

            try
            {
                connection2.Open();
                reader2 = command5.ExecuteReader();

                while (reader2.Read())
                {
                    retName = reader2["client_firstname"].ToString() + " " + reader2["client_lastname"];
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

        private void resetDeliveryTab()
        {
            tbxBookingDateMade.Text = DateTime.Today.ToString("yyyy-MM-dd");
            cbxBookingTruckID.Text = "";
            cbxBookingStaffID.Text = "";
            cbxBookingDriverID.Text = "";
            cbxBookingClientID.Text = "";
            cbxBookingGoodsID.Text = "";
            tbxDeliveryDistance.Text = "";
            rtbBookingNotes.Text = "";
            tbxDepartureDate.Text = "";
            tbxDepartureStreetName.Text = "";
            tbxDepartureAdrNumber.Text = "";
            tbxDepartureAdrArea.Text = "";
            tbxDepartureCity.Text = "";
            tbxArrivalDate.Text = "";
            tbxArrivalStreetName.Text = "";
            tbxArrivalAdrNumber.Text = "";
            tbxArrivalAdrArea.Text = "";
            tbxArrivalCity.Text = "";
        }

        private void btnAddDeliveryBooking_Click(object sender, EventArgs e)
        {
            if (cbxDeliveryID.SelectedItem != null)
            {
                if (cbxDeliveryID.SelectedItem.ToString() == "New...")
                {
                    Boolean stop = false;
                    stop = checkIfNotNull(cbxBookingTruckID);
                    stop = checkIfNotNull(cbxBookingStaffID);
                    stop = checkIfNotNull(cbxBookingClientID);
                    stop = checkIfNotNull(cbxBookingGoodsID);
                    stop = checkIfNotNull(cbxBookingDriverID);
                    stop = checkIfNotNull(tbxBookingDateMade.Text);
                    stop = checkIfNotNull(tbxDeliveryDistance.Text);
                    stop = checkIfNotNull(rtbBookingNotes.Text);
                    stop = checkIfNotNull(tbxDepartureDate.Text);
                    stop = checkIfNotNull(tbxDepartureStreetName.Text);
                    stop = checkIfNotNull(tbxDepartureAdrNumber.Text);
                    stop = checkIfNotNull(tbxDepartureAdrArea.Text);
                    stop = checkIfNotNull(tbxDepartureCity.Text);
                    stop = checkIfNotNull(tbxArrivalDate.Text);
                    stop = checkIfNotNull(tbxArrivalStreetName.Text);
                    stop = checkIfNotNull(tbxArrivalAdrNumber.Text);
                    stop = checkIfNotNull(tbxArrivalAdrArea.Text);
                    stop = checkIfNotNull(tbxArrivalCity.Text);

                    if (stop == false)
                    {
                        MessageBox.Show("Unable to Add, Please make sure that all fields are filled-in");
                    }
                    else
                    {
                        //peform insert
                        ComboBoxItems truckidvar = (ComboBoxItems)cbxBookingTruckID.SelectedItem;
                        ComboBoxItems staffidvar = (ComboBoxItems)cbxBookingStaffID.SelectedItem;
                        ComboBoxItems clientidvar = (ComboBoxItems)cbxBookingClientID.SelectedItem;
                        ComboBoxItems goodidvar = (ComboBoxItems)cbxBookingGoodsID.SelectedItem;
                        ComboBoxItems driveridvar = (ComboBoxItems)cbxBookingDriverID.SelectedItem;
                       
                        cmd.Parameters.AddWithValue("@truckb_id", truckidvar.value);
                        cmd.Parameters.AddWithValue("@staffb_id", staffidvar.value);
                        cmd.Parameters.AddWithValue("@clientb_id", clientidvar.value);
                        cmd.Parameters.AddWithValue("@goodb_id",goodidvar.value);
                        cmd.Parameters.AddWithValue("@driverb_id", driveridvar.value);
                        cmd.Parameters.AddWithValue("@dateb_id",Convert.ToDateTime(tbxBookingDateMade.Text).Date);
                        cmd.Parameters.AddWithValue("@delivDistb_id", tbxDeliveryDistance.Text);
                        cmd.Parameters.AddWithValue("@Notesb_id", rtbBookingNotes.Text);
                        cmd.Parameters.AddWithValue("@DepartDateb_id", Convert.ToDateTime(tbxDepartureDate.Text).Date);
                        cmd.Parameters.AddWithValue("@DepartStreetNameb_id", tbxDepartureStreetName.Text);
                        cmd.Parameters.AddWithValue("@DepartAdrNumb_id", tbxDepartureAdrNumber.Text);
                        cmd.Parameters.AddWithValue("@DepartAdrAreab_id", tbxDepartureAdrArea.Text);
                        cmd.Parameters.AddWithValue("@Depart_cityb_id", tbxDepartureCity.Text);
                        cmd.Parameters.AddWithValue("@ArrivalDateb_id", Convert.ToDateTime(tbxArrivalDate.Text).Date);
                        cmd.Parameters.AddWithValue("@ArrivalStreetNameb_id", tbxArrivalStreetName.Text);
                        cmd.Parameters.AddWithValue("@ArrivalAdrNumberb_id", tbxArrivalAdrNumber.Text);
                        cmd.Parameters.AddWithValue("@ArrivalAdrAreab_id", tbxArrivalAdrArea.Text);
                        cmd.Parameters.AddWithValue("@ArrivalCityb_id", tbxArrivalCity.Text);

                        string insertStr = "INSERT INTO BookingTruck (booking_date_made,booking_departure_date,booking_arrival_date,departure_street_number,departure_street_name,departure_street_area,departure_city,arrival_street_number,arrival_street_name,arrival_street_area,arrival_city,truck_id,staff_id,goods_id,booking_notes,client_id,driver_id,delivery_distance) VALUES(@dateb_id,@DepartDateb_id,@ArrivalDateb_id,@DepartAdrNumb_id,@DepartStreetNameb_id,@DepartAdrAreab_id,@Depart_cityb_id,@ArrivalAdrNumberb_id,@ArrivalStreetNameb_id,@ArrivalAdrAreab_id,@ArrivalCityb_id,@truckb_id,@staffb_id,@goodb_id,@Notesb_id,@clientb_id,@driverb_id,@delivDistb_id)";

                        try
                        {
                            cmd.Connection = conn;
                            cmd.CommandText = insertStr;
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Successfully Added Booking");
                           

                        }
                        catch(Exception error)
                        {
                            MessageBox.Show("Error: " + error.Message);
                        }
                        finally
                        {

                            conn.Close();
                            this.Close();
                        }

                    }



                }
                else
                {
                    MessageBox.Show("Please select the New... option from the delivery ID dropdown");
                }
            }
            else
            {
                 
                    MessageBox.Show("Please select the New... option from the delivery ID dropdown");
                
            }
        }

        private Boolean checkIfNotNull(string val)
        {
            if(val == "")
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private Boolean checkIfNotNull(ComboBox bx)
        {
            if(bx.SelectedItem == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnDeleteDeliveryBooking_Click(object sender, EventArgs e)
        {
            if(cbxDeliveryID.SelectedItem == null || cbxDeliveryID.SelectedItem.ToString() == "New...")
            {
                MessageBox.Show("Cannot Delete");
            }
            else
            {
              
                cmd.Parameters.AddWithValue("@deleteID", cbxDeliveryID.SelectedItem);
                string delete = "DELETE FROM BookingTruck WHERE booking_id = @deleteID";

                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = delete;
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Successfully Deleted Entry");
                }
                catch(Exception error)
                {
                    MessageBox.Show("Error: " + error.Message);
                }
                finally
                {
                    conn.Close();
                    this.Close();
                }
            }
        }

        private void btnUpdateDeliveryBooking_Click(object sender, EventArgs e)
        {
            if (cbxDeliveryID.SelectedItem == null || cbxDeliveryID.SelectedItem.ToString() == "New...")
            {
                MessageBox.Show("Cannot Update");
            }
            else
            {
                ComboBoxItems truckidvar = (ComboBoxItems)cbxBookingTruckID.SelectedItem;
                ComboBoxItems staffidvar = (ComboBoxItems)cbxBookingStaffID.SelectedItem;
                ComboBoxItems clientidvar = (ComboBoxItems)cbxBookingClientID.SelectedItem;
                ComboBoxItems goodidvar = (ComboBoxItems)cbxBookingGoodsID.SelectedItem;
                ComboBoxItems driveridvar = (ComboBoxItems)cbxBookingDriverID.SelectedItem;

                cmd.Parameters.AddWithValue("@truckb_id", truckidvar.value);
                cmd.Parameters.AddWithValue("@staffb_id", staffidvar.value);
                cmd.Parameters.AddWithValue("@clientb_id", clientidvar.value);
                cmd.Parameters.AddWithValue("@goodb_id", goodidvar.value);
                cmd.Parameters.AddWithValue("@driverb_id", driveridvar.value);
                cmd.Parameters.AddWithValue("@dateb_id", Convert.ToDateTime(tbxBookingDateMade.Text).Date);
                cmd.Parameters.AddWithValue("@delivDistb_id", tbxDeliveryDistance.Text);
                cmd.Parameters.AddWithValue("@Notesb_id", rtbBookingNotes.Text);
                cmd.Parameters.AddWithValue("@DepartDateb_id", Convert.ToDateTime(tbxDepartureDate.Text).Date);
                cmd.Parameters.AddWithValue("@DepartStreetNameb_id", tbxDepartureStreetName.Text);
                cmd.Parameters.AddWithValue("@DepartAdrNumb_id", tbxDepartureAdrNumber.Text);
                cmd.Parameters.AddWithValue("@DepartAdrAreab_id", tbxDepartureAdrArea.Text);
                cmd.Parameters.AddWithValue("@Depart_cityb_id", tbxDepartureCity.Text);
                cmd.Parameters.AddWithValue("@ArrivalDateb_id", Convert.ToDateTime(tbxArrivalDate.Text).Date);
                cmd.Parameters.AddWithValue("@ArrivalStreetNameb_id", tbxArrivalStreetName.Text);
                cmd.Parameters.AddWithValue("@ArrivalAdrNumberb_id", tbxArrivalAdrNumber.Text);
                cmd.Parameters.AddWithValue("@ArrivalAdrAreab_id", tbxArrivalAdrArea.Text);
                cmd.Parameters.AddWithValue("@ArrivalCityb_id", tbxArrivalCity.Text);

                string update = "UPDATE BookingTruck SET booking_date_made = @dateb_id,booking_departure_date = @DepartDateb_id,booking_arrival_date = @ArrivalDateb_id,departure_street_number = @DepartStreetNameb_id,departure_street_name = @DepartStreetNameb_id,departure_street_area = @DepartAdrAreab_id,departure_city = @Depart_cityb_id,arrival_street_number = @ArrivalAdrNumberb_id,arrival_street_name = @ArrivalStreetNameb_id,arrival_street_area = @ArrivalAdrAreab_id,arrival_city = @ArrivalCityb_id,truck_id = @truckb_id,staff_id = @staffb_id,goods_id = @goodb_id,booking_notes = @Notesb_id,client_id = @clientb_id,driver_id = @driverb_id,delivery_distance = @delivDistb_id WHERE booking_id = @updateID";
                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = update;
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Successfully Updated Delivery");
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: " + error.Message);
                }
                finally
                {
                    conn.Close();
                    this.Close();
                }
            }
        }
    }
}
