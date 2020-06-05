using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
namespace Apex_Password_Generator
{
    public partial class MainWindow : Window
    {

        char[] chars = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!£$%^&*()@{}:~<>".ToArray();
        int i = 10;
        int previ = 10;
        Random rand = new Random();        
        public MainWindow()
        {
            InitializeComponent();
            generate();
            Telemetry.TrackEvent("Application Opened");
        }
        private void recalc(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                i = (int)Math.Round(numSlider.Value);
                if(i != previ)
                {
                    generate();
                    previ = i;
                }
                numText.Text = i.ToString() + " characters";
            }catch(Exception ex) { }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            generate();
            Telemetry.TrackEvent("Password Generated");
        }
        void generate()
        {
            string s = "";
            for (int count=0;count<i;count++)
            {
                s += chars[rand.Next(0, chars.Length-1)];
            }
            passBox.Text = s;
        }
        private void mouseup(object sender, MouseButtonEventArgs e)
        {
            generate();
        }
        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            string s = "";
            for (int count = 0; count < i; count++)
            {
                s += chars[rand.Next(0, chars.Length - 1)];
            }
            passBox.Text = s;
            Clipboard.SetText(passBox.Text);
            Telemetry.TrackEvent("Password Generated & Copied");
        }
        
    }
    
}
