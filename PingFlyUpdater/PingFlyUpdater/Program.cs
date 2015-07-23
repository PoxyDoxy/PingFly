using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PingFlyUpdater
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        //static void Main()
        static void Main(string[] args)
        {
            Form1.tempholder = args;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
