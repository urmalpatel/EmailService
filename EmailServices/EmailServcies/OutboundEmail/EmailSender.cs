using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;

namespace OutboundEmail
{

    public class EmailSender
    {
        EmailSettings emailSettings;
        public EmailSender()
        {
            emailSettings = EmailSettings.GetInstance();
        }
        public void SendEmails()
        {
            using (SqlConnection connection = new SqlConnection(emailSettings.DBConnectionString))
            {
                connection.Open();
                string query = "SELECT EmailAddress FROM EmailAddresses";
                SqlCommand readcommand = new SqlCommand(query, connection);
                SqlCommand updatecommand = new SqlCommand(query, connection);
                SqlDataReader reader = readcommand.ExecuteReader();

                while (reader.Read())
                {
                    string emailAddress = reader["EmailAddress"].ToString();
                    using (MailMessage mail = new MailMessage(emailSettings.FromEmailAddress, emailAddress))
                    {
                        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                        mail.Subject = "Subject";
                        mail.Body = "Email Body";
                        mail.Headers.Add("Disposition-Notification-To", emailSettings.FromEmailAddress);
                        mail.IsBodyHtml = true;

                        using (SmtpClient smtp = new SmtpClient(emailSettings.SmtpServer, emailSettings.SmtpPort))
                        {
                            smtp.Credentials = new System.Net.NetworkCredential(emailSettings.SmtpUsername, emailSettings.SmtpPassword);
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                            string sentquery = $"UPDATE EmailAddresses SET EmailStatus = '{"Sennt"}' WHERE EmailAddress = '{emailAddress}'";
                            updatecommand = new SqlCommand(sentquery, connection);
                            updatecommand.ExecuteNonQuery();
                        }
                    }

                }
            }
        }
    }

}