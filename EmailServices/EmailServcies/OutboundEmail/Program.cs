using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace OutboundEmail
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // Manually invoke debugging entry point
                var serviceInstance = new OutboundEmail();
            }
            else
            {
                ServicesToRun = new ServiceBase[]
                {
                new OutboundEmail()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
