using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Xml;

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
                msg.Body = message;
                client.Send(msg);

                MessageBox.Show("Email Successfully Sent!");
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
        }



        public static void handleEmail(string type,string email,string message,string subj)
        {
            switch (type)
            {
                case "registration":
                    sendRegistration(email);
                    break;
                case "normal":
                    sendNormal(email, message,subj);
                    break;
                case "booking":
                    sendBooking(email,subj);
                    break;
                default:
                    MessageBox.Show("Something went wrong - handleEmail");
                    break;
            }
        }

        private static void sendRegistration(string email)
        {
            string file = AppDomain.CurrentDomain.BaseDirectory + "emailBodies.xml";
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(file);

                XmlNode node = doc.DocumentElement.SelectSingleNode("registration/body");
                string message = "";
                foreach(XmlNode nodes in node.ChildNodes)
                {
                    message += "<h4>" + nodes.InnerText + "</h4>";
                }

                string subject = "";
                node = doc.DocumentElement.SelectSingleNode("registration/subject");
                foreach (XmlNode nodes in node.ChildNodes)
                {
                    subject += nodes.InnerText;
                }

                sendMail(email, message, subject);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
        }

        private static void sendBooking(string email,string code)
        {
            string file = AppDomain.CurrentDomain.BaseDirectory + "emailBodies.xml";
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(file);

                XmlNode node = doc.DocumentElement.SelectSingleNode("booking/body");
                string msg = "";
                msg += "<h4>" + doc.DocumentElement.SelectSingleNode("booking/body/heading").InnerText + "</h4>";
                msg += "<h4>" + doc.DocumentElement.SelectSingleNode("booking/body/Message").InnerText + "</h4>";
                msg += "<h4> Your reference number is : BOOK" + code + "</h4>";
                msg += "<h4>" + doc.DocumentElement.SelectSingleNode("booking/body/info").InnerText + "</h4>";
                msg += "<h4>" + doc.DocumentElement.SelectSingleNode("booking/body/footer").InnerText + "</h4>";

                string subject = "";
                node = doc.DocumentElement.SelectSingleNode("booking/subject");
                foreach (XmlNode nodes in node.ChildNodes)
                {
                    subject += nodes.InnerText;
                }


                sendMail(email, msg, subject);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
        }

        private static void sendNormal(string email,string message,string subj)
        {
            string file = AppDomain.CurrentDomain.BaseDirectory + "emailBodies.xml";
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(file);

                XmlNode node = doc.DocumentElement.SelectSingleNode("normal/body");
                string msg = "";
                msg += "<h4>" + subj + "</h4>";
                msg += "<h4>" + doc.DocumentElement.SelectSingleNode("normal/body/heading").InnerText + "</h4>";
                msg += "<h4>" + message + "</h4>";
                msg += "<h4>" + doc.DocumentElement.SelectSingleNode("normal/body/info").InnerText + "</h4>";
                msg += "<h4>" + doc.DocumentElement.SelectSingleNode("normal/body/footer").InnerText + "</h4>";

                string subject = "";
                node = doc.DocumentElement.SelectSingleNode("normal/subject");
                foreach(XmlNode nodes in node.ChildNodes)
                {
                    subject += nodes.InnerText;
                }
                

                sendMail(email, msg, subject);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
        }



    }
}
