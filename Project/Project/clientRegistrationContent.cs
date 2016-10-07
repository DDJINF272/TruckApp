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
   
    public partial class clientRegistrationContent : Form
    {
        public int currentTab = 0;
        string fname, sname, busname, cellnum, landnum,streetname,streetnumber,city,suburb,province,username,password,email;

        private void btnPhase4_Click(object sender, EventArgs e)
        {
            if(txtbxUsername.Text == "" || txtbxPassword.Text == "" || txtbxEmail.Text == "")
            {
                MessageBox.Show("Please complete the fields");
            }
            else
            {
                username = txtbxUsername.Text;
                password = txtbxPassword.Text;
                email = txtbxEmail.Text;

                currentTab++;

                disableTabs(currentTab);
                rbnPhase3.Checked = true;
                lblPhase3.ForeColor = Color.Blue;
                tabControl1.SelectTab(currentTab);





            }
        }

        public clientRegistrationContent()
        {
            InitializeComponent();
        }

        private void chkbxPhase1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabPhase1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPhase3_Click(object sender, EventArgs e)
        {
            if (txtbxStreetName.Text == ""|| txtbxStreetNumber.Text == "" || txtbxSuburb.Text == "" || txtbxCity.Text == "" || txtbxProvince.Text == "")
            {
                MessageBox.Show("Please complete the fields");
            }
            else
            {
                streetname = txtbxStreetName.Text;
                streetnumber = txtbxStreetNumber.Text;
                suburb = txtbxSuburb.Text;
                city = txtbxCity.Text;
                province = txtbxProvince.Text;

                currentTab++;

                disableTabs(currentTab);
                rbnPhase3.Checked = true;
                lblPhase3.ForeColor = Color.Blue;
                tabControl1.SelectTab(currentTab);





            }
        }
   
        private void clientRegistrationContent_Load(object sender, EventArgs e)
        {
            rbtnPhase1.Checked = true;
            rbtnPhase1.ForeColor = Color.Blue;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(!e.TabPage.Enabled)
            {
                e.Cancel = true;
            }
        }

        private void btnPhase2_Click(object sender, EventArgs e)
        {
            if(txtbxFirstname.Text == "" || txtbxLastname.Text == "" || txtbxLandNum.Text == "" || txtbxCellNum.Text == "" || txtbxBussName.Text == "")
            {
                MessageBox.Show("Please complete the fields");
            }
            else
            {
                fname = txtbxFirstname.Text;
                sname = txtbxLastname.Text;
                busname = txtbxBussName.Text;
                cellnum = txtbxCellNum.Text;
                landnum = txtbxLandNum.Text;


                currentTab++;

                disableTabs(currentTab);
                rbnPhase2.Checked = true;
                lblPhase2.ForeColor = Color.Blue;
                tabControl1.SelectTab(currentTab);





            }
        }

        private void disableTabs(int index)
        {
            foreach (TabPage tab in tabControl1.TabPages)
            {
                tab.Enabled = false;
            }
            (tabControl1.TabPages[currentTab] as TabPage).Enabled = true;


            
        }
    }
}
