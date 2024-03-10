using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace InboundEmail
{
    partial class InboundEmail : ServiceBase
    {
        System.Windows.Forms.Timer timer;
        public InboundEmail()
        {
            InitializeComponent();
        }
        EmailReceiver receiver;
        EmailSettings setting;
        protected override void OnStart(string[] args)
        {
            receiver = new EmailReceiver();
            setting = new EmailSettings();
            timer = new System.Windows.Forms.Timer();
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            timer.Interval = setting.TimerSetting;
            timer.Enabled = true;
            timer.Start();
        }

        protected override void OnStop()
        {
            receiver = null;
            setting = null;
            timer.Stop();
            timer.Enabled = false;

        }

        public void timer_Tick(object sender, EventArgs e)
        {
            receiver.ReceiveEmails();
        }
    }
}
