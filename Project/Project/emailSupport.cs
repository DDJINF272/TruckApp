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
    public partial class emailSupport : Form
    {
        string client;
        public emailSupport(string clnt)
        {
            InitializeComponent();
            client = clnt;
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            if (txtBxMessage.Text == "" || txtBxSubject.Text == "")
            {
                MessageBox.Show("Please provide information to send.");
            }
            else
            {

                string toSend = "inf272truckapp@gmail.com";

                string subject = "User Support Request from " +client + " ";
                subject +=   txtBxSubject.Text;
                string message = txtBxMessage.Text;


                email.handleEmail("normal", toSend, message, subject);
            }
        }
    }
}
