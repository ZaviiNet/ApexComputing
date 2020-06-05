using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Apex_ESET_Tools
{
    partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
            // For the example
            const string ex1 = "C:\\";

            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "esetuninstaller.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = "-f j -o \"" + ex1 + "\" -z 1.0 -s y ";
        }
    protected override void OnStop()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.FileName = "esetuninstaller.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            const string ex1 = "C:\\";
            startInfo.Arguments = "-f j -o \"" + ex1 + "\" -z 1.0 -s y ";

            // TODO: Add code here to perform any tear-down necessary to stop your service.
            using (Process exeProcess = Process.Start(startInfo))
            {
                exeProcess.WaitForExit();
            }
        }
    }
}
