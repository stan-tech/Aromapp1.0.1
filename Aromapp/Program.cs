using System;
using System.Collections.Generic;
using System.IO;
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
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                using (DBHelper helper = new DBHelper())
                {

                    if (helper.CheckForConnectedUsers())
                    {
                        Application.Run(new Home());

                    }
                    else if (!helper.CheckForStoreInfo())
                    {

                        Launcher launcher = new Launcher();
                        Application.Run(launcher);


                    }
                    else
                    {
                        List<User> users = helper.GetUsers();

                        if (users.Count == 0)
                        {
                            Application.Run(new AddUser(true));

                        }
                        else
                        {
                            Application.Run(new SignIn());

                        }

                    }
                }

            }
            catch (Exception ex)
            {
                string logPath = Path.Combine(AppContext.BaseDirectory, "error_log.txt");
                File.AppendAllText(logPath,
                        "----------------------------------------------------" + Environment.NewLine +
                        "Date: " + DateTime.Now + Environment.NewLine +
                        "Message: " + ex.Message + Environment.NewLine +
                        "StackTrace: " + ex.StackTrace + Environment.NewLine +
                        "----------------------------------------------------" + Environment.NewLine
                );

            }

        }


    }


    
}
