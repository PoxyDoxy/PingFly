using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace PingFly
{
    public partial class Updater : Form
    {
        public Updater()
        {
            InitializeComponent();
        }

        private void Updater_Load(object sender, EventArgs e)
        {
            if (File.Exists("PingFlyUpdater.exe"))
            {
                File.Delete("PingFlyUpdater.exe");
            }

            if (File.Exists("update_pending_" + assemblyFilePath))
            {
                File.Delete("update_pending_" + assemblyFilePath);
                MessageBox.Show("Oh No, Looks like the Update Failed...");
            }
            updatecheck.RunWorkerAsync();
        }

        private static readonly string latestVersionUrl = "http://update.murbak.com.au/PingFly/version.html";
        private static readonly string latestVersionDownload = "http://update.murbak.com.au/PingFly/PingFly.exe";
        private static readonly string assemblyFilePath = System.AppDomain.CurrentDomain.FriendlyName;
        private static readonly Regex versionNumberRegex = new Regex(@"([0-9]+\.)*[0-9]+");

        public void CheckForUpdate()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate () { CheckForUpdate(); }));
            }
            else
            {
                Version localversion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                Version latestversion = new Version(GetLatestVersion());
                //Change < to == to set debugging mode
                if (localversion.CompareTo(latestversion) < 0)
                {
                    yesupdate.Visible = true;
                    noupdate.Visible = true;
                    updatetext.Visible = true;
                    updatelabel.Text = "Update Available!";
                    /*DialogResult dialogResult = MessageBox.Show("An update is available, would you like to update?", "Update available!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        updatelabel.Text = "Downloading Update";
                        WebClient downloader = new WebClient();
                        try
                        {
                            byte[] latestVersionBytes = downloader.DownloadData(latestVersionDownload);
                            string temporaryPath = "update_pending_" + assemblyFilePath;
                            System.IO.File.WriteAllBytes(temporaryPath, latestVersionBytes);
                            if (File.Exists(temporaryPath))
                            {
                                if (!File.Exists("PingFlyUpdater.exe"))
                                {
                                    byte[] exe = Properties.Resources.PingFlyUpdater;
                                    File.WriteAllBytes(Application.StartupPath + "\\PingFlyUpdater.exe", exe);
                                }

                                Process.Start(Application.StartupPath + "\\PingFlyUpdater.exe", System.AppDomain.CurrentDomain.FriendlyName);
                                Application.Exit();
                            }
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(Convert.ToString(e));
                            Application.Exit();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        this.Visible = false;
                        Form loadmainform = new Form1();
                        loadmainform.Show();
                    }*/
                }
                else
                {
                    this.Visible = false;
                    Form loadmainform = new Form1();
                    loadmainform.Show();
                }
            }
        }

        private static string GetLatestVersion()
        {
            Uri latestVersionUri = new Uri(latestVersionUrl);
            WebClient webClient = new WebClient();
            string receivedData = string.Empty;

            try
            {
                receivedData = webClient.DownloadString(latestVersionUrl).Trim();
            }
            catch (WebException)
            {
                MessageBox.Show("Oh No, Looks like either your Internet, or the update server is down.");
            }

            // Just in case the server returned something other than a valid version number. 
            return versionNumberRegex.IsMatch(receivedData)
                ? receivedData
                : null;
        }

        private void updatecheck_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForUpdate();
        }

        private void yesupdate_Click(object sender, EventArgs err)
        {
            updatelabel.Text = "Downloading Update";
            WebClient downloader = new WebClient();
            try
            {
                byte[] latestVersionBytes = downloader.DownloadData(latestVersionDownload);
                string temporaryPath = "update_pending_" + assemblyFilePath;
                System.IO.File.WriteAllBytes(temporaryPath, latestVersionBytes);
                if (File.Exists(temporaryPath))
                {
                    if (!File.Exists("PingFlyUpdater.exe"))
                    {
                        byte[] exe = Properties.Resources.PingFlyUpdater;
                        File.WriteAllBytes(Application.StartupPath + "\\PingFlyUpdater.exe", exe);
                    }

                    Process.Start(Application.StartupPath + "\\PingFlyUpdater.exe", System.AppDomain.CurrentDomain.FriendlyName);
                    Application.Exit();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error!!!!");
                MessageBox.Show(Convert.ToString(e));
                Application.Exit();
            }
        }

        private void noupdate_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form loadmainform = new Form1();
            loadmainform.Show();
        }
    }
}
