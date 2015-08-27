using System;
using System.Windows.Forms;

namespace Money_Exchanger_Server_Side
{
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            //  ServerImplementation sim = new ServerImplementation();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //            Form1 f1 = new Form1();
            Application.Run(new Form1());
        }
    }
}