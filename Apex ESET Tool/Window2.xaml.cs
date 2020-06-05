using System.Windows;
using System.ServiceProcess;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System;

namespace Apex_ESET_Tools
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            CheckerAsync();
            
        }

        ServiceController sc = ServiceController.GetServices()
            .FirstOrDefault(s => s.ServiceName == "ekm");

        public string keyName = @"HKEY_LOCAL_MACHINE\SOFTWARE\ESET\ESET Security\CurrentVersion\Info";
        public string valueName = "DataDir";
        System.Diagnostics.Process[] pname = System.Diagnostics.Process.GetProcessesByName("eguiProxy");


        private void Next(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();
            win1.Show();
            this.Close();
        }

        public async Task CheckerAsync()
        {
            if (checkInstalled("ESET Security"))
            {
                Installed.Text = "Installed";
                Action.Text = "Try Rebooting";
                //Next Check
            }
            else
            {
                Installed.Text = "Not Installed";
                Action.Text = "Reinstall ESET";
                //Enable Cross on Form > Skip Rest of Checks To to Re-install
            }
            B.Value += (B.Maximum / 4);
            await Task.Delay(2000);

            if (sc == null)
            {
                Service.Text = "Not Running";
                Action.Text = "Reinstall ESET";
                //Enable Cross on Form > Skip Rest of Checks To to Re-install
            }
            else
            {
                Service.Text = "Running";
                Action.Text = "Try Rebooting";
            }
            B.Value += (B.Maximum / 4);
            await Task.Delay(2000);
            if (pname.Length == 0)
            {
                Running.Text = "Not Running";
                Action.Text = "Try Starting the Service Manually from RMM \n If Service Fails to Start Reinstall ESET";
                //Enable Cross on Form > Skip Rest of Checks To to Re-install
            }
            else
            {
                Running.Text = "Running";
                Action.Text = "Try Rebooting";
                //Next Check
            }
            B.Value += (B.Maximum / 4);
            await Task.Delay(2000);
            if (Registry.GetValue(keyName, valueName, null) == null)
            {
                Reg.Text = "Not Found";
                Action.Text = "Reinstall ESET";
                //Enable Cross on Form > Skip Rest of Checks To to Re-install
            }
            else
            {
                Reg.Text = "Found";
                Action.Text = "Running a Test Scan If this does not work Try Rebooting";
                //Run Scan
                RunScan();
            }
            B.Value += (B.Maximum / 4);
            if (B.Value == B.Maximum)
            {
                System.Windows.Controls.Button button = _nextbtn as Button;
                button.IsEnabled = true;
                button.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
               
            }
        }
        public void RunScan() {
            //public string ExecuteCommandSync()
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C C:\\Program Files\\ESET\\ESET Security\\ecls.exe” /base-dir=”C:\\Program Files\\ESET\\ESET Security\\Modules” /no-files /quarantine /memory /log-file=c:\\ESET_scanlog.txt";
                process.StartInfo = startInfo;
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                MessageBox.Show(output);
                process.WaitForExit();
                //return output;
            }
        }

        public static bool checkInstalled(string c_name)
        {
            string displayName;

            string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey);
            if (key != null)
            {
                foreach (RegistryKey subkey in key.GetSubKeyNames().Select(keyName => key.OpenSubKey(keyName)))
                {
                    displayName = subkey.GetValue("DisplayName") as string;
                    if (displayName != null && displayName.Contains(c_name))
                    {
                        return true;
                    }
                }
                key.Close();
            }

            registryKey = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
            key = Registry.LocalMachine.OpenSubKey(registryKey);
            if (key != null)
            {
                foreach (RegistryKey subkey in key.GetSubKeyNames().Select(keyName => key.OpenSubKey(keyName)))
                {
                    displayName = subkey.GetValue("DisplayName") as string;
                    if (displayName != null && displayName.Contains(c_name))
                    {
                        return true;
                    }
                }
                key.Close();
            }
            return false;
        }

    }
}