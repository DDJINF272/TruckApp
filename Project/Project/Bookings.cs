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

            cmd.Parameters.Add("@goods_id", SqlDbType.Int);
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
                    cmd.Parameters["@goods_id"].Value = var;
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
    }
}
