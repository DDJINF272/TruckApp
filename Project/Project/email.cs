using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Project
{
    class email
    {

        public static void sendMail(string email,string message,string subject)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("inf272truckapp@gmail.com", "TruckApp@123");
                MailMessage msg = new MailMessage();
                msg.IsBodyHtml = true;
                msg.To.Add(email);
                msg.From = new MailAddress("inf272truckapp@gmail.com");
                msg.Subject = subject;
                msg.Body = formatMessage(message);
                client.Send(msg);

                MessageBox.Show("Email Successfully Sent!");
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
        }

        private static string formatMessage(string msg)
        {
            string toRet = "<h3>Attention Valued TruckApp customer</h3>";
            toRet += "<h4>" + msg + "</h4><br><br>";
            toRet += "<p>Thank you for your time, enjoy your day further</p>";
            toRet += "<b>TruckApp Management team</p><p>Tel - xxx xxx xxx</p><p>Email - inf272truckapp@gmail.com</p>";

            return toRet;
                
                
                
        }

       
        
    }
}
