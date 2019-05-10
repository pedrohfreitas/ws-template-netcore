using System;
using System.ServiceProcess;
using Quartz;
using Quartz.Impl;

namespace Sample
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new SampleServiceBase()
            };
            ServiceBase.Run(ServicesToRun);
        }
        
    }
}
