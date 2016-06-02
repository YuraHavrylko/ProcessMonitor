using System;
using System.Collections.Generic;
using System.Management;
using System.ServiceProcess;

namespace ProcessMonitorService
{
   

    public partial class ProcessMonitorService : ServiceBase
    {
        ManagementEventWatcher processStartEvent = new ManagementEventWatcher("SELECT * FROM Win32_ProcessStartTrace");
        ManagementEventWatcher processStopEvent = new ManagementEventWatcher("SELECT * FROM Win32_ProcessStopTrace");

        public ProcessMonitorService()
        {
            InitializeComponent();
        }

        protected List<string> GetSettings()
        {
            List<string> list = new List<string>();
            string line = "";
            using (System.IO.StreamReader file =
            new System.IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory + "monitoredprocess.txt", true))
            {
                while ((line = file.ReadLine()) != null)
                    list.Add(line);
            }
            return list;
        }

        protected override void OnStart(string[] args)
        {
            processStartEvent.EventArrived += processStartEvent_EventArrived;
            processStartEvent.Start();
            processStopEvent.EventArrived += processStopEvent_EventArrived;
            processStopEvent.Start();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
        }

        protected override void OnStop()
        {
            processStartEvent.Stop();
            processStopEvent.Stop();
        }

        void processStartEvent_EventArrived(object sender, EventArrivedEventArgs e)
        {
            string processName = e.NewEvent.Properties["ProcessName"].Value.ToString();
            string processID = Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value).ToString();
            if (GetSettings().Contains(processName) || GetSettings().Count == 0)
            {
                LogInFile("Process started. Name: " + processName + " | ID: " + processID + '\n');
            }
            
        }

        void processStopEvent_EventArrived(object sender, EventArrivedEventArgs e)
        {
            string processName = e.NewEvent.Properties["ProcessName"].Value.ToString();
            string processID = Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value).ToString();
            if (GetSettings().Contains(processName) || GetSettings().Count == 0)
            {
                LogInFile("Process stopped. Name: " + processName + " | ID: " + processID + '\n');
            }
        }

        void LogInFile(string message)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "process.log", true))
            {
                file.WriteLine(message);
            }
        }
    }
}
