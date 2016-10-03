using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class AddClient : Form
    {
        public AddClient()
        {
            InitializeComponent();
        }



        private void tabControl1_Click(object sender, EventArgs e)
        {
            txtSumBusinessName.Text = txtBusinessName.Text;
            txtSumCellphone.Text = txtCellphone.Text;
            txtSumCity.Text = txtCityAddress.Text;
            txtSumFirstname.Text = txtFirstname.Text;
            txtSumLastname.Text = txtLastname.Text;
            txtSumLandline.Text = txtLandline.Text;
            txtSumProvince.Text = txtAddressProvince.Text;
            txtSumStreet.Text = txtStreetName.Text;
            txtSumStreetNum.Text = txtStreetNumber.Text;
            txtSumSuburb.Text = txtAddressSuburb.Text;

        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
