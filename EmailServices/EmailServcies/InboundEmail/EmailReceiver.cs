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
using MailKit.Net.Pop3;

namespace InboundEmail
{

    public class EmailReceiver
    {
        EmailSettings emailSettings;
        public EmailReceiver()
        {
            emailSettings = EmailSettings.GetInstance();
        }
        public void ReceiveEmails()
        {
            using (Pop3Client client = new Pop3Client())
            {
                client.Connect(emailSettings.Pop3Server, emailSettings.Pop3Port, true);
                client.Authenticate(emailSettings.Pop3Username, emailSettings.Pop3Password);

                int messageCount = client.GetMessageCount();
                for (int i = 0; i < messageCount; i++)
                {
                    var message = client.GetMessage(i);
                    var internetAddresses = message.From;
                    
                    //string subject = message.Headers.Subject;

                    // Check for read receipt header
                    if (message.Headers.Contains("Disposition-Notification-To"))
                    {
                        // Update the source table to confirm it's a valid email address
                        using (SqlConnection connection = new SqlConnection(emailSettings.DBConnectionString))
                        {
                            connection.Open();
                            foreach (var from in internetAddresses)
                            {
                                string query = $"UPDATE EmailAddresses SET EmailStatus = '{"Read"}' WHERE EmailAddress = '{from.ToString()}'";
                                SqlCommand command = new SqlCommand(query, connection);
                                command.ExecuteNonQuery();
                            }
                        }
                    }

                    // Check for delivery status header
                    if (message.Headers.Contains("X-Failed-Recipients"))
                    {
                        // Update the source table to mark it as not deliverable
                        using (SqlConnection connection = new SqlConnection(emailSettings.DBConnectionString))
                        {
                            connection.Open();
                            foreach (var from in internetAddresses)
                            {
                                string query = $"UPDATE EmailAddresses SET EmailStatus = '{"Bounced"}' WHERE EmailAddress = '{from.ToString()}'";
                                SqlCommand command = new SqlCommand(query, connection);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }

                client.Disconnect(true);
            }

        }
    }

}