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
    public partial class Trucks : Form
    {
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

        private void tabControl1_Click(object sender, EventArgs e)
        {
           //---------------------------------------------------------------
           //   SET THE INPUT TEXT AND THE SUMMERY TEXT TO DISPLAY THE SAME

            txtSumBodyType.Text             = txtBodyType.Text;
            txtSumFuelPer100km.Text         = txtFuelPer100Km.Text;
            txtSumHorsePower.Text           = txtHorsePower.Text;
            txtSumLoadCapacity.Text         = txtLoadCapacity.Text;
            txtSumLoadFree.Text             = txtLoadFreeWeight.Text;
            txtSumRegistrationNumber.Text   = txtRegistrationNumber.Text;
            txtSumTankSize.Text             = txtTankSize.Text;
            txtSumTotalKilos.Text           = txtTotalKilos.Text;
            txtSumTruckMake.Text            = txtTruckMake.Text;
            txtSumTruckModel.Text           = txtTruckModel.Text;
            txtSumTruckType.Text            = txtTruckType.Text;
            //---------------------------------------------------------------


        }
    }
}
