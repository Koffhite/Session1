using AMONIC_Airlines.Dialogs;
using AMONIC_Airlines.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AMONIC_Airlines
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static CrashLog currentlog = new CrashLog();
        public App()
        {

        }
        public static void Logged(User user)
        {
            try
            {
                Session199Context db = new Session199Context();
                if (db.CrashLogs.OrderBy(x => x.Login).LastOrDefault(x => x.User.Id == user.Id) is CrashLog dblog)
                {
                    if (dblog.Logout == null) 
                    { 
                        CrashLogDialog crashLogDialog = new CrashLogDialog(dblog);
                        crashLogDialog.ShowDialog();
                    }
                }
                Random rnd = new Random();
                currentlog.Id = rnd.Next(1, 100000);
                currentlog.UserId = user.Id;
                currentlog.Login = DateTime.Now;

                db.CrashLogs.Add(currentlog);
                db.SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            try
            {
                if (currentlog.Login != null)
                {
                    Session199Context db = new Session199Context();

                    currentlog.Logout = DateTime.Now;
                    db.CrashLogs.Update(currentlog);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
