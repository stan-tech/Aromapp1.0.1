using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aromapp
{
    internal static class Program
    {
        static CleanTrashService _maintenance;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _maintenance = new CleanTrashService(DBHelper.connectionString, Properties.Settings.Default.RetentionPeriod);
            _maintenance.Start(new string[] { });

            Application.Run(new Home(_maintenance));

            //using (DBHelper helper = new DBHelper())
            //{

            //    if (helper.CheckForConnectedUsers())
            //    {
            //        Application.Run(new Home());

            //    }
            //    else if (!helper.CheckForStoreInfo())
            //    {

            //        Launcher launcher = new Launcher();
            //        Application.Run(launcher);


            //    }
            //    else
            //    {
            //        List<User> users = helper.GetUsers();

            //        if (users.Count == 0)
            //        {
            //            Application.Run(new AddUser(true));

            //        }
            //        else
            //        {
            //            Application.Run(new SignIn());

            //        }

            //    }
            //}

            _maintenance.Dispose();

        }


    }


    
}
