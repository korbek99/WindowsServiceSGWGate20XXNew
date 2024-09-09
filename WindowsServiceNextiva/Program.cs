using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace WindowsServiceNextiva
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        static void Main()
        {
            #if DEBUG
                        ServiceGateway myService = new ServiceGateway();
                        myService.OnDebug();
                        System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
            #else
                                                    ServiceBase[] ServicesToRun;
                                                    ServicesToRun = new ServiceBase[] 
			                                        { 
				                                        new WinServiceSWG() 
			                                        };
                                                    ServiceBase.Run(ServicesToRun);
            #endif
        }
    }
}
