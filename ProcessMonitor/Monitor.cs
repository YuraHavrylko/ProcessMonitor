using System;
using System.Diagnostics;
using System.Management;
using System.Windows.Forms;

namespace ProcessMonitor
{
    public partial class Monitor : Form
    {
        ManagementEventWatcher processStartEvent = new ManagementEventWatcher("SELECT * FROM Win32_ProcessStartTrace");
        ManagementEventWatcher processStopEvent = new ManagementEventWatcher("SELECT * FROM Win32_ProcessStopTrace");
        
        Process[] runningNow = Process.GetProcesses();
        public Monitor()
        {
            InitializeComponent();
            RefreshProcess();
            processStartEvent.EventArrived += processStartEvent_EventArrived;
            processStartEvent.Start();
            processStopEvent.EventArrived += processStopEvent_EventArrived;
            processStopEvent.Start();
            
        }

        void RefreshProcess()
        {
            runningNow = Process.GetProcesses();
            ProcessList.ColumnCount = 4;
            ProcessList.Columns[0].Name = "Id";
            ProcessList.Columns[1].Name = "Process name";
            ProcessList.Columns[2].Name = "Start time";
            ProcessList.Columns[3].Name = "Priority";
            if (ProcessLog.InvokeRequired)
            {
                ProcessList.Invoke(new Action(() =>
                {
                    ProcessList.Rows.Clear();
                    for (int i = 0; i < runningNow.Length - 1; i++)
                    {
                        ProcessList.Rows.Add(runningNow[i].Id, runningNow[i].ProcessName, runningNow[i].StartTime, runningNow[i].BasePriority);
                    }
                    ProcessList.Refresh();
                }));
            }
            else
            {
                
                ProcessList.Rows.Clear();
                for (int i = 0; i < runningNow.Length - 1; i++)
                {
                    ProcessList.Rows.Add(runningNow[i].Id, runningNow[i].ProcessName, runningNow[i].StartTime, runningNow[i].BasePriority);
                }
                ProcessList.Refresh();
            }
        }

        void processStartEvent_EventArrived(object sender, EventArrivedEventArgs e)
        {
            string processName = e.NewEvent.Properties["ProcessName"].Value.ToString();
            string processID = Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value).ToString();

            SetTextSafe("Process started. Name: " + processName + " | ID: " + processID + '\n');
            RefreshProcess();
        }

        void SetTextSafe(string newText)
        {
            if (ProcessLog.InvokeRequired)
                ProcessLog.Invoke(new Action<string>((s) => ProcessLog.AppendText(s)), newText);
            else ProcessLog.AppendText(newText);
        }

        void processStopEvent_EventArrived(object sender, EventArrivedEventArgs e)
        {
            string processName = e.NewEvent.Properties["ProcessName"].Value.ToString();
            string processID = Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value).ToString();

            SetTextSafe("Process stopped. Name: " + processName + " | ID: " + processID + '\n');
            RefreshProcess();
        }

        private void btmRefresh_Click(object sender, EventArgs e)
        {
            RefreshProcess();
        }
    }
}
