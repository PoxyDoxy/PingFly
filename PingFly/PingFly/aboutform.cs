using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Net;

namespace PingFly
{
    public partial class aboutform : Form
    {
        public aboutform()
        {
            InitializeComponent();
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            varholder.eggmode_status = false;
            varholder.easter_egg = 0;
            this.Close();
        }

        private void aboutform_Load(object sender, EventArgs e)
        {
            this.Size = new Size(429, 291);
            try
            {
                label2.Text = "v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            }
            catch
            {
                MessageBox.Show("This Error really Shouldn't happen, Did you Remove the Programs Version?");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Make Bigger and Fetch Stats
            if (this.Width == 429 & this.Height == 291)
            {
                button1.Text = "Loading...";
                button1.Enabled = false;
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        label6.Text = client.DownloadString("http://update.murbak.com.au/PingFly/backend/current-active.php?action=fetch");
                    }
                }
                catch
                {
                    // Either Internet is down, or Server is down.
                    label6.Text = "Statistics are Offline.";
                }

                try
                {
                    using (WebClient client = new WebClient())
                    {
                        label7.Text = client.DownloadString("http://update.murbak.com.au/PingFly/backend/total-active.php?action=fetch");
                    }
                }
                catch
                {
                    // Either Internet is down, or Server is down.
                    label7.Text = "Statistics are Offline.";
                }
                button1.Enabled = true;
                button1.Text = "Less Stats";
                this.Size = new Size(429, 464);
                
            }
            else // Make Smaller
            if (this.Width == 429 & this.Height == 464)
            {
                button1.Text = "More Stats";
                this.Size = new Size(429, 291);
            }
            
            // Increase Box Size
            // Decrease Box Size

        }

        public static class varholder 
        {
            public static int easter_egg;
            public static bool eggmode_status = false;
            public static string BACKUP1, BACKUP2, BACKUP3, BACKUP6;
            public static Point BACKUP4;
            public static Size BACKUP5;
            public static String image_url;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (varholder.easter_egg >= 5)
            {
                if (varholder.eggmode_status == true)
                {
                    // Easter Egg Time is Over
                    // Restore Values to Originals
                    label1.Text = varholder.BACKUP1;
                    label2.Text = varholder.BACKUP2;
                    label4.Text = varholder.BACKUP3;
                    label1.Location = varholder.BACKUP4;
                    label3.Text = varholder.BACKUP6;
                    this.BackgroundImage = null;
                    varholder.eggmode_status = false;
                    varholder.easter_egg = 0;
                }
                else
                {
                    // EASTER EGG TIME!!!
                    // Backup old Interface Before Changing
                    varholder.BACKUP1 = label1.Text;
                    varholder.BACKUP2 = label2.Text;
                    varholder.BACKUP3 = label4.Text;
                    varholder.BACKUP4 = label1.Location;
                    varholder.BACKUP6 = label3.Text;
                    try
                    {
                        using(WebClient client = new WebClient()) 
                        {
                            varholder.image_url = client.DownloadString("http://update.murbak.com.au/PingFly/backend/random-image.php");
                        }
                        Form imageboxform = new ImageViewer();
                        imageboxform.ShowDialog();
                    }
                    catch
                    {
                        // They Have No Internet, Or Remote Image is Down.
                    }
                    // Change Interface
                    varholder.eggmode_status = true;
                    label1.Text = "EASTER EGG MODE";
                    label1.Location = new Point(100, 9);
                    label2.Text = "v9.0.0.1";
                    label3.Text = "PingFly measures the latency of up to 6 memes, with features such as Memes, Meme Loss Counting and Location based Meme Server Lists.";
                    label4.Text = "Created by Meme Generator.";
                    varholder.easter_egg = 0;
                }
            }
            else
            {
                varholder.easter_egg = varholder.easter_egg + 1;
            }
        }
    }
}
