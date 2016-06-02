using System;
using System.ServiceProcess;

namespace ProcessMonitorService
{
    static class Program
    {

        static void Main()
        {
            try
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    new ProcessMonitorService()
                };
                ServiceBase.Run(ServicesToRun);
            }
            catch (Exception e)
            {

                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "error.log", true))
                {
                    file.WriteLine(e.Message + '\n' + e.StackTrace);
                }
            }


        }
    }
}
