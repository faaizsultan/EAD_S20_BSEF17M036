using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assig2.BAL;
using UserData;
namespace Assignment2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            String applicationBAsePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);//creating Images Folder..
            System.IO.Directory.CreateDirectory(applicationBAsePath + @"\images\");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Console.WriteLine(DateTime.Now.ToShortTimeString());
            Console.WriteLine(DateTime.Now.ToLongDateString());
            Console.WriteLine(DateTime.Now.ToShortDateString());
            
            Application.Run(new mainScreen());
        }
    }
}
