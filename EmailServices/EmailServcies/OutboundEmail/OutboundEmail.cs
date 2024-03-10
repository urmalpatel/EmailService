using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace OutboundEmail
{
    partial class OutboundEmail : ServiceBase
    {
        System.Windows.Forms.Timer timer;
        public OutboundEmail()
        {
            InitializeComponent();
        }

        private EmailSender sender;
        private EmailSettings setting;
        protected override void OnStart(string[] args)
        {
            sender = new EmailSender();
            setting = new EmailSettings();
            timer = new System.Windows.Forms.Timer();
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            timer.Interval = setting.TimerSetting;
            timer.Enabled = true;
            timer.Start();
        }

        protected override void OnStop()
        {
            sender = null;
            setting = null;
            timer.Stop();
            timer.Enabled = false;

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.sender.SendEmails();
        }
    }
}
