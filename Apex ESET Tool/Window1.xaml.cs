using System;
using System.IO;
using System.Windows;


namespace Apex_ESET_Tools
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public Window1() => InitializeComponent();
        private void Exit2(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Reinstall(object sender, RoutedEventArgs e)
        {
            Window3 win3 = new Window3();
            win3.Show();
            this.Close();
        }
        private void Troubleshoot(object sender, RoutedEventArgs e)
        {
            Window2 win2 = new Window2();
            win2.Show();
            this.Close();
        }

        private void Remove(object sender, RoutedEventArgs e)
        {

        }
    }
}
