using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace PingFlyUpdater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string[] tempholder;

        private void Form1_Load(object sender, EventArgs e)
        {
            if (tempholder.Length == 1)
            {
                string oldversion = tempholder[0];
                string newversion = "update_pending_" + tempholder[0];

                if (File.Exists(newversion))
                {
                    if (File.Exists(oldversion))
                    {
                        File.Delete(oldversion);
                    }

                    File.Move(newversion, oldversion);

                    if (File.Exists(oldversion))
                    {
                        Process.Start(oldversion);
                    }

                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Well, This is Awkward... Did somthing delete the Update File?");
                    Application.Exit();
                }
            }

            if (tempholder.Length > 1) 
            {
                MessageBox.Show("Too Many Arguments!");
                Application.Exit();
            }

            if (tempholder == null || tempholder.Length == 0)
            {
                MessageBox.Show("Don't run this without the correct Arguments.\nPlease let the updater finish.");
                Application.Exit();
            }
            
        }

    }
}
