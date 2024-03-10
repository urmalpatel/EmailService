using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;


namespace InboundEmail
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
                var serviceInstance = new InboundEmail();
                
            }
            else
            {
                ServicesToRun = new ServiceBase[]
                {
                new InboundEmail()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
