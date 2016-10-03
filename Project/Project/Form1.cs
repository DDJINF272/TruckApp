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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Trucks addS = new Trucks();
            addS.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddStaff s = new AddStaff();
            s.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddDepartment d = new AddDepartment();
            d.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddClient ac = new AddClient();
            ac.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UserLogin login = new UserLogin();
            login.ShowDialog();
        }
    }
}
