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
    public partial class clientRegistration : Form
    {
        public clientRegistration()
        {
            InitializeComponent();
        }

        private void btnStartRegister_Click(object sender, EventArgs e)
        {
            Form begReg = new clientRegistrationContent();
            begReg.ShowDialog();
        }
    }
}
