using AMONIC_Airlines.Models;
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

namespace AMONIC_Airlines.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для CrashLogDialog.xaml
    /// </summary>
    public partial class CrashLogDialog : Window
    {
        bool CrashType = false;
        CrashLog log;
        public CrashLogDialog(CrashLog crashLog)
        {
            InitializeComponent();
            log = crashLog;
            ErrorBlock.Text = $"No logout detected for your last login on {log.Login}";
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Session199Context db = new Session199Context();

                log.CrashType = CrashType;
                log.Error = ErrorBox.Text;
                db.CrashLogs.Update(log);
                db.SaveChanges();
                this.DialogResult = true;
            } catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void SoftwareRadio_Checked(object sender, RoutedEventArgs e)
        {
            CrashType = false;
        }
        private void SystemRadio_Checked(object sender, RoutedEventArgs e)
        {
            CrashType = true;
        }
    }
}
