using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.ServiceProcess;

namespace Apex_ESET_Tools
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        private const MessageBoxButton oK = MessageBoxButton.OK;
        readonly string messageBoxText = "Cannot Download Uninstaller, Please check your internet connection and try again.";
        readonly string caption = "Check Internet Connection";
        readonly MessageBoxButton button = oK;
        readonly MessageBoxImage icon = MessageBoxImage.Warning;
        readonly string curFile = @"C:\esetuninstaller.exe";
        public Window3()
        {
            InitializeComponent();
        }

        private void Cancelbtn2(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();
            win1.Show();
            this.Close();
        }
        private void BeginReinstall()
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                using (System.Net.WebClient client = new System.Net.WebClient())
                {
                    client.DownloadFileAsync(new Uri("https://download.eset.com/com/eset/tools/installers/eset_apps_remover/latest/esetuninstaller.exe"),
                               "C:\\esetuninstaller.exe");
                }
            }
            else
            {
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
            //Check if esetuninstaller exists before moving on
            if (File.Exists(curFile))
            {
                //System.Windows.Controls.Button button = Restartbtn as Button;
                //button.IsEnabled = true;
                //button.Visibility = System.Windows.Visibility.Visible;
                //AddScript();
            }
            else
            {
                
            }
            NetAdmin();
        }
        private void AddScript()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "powershell.exe";
            startInfo.Arguments = "/C C:\\Users\\tranc\\source\\repos\\Apex ESET Tools\\changereg.ps1 -Force -Confirm:$false";
            process.StartInfo = startInfo;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            MessageBox.Show(output);
            process.WaitForExit();
            NetAdmin();

        }
        private void NetAdmin()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C net user administrator /active:yes";
            process.StartInfo = startInfo;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            MessageBox.Show(output);
            process.WaitForExit();
        }

    private void rebootPC ()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C wpeutil reboot";
            process.StartInfo = startInfo;
            process.Start();
        }


    }
}
