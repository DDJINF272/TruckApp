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
    public partial class AddStaff : Form
    {
        public AddStaff()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            txtSumAccountNumber.Text     = txtAccountNumber.Text;
            txtSumAccountType.Text       = txtAccountType.Text;
            txtSumBank.Text              = txtBankName.Text;
            txtSumBranchCode.Text        = txtBranchCode.Text;
            txtSumBranchname.Text        = txtBranchName.Text;
            txtSumCellphone.Text         = txtCellphone.Text;
            txtSumCity.Text              = txtCityAddress.Text;
            txtSumDepartment.Text        = txtSumDepartment.Text;
            txtSumDrivers.Text           = txtSumDrivers.Text;
            txtSumFirstname.Text         = txtFirstname.Text;
            txtSumID.Text                = txtID.Text;
            txtSumLastname.Text          = txtLastname.Text;
            txtSumProvince.Text          = txtAddressProvince.Text;
            txtSumStreet.Text            = txtStreetName.Text;
            txtSumStreetNum.Text         = txtStreetNumber.Text;
            txtSumSuburb.Text            = txtAddressSuburb.Text;

        }
    }
}
