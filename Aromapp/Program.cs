using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aromapp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD

            using (DBHelper helper = new DBHelper())
            {
=======
            Application.Run(new Home());
>>>>>>> 5d140cb56cb55814e30098b42a3b5e5fe92a1409

            /*
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
                        }*/

<<<<<<< HEAD
                }
            }

=======
>>>>>>> 5d140cb56cb55814e30098b42a3b5e5fe92a1409


        }


    }
}
