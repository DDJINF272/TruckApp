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
    public partial class firstContact : Form
    {
        public firstContact()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClientLogon_Click(object sender, EventArgs e)
        {
            Form clientPortal = new ClientLogon();
            clientPortal.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form staffPortal = new UserLogin();
            staffPortal.ShowDialog();

        }
    }
}
