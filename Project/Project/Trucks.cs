﻿using System;
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

    public partial class Trucks : Form
    {
        //Instantiate Database things...
        SqlConnection conn = new SqlConnection(Globals.DBConn);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter adapter = new SqlDataAdapter();
        

        string type, model, make, cabType, LFW, TotKilo, FU100, LC, BT, HP, TS,regNum,DriverCodeNeeded,KmLastService;
        DateTime DateLastService, DateNextService, TyresLastReplaced;

        private void txtRegistrationNumber_Leave(object sender, EventArgs e)
        {
            regNum = txtRegistrationNumber.Text;
            txtSumRegistrationNumber.Text = regNum;
        }

        private void txtKiloAfterService_Leave(object sender, EventArgs e)
        {
            KmLastService = txtKiloAfterService.Text;
           
        }

        private void cmbDriverCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            DriverCodeNeeded = cmbDriverCodes.SelectedItem.ToString();
            cmbSumDriverCodeNeeded.Items.Clear();
            cmbSumDriverCodeNeeded.Items.Add(DriverCodeNeeded);
            cmbSumDriverCodeNeeded.SelectedItem = DriverCodeNeeded;
            
        }

        private void datePLastService_Leave(object sender, EventArgs e)
        {
            DateLastService = datePLastService.Value.Date;
        }

        private void datePNextService_Leave(object sender, EventArgs e)
        {
            DateNextService = datePNextService.Value.Date;
        }

        private void datePTyreLastReplaced_Leave(object sender, EventArgs e)
        {
            TyresLastReplaced = datePTyreLastReplaced.Value.Date;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            cmd.Parameters.Add("@code", SqlDbType.VarChar);
           
            //Get DriverLicense ID
            int licID = -1, sleepID = -1,maintenanceid = -1,truckid = -1;
            string licenceID = "SELECT licence_code_id FROM DriversLiscenceCodes WHERE code_type = @code";

            try
            {
                cmd.Connection = conn;

                cmd.CommandText = licenceID;
                cmd.Parameters["@code"].Value = DriverCodeNeeded;
                conn.Open();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    licID = Convert.ToInt32(reader["licence_code_id"]);
                }

                conn.Close();

                cmd.Parameters.Add("@sleepcode", SqlDbType.VarChar);
                string sleeptypeID = "SELECT sleeping_type_id FROM TruckSleepTypes WHERE type_name = @sleepcode";

                try
                {

                    cmd.Connection = conn;
                    cmd.CommandText = sleeptypeID;
                    cmd.Parameters["@sleepcode"].Value = cabType;

                    conn.Open();

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        sleepID = Convert.ToInt32(reader["sleeping_type_id"]);
                    }

                    conn.Close();


                    //1st -> Maintenance
                    //Insert
                    cmd.Parameters.Add("@last_service", SqlDbType.Int);
                    cmd.Parameters.Add("@dateLastServiced", SqlDbType.Date);
                    cmd.Parameters.Add("@dateTiresRenewed", SqlDbType.Date);




                    cmd.Parameters["@last_service"].Value = KmLastService;
                    cmd.Parameters["@dateLastServiced"].Value = datePLastService.Value.Date;
                    cmd.Parameters["@dateTiresRenewed"].Value = datePTyreLastReplaced.Value.Date;



                    string insertMain = "INSERT INTO TruckMaintenance (kilos_serviced,date_last_service,date_tires_renewed) VALUES(@last_service,@dateLastServiced,@dateTiresRenewed) SELECT CAST(SCOPE_IDENTITY() AS int)";

                    try
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = insertMain;
                        conn.Open();
                        maintenanceid = (Int32)cmd.ExecuteScalar();
                        conn.Close();



                        //Insert data into the different tables
                        //2nd -> Trucks
                        cmd.Parameters.Add("@truck_registration", SqlDbType.VarChar);
                        cmd.Parameters.Add("@body_type_trailer", SqlDbType.VarChar);
                        cmd.Parameters.Add("@truck_mode", SqlDbType.VarChar);
                        cmd.Parameters.Add("@truck_type", SqlDbType.VarChar);
                        cmd.Parameters.Add("@truck_horse_power", SqlDbType.VarChar);
                        cmd.Parameters.Add("@weight", SqlDbType.Int);
                        cmd.Parameters.Add("@capacity", SqlDbType.Int);
                        cmd.Parameters.Add("@kilos", SqlDbType.Int);
                        cmd.Parameters.Add("@license_code", SqlDbType.Int);
                        cmd.Parameters.Add("@fuel_tank", SqlDbType.Int);
                        cmd.Parameters.Add("@fuel_usage", SqlDbType.Int);
                        cmd.Parameters.Add("@sleep", SqlDbType.Int);
                        cmd.Parameters.Add("@maintenance", SqlDbType.Int);

                        cmd.Parameters["@truck_registration"].Value = regNum;
                        cmd.Parameters["@truck_type"].Value = type;
                        cmd.Parameters["@body_type_trailer"].Value = BT;
                        cmd.Parameters["@truck_mode"].Value = model;
                        cmd.Parameters["@truck_horse_power"].Value = HP;
                        cmd.Parameters["@weight"].Value = LFW;
                        cmd.Parameters["@capacity"].Value = LC;
                        cmd.Parameters["@kilos"].Value = TotKilo;
                        cmd.Parameters["@license_code"].Value = licID;
                        cmd.Parameters["@fuel_tank"].Value = TS;
                        cmd.Parameters["@sleep"].Value = sleepID;
                        cmd.Parameters["@fuel_usage"].Value = FU100;
                        cmd.Parameters["@maintenance"].Value = maintenanceid;

                        string insertTruck = "INSERT INTO Trucks (truck_registration,truck_weight,truck_capacity,truck_type,truck_kilos,body_type_trailer,licence_code_id,mode_type,horse_power,fuel_tank_litre,fuel_usage_kilo,sleeping_type_id,maintenance_id) VALUES(@truck_registration,@weight,@capacity,@truck_type,@kilos,@body_type_trailer,@license_code,@truck_mode,@truck_horse_power,@fuel_tank,@fuel_usage,@sleep,@maintenance)";
                        try
                        {
                            cmd.Connection = conn;
                            cmd.CommandText = insertTruck;
                            conn.Open();
                            cmd.ExecuteNonQuery();
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

                        MessageBox.Show("Successfully Added Truck to Database");
                        this.Close();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error: " + error.Message);
                        conn.Close();
                    }








                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: " + error.Message);
                    conn.Close();
                }


                
                
            }
            catch(Exception error)
            {
                MessageBox.Show("Error: " + error.Message);

                conn.Close();
            }


            
            
        }

        private void Trucks_Load(object sender, EventArgs e)
        {
            
            
        }

        private void txtFU100_Leave(object sender, EventArgs e)
        {
            FU100 = txtFU100.Text;
            txtSumFU100.Text = FU100;
        }

        private void txtLC_Leave(object sender, EventArgs e)
        {
            LC = txtLC.Text;
            txtSumLC.Text = LC;
        }

        private void txtBT_Leave(object sender, EventArgs e)
        {
            BT = txtBT.Text;
            txtSumBT.Text = BT;
        }

        private void txtHP_Leave(object sender, EventArgs e)
        {
            HP = txtHP.Text;
            txtSumHP.Text = HP;
        }

        private void txtTS_Leave(object sender, EventArgs e)
        {
            TS = txtTS.Text;
            txtSumTS.Text = TS;
        }

        private void txtType_Leave(object sender, EventArgs e)
        {
            type = txtType.Text;
            txtSumType.Text = type;
        }

        private void txtModel_Leave(object sender, EventArgs e)
        {
            model = txtModel.Text;
            txtSumModel.Text = model;
        }

        private void txtMake_Leave(object sender, EventArgs e)
        {
            make = txtMake.Text;
            txtSumMake.Text = make;
        }

        private void txtLFW_Leave(object sender, EventArgs e)
        {
            LFW = txtLFW.Text;
            txtSumLFW.Text = LFW;
        }

        private void txtTotKilo_Leave(object sender, EventArgs e)
        {
            TotKilo = txtTotKilo.Text;
            txtSumTotKilo.Text = TotKilo;
        }

        private void cmbCabType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cabType = cmbCabType.SelectedItem.ToString();
            cmbSumCabType.Items.Clear();
            cmbSumCabType.Items.Add(cabType);
            cmbSumCabType.SelectedItem = cabType;
            
        }

        public Trucks()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tabControl1_Enter(object sender, EventArgs e)
        {
            string trucktype = "SELECT * FROM TruckSleepTypes";

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = trucktype;
                conn.Open();

                reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    cmbCabType.Items.Add(reader["type_name"]);
                }


                conn.Close();
            }
            catch(Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
                conn.Close();
            }


            string licenseType = "SELECT * FROM DriversLiscenceCodes";

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = licenseType;
                conn.Open();

                reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    cmbDriverCodes.Items.Add(reader["code_type"]);
                }

                conn.Close();
            }
            catch(Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
                conn.Close();
            }
        }
    }
}