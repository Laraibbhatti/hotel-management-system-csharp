using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_PROJECT_HOTEL_MANAGEMENT_SYSTEM
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
            Application.Run(new HOME_PAGE());
            // Application.Run(new ADMIN_FORM());
            // Application.Run(new ROOMS_FORM());
            // Application.Run(new CONTACT_FORM());
            //Application.Run(new Form10());

        }
    }
}
