using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AMONIC_Airlines.Models;
using System.Windows.Threading;
using Microsoft.EntityFrameworkCore;

namespace AMONIC_Airlines
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        DispatcherTimer? _timer;
        TimeSpan _time;
        Session199Context db = new Session199Context();
        int Countdown = 3;
        bool Locked = false;
        public AuthWindow()
        {
            InitializeComponent();
            
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Locked) { MessageBox.Show("Too many failed logins"); return; }
                if (db.Users.Include(x => x.CrashLogs).SingleOrDefault(x => x.Email == LoginBox.Text) is User user) {
                    if (CreateMD5(PasswordBox.Password).ToUpper() == user.Password.ToUpper() )
                    {
                        App.Logged(user);
                        if (user.RoleId == 1)
                        {
                            AdminWindow adminWindow= new AdminWindow();
                            adminWindow.Show();
                            this.Close();

                        } else if (user.RoleId == 2) 
                        {
                            UserWindow userWindow= new UserWindow(user);
                            userWindow.Show();
                            this.Close();
                        }
                        else { Fail("Role not exist"); }
                    }
                    else { Fail($"Incorrect password"); }
                } else { Fail("User not exist"); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void Fail(string message)
        {
            Countdown -= 1; 
            if (Countdown <= 0) { Locked = true; StartTimer(); }
            MessageBox.Show(message);
        }
        private void StartTimer()
        {

            _time = TimeSpan.FromSeconds(10);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                TimerBlock.Text = _time.ToString("c");
                if (_time == TimeSpan.Zero) 
                {
                    _timer!.Stop();
                    Locked = false;
                    Countdown = 3;
                    TimerBlock.Text = "";
                }
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer.Start();
        }
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes); // .NET 5 +

                // Convert the byte array to hexadecimal string prior to .NET 5
                // StringBuilder sb = new System.Text.StringBuilder();
                // for (int i = 0; i < hashBytes.Length; i++)
                // {
                //     sb.Append(hashBytes[i].ToString("X2"));
                // }
                // return sb.ToString();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
