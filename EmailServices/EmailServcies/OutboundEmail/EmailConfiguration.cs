using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Configuration;

namespace OutboundEmail
{
    public class EmailSettings
    {
        public string DBConnectionString { get; set; }
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
        public string FromEmailAddress { get; set; }
        public int TimerSetting { get; set; }

        public static EmailSettings GetInstance()
        {
            string jsonPath = (@"C:\Users\PatelU\source\repos\EmailServices\EmailServcies\OutboundEmail\emailsettings.json"); // Read the JSON data from your file
            string jsonString = File.ReadAllText(jsonPath);
            var serializer = new DataContractJsonSerializer(typeof(EmailSettings));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));

            var emailSettings = (EmailSettings)serializer.ReadObject(ms);

            return emailSettings;
        }
    }


}
