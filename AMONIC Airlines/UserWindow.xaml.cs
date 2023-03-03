using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
using AMONIC_Airlines.Models;

namespace AMONIC_Airlines
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {

        public UserWindow(User user)
        {
            InitializeComponent();
            TimeSpan timeSum= TimeSpan.Zero;
            //foreach (CrashLog log in user.CrashLogs)
            //{
            //    log.Login.Value.
            //    timeSum.Add(log.);
            //}

            HiBlock.Text = $"Hi {user.FirstName}, Welcome to AMONIC Airlines.";
            //TimeBlock.Text = $"Time spent on system: {}";

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
