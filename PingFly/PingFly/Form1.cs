using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.NetworkInformation;

namespace PingFly
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static class Variables
        {
            public static string server1, server2, server3, server4, server5, server6;
            public static string serveramount;
            public static string error0, error1 = "Error: Server Address Is Blank.", error2 = "Error: '/' is not allowed.", error3 = "Error: ':' is not allowed.", error4 = "Error: Both ':' and '/' are not allowed.";
            public static string dots1, dots2, dots3, dots4, dots5, dots6;
            public static long minping = -1, maxping = -1, averageping = -1, averagetick = 0, averagetotal = 0, lostpackets = 0, totalpackets = 0;
            public static long server1live, server2live, server3live, server4live, server5live, server6live, serverliveaverage;
            public static bool workerisfree;
            public static double packetloss = 0;
            public static int sleeptime = 1000;
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startbutton_Click(object sender, EventArgs e)
        {
            // Start Pinger
            Variables.serveramount = Convert.ToString(serveramount.SelectedItem);
            if (startbutton.Text == "Start")
            {

                startbutton.Text = "Stop";
                serveramount.Enabled = false;
                resetbutton.Enabled = false;
                Variables.workerisfree = false;
                server1address.Enabled = false;
                server2address.Enabled = false;
                server3address.Enabled = false;
                server4address.Enabled = false;
                server5address.Enabled = false;
                server6address.Enabled = false;

                perthservers.Enabled = false;
                try
                {
                    PingAndPing.RunWorkerAsync();
                }
                catch
                {
                    startbutton.Text = "Start";
                    serveramount.Enabled = true;
                    resetbutton.Enabled = true;
                    Variables.workerisfree = true;

                    // ServerAmount = 1
                    if (serveramount.SelectedItem == "1")
                    {
                        server1address.Enabled = true;
                        server2address.Enabled = false;
                        server3address.Enabled = false;
                        server4address.Enabled = false;
                        server5address.Enabled = false;
                        server6address.Enabled = false;
                    }

                    // ServerAmount = 2
                    if (serveramount.SelectedItem == "2")
                    {
                        server1address.Enabled = true;
                        server2address.Enabled = true;
                        server3address.Enabled = false;
                        server4address.Enabled = false;
                        server5address.Enabled = false;
                        server6address.Enabled = false;
                    }

                    // ServerAmount = 3
                    if (serveramount.SelectedItem == "3")
                    {
                        server1address.Enabled = true;
                        server2address.Enabled = true;
                        server3address.Enabled = true;
                        server4address.Enabled = false;
                        server5address.Enabled = false;
                        server6address.Enabled = false;
                    }

                    // ServerAmount = 4
                    if (serveramount.SelectedItem == "4")
                    {
                        server1address.Enabled = true;
                        server2address.Enabled = true;
                        server3address.Enabled = true;
                        server4address.Enabled = true;
                        server5address.Enabled = false;
                        server6address.Enabled = false;
                    }

                    // ServerAmount = 5
                    if (serveramount.SelectedItem == "5")
                    {
                        server1address.Enabled = true;
                        server2address.Enabled = true;
                        server3address.Enabled = true;
                        server4address.Enabled = true;
                        server5address.Enabled = true;
                        server6address.Enabled = false;
                    }

                    // ServerAmount = 6
                    if (serveramount.SelectedItem == "6")
                    {
                        server1address.Enabled = true;
                        server2address.Enabled = true;
                        server3address.Enabled = true;
                        server4address.Enabled = true;
                        server5address.Enabled = true;
                        server6address.Enabled = true;
                    }
                }

            }
            else
            {
                startbutton.Enabled = false;

                PingAndPing.CancelAsync();
                while (PingAndPing.IsBusy == false)
                {
                    Thread.Sleep(100);
                }

                startbutton.Text = "Start";
                serveramount.Enabled = true;
                resetbutton.Enabled = true;
                Variables.workerisfree = true;

                perthservers.Enabled = true;

                dots1.Text = "";
                dots2.Text = "";
                dots3.Text = "";
                dots4.Text = "";
                dots5.Text = "";
                dots6.Text = "";

                Variables.dots1 = "";
                Variables.dots2 = "";
                Variables.dots3 = "";
                Variables.dots4 = "";
                Variables.dots5 = "";
                Variables.dots6 = "";

                Variables.lostpackets = 0;

                label8.Text = "(Status)";
                label9.Text = "(Status)";
                label10.Text = "(Status)";
                label11.Text = "(Status)";
                label12.Text = "(Status)";
                label13.Text = "(Status)";

                /*server1result.Text = "";
                server2result.Text = "";
                server3result.Text = "";
                server4result.Text = "";
                server5result.Text = "";
                server6result.Text = "";*/

                this.server1result.ForeColor = Color.Black;
                this.server2result.ForeColor = Color.Black;
                this.server3result.ForeColor = Color.Black;
                this.server4result.ForeColor = Color.Black;
                this.server5result.ForeColor = Color.Black;
                this.server6result.ForeColor = Color.Black;

                // ServerAmount = 1
                if (serveramount.SelectedItem == "1")
                {
                    server1address.Enabled = true;
                    server2address.Enabled = false;
                    server3address.Enabled = false;
                    server4address.Enabled = false;
                    server5address.Enabled = false;
                    server6address.Enabled = false;
                }

                // ServerAmount = 2
                if (serveramount.SelectedItem == "2")
                {
                    server1address.Enabled = true;
                    server2address.Enabled = true;
                    server3address.Enabled = false;
                    server4address.Enabled = false;
                    server5address.Enabled = false;
                    server6address.Enabled = false;
                }

                // ServerAmount = 3
                if (serveramount.SelectedItem == "3")
                {
                    server1address.Enabled = true;
                    server2address.Enabled = true;
                    server3address.Enabled = true;
                    server4address.Enabled = false;
                    server5address.Enabled = false;
                    server6address.Enabled = false;
                }

                // ServerAmount = 4
                if (serveramount.SelectedItem == "4")
                {
                    server1address.Enabled = true;
                    server2address.Enabled = true;
                    server3address.Enabled = true;
                    server4address.Enabled = true;
                    server5address.Enabled = false;
                    server6address.Enabled = false;
                }

                // ServerAmount = 5
                if (serveramount.SelectedItem == "5")
                {
                    server1address.Enabled = true;
                    server2address.Enabled = true;
                    server3address.Enabled = true;
                    server4address.Enabled = true;
                    server5address.Enabled = true;
                    server6address.Enabled = false;
                }

                // ServerAmount = 6
                if (serveramount.SelectedItem == "6")
                {
                    server1address.Enabled = true;
                    server2address.Enabled = true;
                    server3address.Enabled = true;
                    server4address.Enabled = true;
                    server5address.Enabled = true;
                    server6address.Enabled = true;
                }
                startbutton.Enabled = true;
            }
        }

        private void PingAndPing_DoWork(object sender, DoWorkEventArgs e)
        {
            // Set Variables
            Variables.server1 = server1address.Text;
            Variables.server2 = server2address.Text;
            Variables.server3 = server3address.Text;
            Variables.server4 = server4address.Text;
            Variables.server5 = server5address.Text;
            Variables.server6 = server6address.Text;

            // Run Pinger

            // 1 Server Ping
            if (Variables.serveramount == "1")
            {
                checkurl(Variables.server1);
                if (PingAndPing.CancellationPending == true)
                {
                    Variables.workerisfree = true;
                    e.Cancel = true;
                    return;
                }
            }

            // 2 Server Ping
            if (Variables.serveramount == "2")
            {
                checkurl(Variables.server1);
                checkurl(Variables.server2);
                if (PingAndPing.CancellationPending == true)
                {
                    Variables.workerisfree = true;
                    e.Cancel = true;
                    return;
                }
            }

            // 3 Server Ping
            if (Variables.serveramount == "3")
            {
                checkurl(Variables.server1);
                checkurl(Variables.server2);
                checkurl(Variables.server3);
                if (PingAndPing.CancellationPending == true)
                {
                    Variables.workerisfree = true;
                    e.Cancel = true;
                    return;
                }
            }

            // 4 Server Ping
            if (Variables.serveramount == "4")
            {
                checkurl(Variables.server1);
                checkurl(Variables.server2);
                checkurl(Variables.server3);
                checkurl(Variables.server4);
                if (PingAndPing.CancellationPending == true)
                {
                    Variables.workerisfree = true;
                    e.Cancel = true;
                    return;
                }
            }

            // 5 Server Ping
            if (Variables.serveramount == "5")
            {
                checkurl(Variables.server1);
                checkurl(Variables.server2);
                checkurl(Variables.server3);
                checkurl(Variables.server4);
                checkurl(Variables.server5);
                if (PingAndPing.CancellationPending == true)
                {
                    Variables.workerisfree = true;
                    e.Cancel = true;
                    return;
                }
            }

            // 6 Server Ping
            if (Variables.serveramount == "6")
            {
                checkurl(Variables.server1);
                checkurl(Variables.server2);
                checkurl(Variables.server3);
                checkurl(Variables.server4);
                checkurl(Variables.server5);
                checkurl(Variables.server6);
                if (PingAndPing.CancellationPending == true)
                {
                    Variables.workerisfree = true;
                    e.Cancel = true;
                    return;
                }
            }

            while (true)
            {
                // Run Ping
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();

                // Use the default Ttl value which is 128, 
                // but change the fragmentation behavior.
                options.DontFragment = true;

                // Create a buffer of 32 bytes of data to be transmitted. 
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 3000;

                try
                {
                    // If 1 Server
                    if (Convert.ToDecimal(Variables.serveramount) == 1)
                    {
                        PingReply reply1 = pingSender.Send(Variables.server1, timeout, buffer, options);
                        if (reply1.Status == IPStatus.TimedOut) { updatepacketloss(1); }
                        if (reply1.Status == IPStatus.Success)
                        {
                            updateserver(reply1.RoundtripTime, 1);
                        }

                        updateliveaverage();
                        Thread.Sleep(Variables.sleeptime);
                    }

                    // If 2 Server
                    if (Convert.ToDecimal(Variables.serveramount) == 2)
                    {
                        PingReply reply1 = pingSender.Send(Variables.server1, timeout, buffer, options);
                        PingReply reply2 = pingSender.Send(Variables.server2, timeout, buffer, options);
                        if (reply1.Status == IPStatus.TimedOut) { updatepacketloss(1); }
                        if (reply1.Status == IPStatus.Success)
                        {
                            updateserver(reply1.RoundtripTime, 1);
                        }

                        if (reply2.Status == IPStatus.TimedOut) { updatepacketloss(2); }
                        if (reply2.Status == IPStatus.Success)
                        {
                            updateserver(reply2.RoundtripTime, 2);
                        }

                        updateliveaverage();
                        Thread.Sleep(Variables.sleeptime);
                    }
                    // If 3 Server
                    if (Convert.ToDecimal(Variables.serveramount) == 3)
                    {
                        PingReply reply1 = pingSender.Send(Variables.server1, timeout, buffer, options);
                        PingReply reply2 = pingSender.Send(Variables.server2, timeout, buffer, options);
                        PingReply reply3 = pingSender.Send(Variables.server3, timeout, buffer, options);
                        if (reply1.Status == IPStatus.TimedOut) { updatepacketloss(1); }
                        if (reply1.Status == IPStatus.Success)
                        {
                            updateserver(reply1.RoundtripTime, 1);
                        }

                        if (reply2.Status == IPStatus.TimedOut) { updatepacketloss(2); }
                        if (reply2.Status == IPStatus.Success)
                        {
                            updateserver(reply2.RoundtripTime, 2);
                        }

                        if (reply3.Status == IPStatus.TimedOut) { updatepacketloss(3); }
                        if (reply3.Status == IPStatus.Success)
                        {
                            updateserver(reply3.RoundtripTime, 3);
                        }

                        updateliveaverage();
                        Thread.Sleep(Variables.sleeptime);
                    }

                    // If 4 Server
                    if (Convert.ToDecimal(Variables.serveramount) == 4)
                    {
                        PingReply reply1 = pingSender.Send(Variables.server1, timeout, buffer, options);
                        PingReply reply2 = pingSender.Send(Variables.server2, timeout, buffer, options);
                        PingReply reply3 = pingSender.Send(Variables.server3, timeout, buffer, options);
                        PingReply reply4 = pingSender.Send(Variables.server4, timeout, buffer, options);
                        if (reply1.Status == IPStatus.TimedOut) { updatepacketloss(1); }
                        if (reply1.Status == IPStatus.Success)
                        {
                            updateserver(reply1.RoundtripTime, 1);
                        }

                        if (reply2.Status == IPStatus.TimedOut) { updatepacketloss(2); }
                        if (reply2.Status == IPStatus.Success)
                        {
                            updateserver(reply2.RoundtripTime, 2);
                        }

                        if (reply3.Status == IPStatus.TimedOut) { updatepacketloss(3); }
                        if (reply3.Status == IPStatus.Success)
                        {
                            updateserver(reply3.RoundtripTime, 3);
                        }

                        if (reply4.Status == IPStatus.TimedOut) { updatepacketloss(4); }
                        if (reply4.Status == IPStatus.Success)
                        {
                            updateserver(reply4.RoundtripTime, 4);
                        }

                        updateliveaverage();
                        Thread.Sleep(Variables.sleeptime);
                    }

                    // If 5 Server
                    if (Convert.ToDecimal(Variables.serveramount) == 5)
                    {
                        PingReply reply1 = pingSender.Send(Variables.server1, timeout, buffer, options);
                        PingReply reply2 = pingSender.Send(Variables.server2, timeout, buffer, options);
                        PingReply reply3 = pingSender.Send(Variables.server3, timeout, buffer, options);
                        PingReply reply4 = pingSender.Send(Variables.server4, timeout, buffer, options);
                        PingReply reply5 = pingSender.Send(Variables.server5, timeout, buffer, options);
                        if (reply1.Status == IPStatus.TimedOut) { updatepacketloss(1); }
                        if (reply1.Status == IPStatus.Success)
                        {
                            updateserver(reply1.RoundtripTime, 1);
                        }

                        if (reply2.Status == IPStatus.TimedOut) { updatepacketloss(2); }
                        if (reply2.Status == IPStatus.Success)
                        {
                            updateserver(reply2.RoundtripTime, 2);
                        }

                        if (reply3.Status == IPStatus.TimedOut) { updatepacketloss(3); }
                        if (reply3.Status == IPStatus.Success)
                        {
                            updateserver(reply3.RoundtripTime, 3);
                        }

                        if (reply4.Status == IPStatus.TimedOut) { updatepacketloss(4); }
                        if (reply4.Status == IPStatus.Success)
                        {
                            updateserver(reply4.RoundtripTime, 4);
                        }

                        if (reply5.Status == IPStatus.TimedOut) { updatepacketloss(5); }
                        if (reply5.Status == IPStatus.Success)
                        {
                            updateserver(reply5.RoundtripTime, 5);
                        }

                        updateliveaverage();
                        Thread.Sleep(Variables.sleeptime);
                    }

                    // If 6 Server
                    if (Convert.ToDecimal(Variables.serveramount) == 6)
                    {
                        PingReply reply1 = pingSender.Send(Variables.server1, timeout, buffer, options);
                        PingReply reply2 = pingSender.Send(Variables.server2, timeout, buffer, options);
                        PingReply reply3 = pingSender.Send(Variables.server3, timeout, buffer, options);
                        PingReply reply4 = pingSender.Send(Variables.server4, timeout, buffer, options);
                        PingReply reply5 = pingSender.Send(Variables.server5, timeout, buffer, options);
                        PingReply reply6 = pingSender.Send(Variables.server6, timeout, buffer, options);
                        if (reply1.Status == IPStatus.TimedOut) { updatepacketloss(1); }
                        if (reply1.Status == IPStatus.Success)
                        {
                            updateserver(reply1.RoundtripTime, 1);
                        }

                        if (reply2.Status == IPStatus.TimedOut) { updatepacketloss(2); }
                        if (reply2.Status == IPStatus.Success)
                        {
                            updateserver(reply2.RoundtripTime, 2);
                        }

                        if (reply3.Status == IPStatus.TimedOut) { updatepacketloss(3); }
                        if (reply3.Status == IPStatus.Success)
                        {
                            updateserver(reply3.RoundtripTime, 3);
                        }

                        if (reply4.Status == IPStatus.TimedOut) { updatepacketloss(4); }
                        if (reply4.Status == IPStatus.Success)
                        {
                            updateserver(reply4.RoundtripTime, 4);
                        }

                        if (reply5.Status == IPStatus.TimedOut) { updatepacketloss(5); }
                        if (reply5.Status == IPStatus.Success)
                        {
                            updateserver(reply5.RoundtripTime, 5);
                        }

                        if (reply6.Status == IPStatus.TimedOut) { updatepacketloss(6); }
                        if (reply6.Status == IPStatus.Success)
                        {
                            updateserver(reply6.RoundtripTime, 6);
                        }

                        updateliveaverage();
                        Thread.Sleep(Variables.sleeptime);
                    }

                    if (PingAndPing.CancellationPending == true)
                    {
                        Variables.workerisfree = true;
                        e.Cancel = true;
                        return;
                    }
                }
                catch (Exception exptn)
                {
                    string exceptionholder;
                    exceptionholder = Convert.ToString(exptn);
                    if (exceptionholder.Contains("No such host is known")) { MessageBox.Show("Error - Either DNS could not be resolved or the domain name does not exist.\nPlease check spelling or run 'IPCONFIG /FLUSHDNS'.", "Error - Domain Name Invalid"); }
                    else { MessageBox.Show(exptn.Message, "Error"); }
                    resetstopbutton();
                    e.Cancel = true;
                    return;
                }
            }
        }

        public void updateliveaverage()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate () { updateliveaverage(); }));
            }
            else
            {
                long livetotal = 0;
                int divamount = 0;
                if (Variables.server1live != -1) { livetotal = livetotal + Variables.server1live; divamount++; }
                if (Variables.server2live != -1) { livetotal = livetotal + Variables.server2live; divamount++; }
                if (Variables.server3live != -1) { livetotal = livetotal + Variables.server3live; divamount++; }
                if (Variables.server4live != -1) { livetotal = livetotal + Variables.server4live; divamount++; }
                if (Variables.server5live != -1) { livetotal = livetotal + Variables.server5live; divamount++; }
                if (Variables.server6live != -1) { livetotal = livetotal + Variables.server6live; divamount++; }
                if (divamount != 0 && livetotal != 0)
                {
                    Variables.serverliveaverage = livetotal / divamount;
                    liveaverage.Text = Convert.ToString(Variables.serverliveaverage) + "ms";
                }

                Variables.server1live = -1;
                Variables.server2live = -1;
                Variables.server3live = -1;
                Variables.server4live = -1;
                Variables.server5live = -1;
                Variables.server6live = -1;
                Variables.serverliveaverage = -1;
            }
        }

        public void updatepacketloss(int servernumber)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate () { updatepacketloss(servernumber); }));
            }
            else
            {
                if (Convert.ToDecimal(servernumber) == 1) { this.label8.Text = "Offline"; }
                if (Convert.ToDecimal(servernumber) == 2) { this.label9.Text = "Offline"; }
                if (Convert.ToDecimal(servernumber) == 3) { this.label10.Text = "Offline"; }
                if (Convert.ToDecimal(servernumber) == 4) { this.label11.Text = "Offline"; }
                if (Convert.ToDecimal(servernumber) == 5) { this.label12.Text = "Offline"; }
                if (Convert.ToDecimal(servernumber) == 6) { this.label13.Text = "Offline"; }

                if (Convert.ToDecimal(servernumber) == 1) { if (Variables.dots1 == ".....") { Variables.dots1 = "."; } else { Variables.dots1 = Variables.dots1 + "."; } }
                if (Convert.ToDecimal(servernumber) == 2) { if (Variables.dots2 == ".....") { Variables.dots2 = "."; } else { Variables.dots2 = Variables.dots2 + "."; } }
                if (Convert.ToDecimal(servernumber) == 3) { if (Variables.dots3 == ".....") { Variables.dots3 = "."; } else { Variables.dots3 = Variables.dots3 + "."; } }
                if (Convert.ToDecimal(servernumber) == 4) { if (Variables.dots4 == ".....") { Variables.dots4 = "."; } else { Variables.dots4 = Variables.dots4 + "."; } }
                if (Convert.ToDecimal(servernumber) == 5) { if (Variables.dots5 == ".....") { Variables.dots5 = "."; } else { Variables.dots5 = Variables.dots5 + "."; } }
                if (Convert.ToDecimal(servernumber) == 6) { if (Variables.dots6 == ".....") { Variables.dots6 = "."; } else { Variables.dots6 = Variables.dots6 + "."; } }

                if ((Convert.ToDecimal(servernumber) == 1)) { this.server1result.Text = "Offline"; this.dots1.Text = Variables.dots1; }
                if ((Convert.ToDecimal(servernumber) == 2)) { this.server2result.Text = "Offline"; this.dots2.Text = Variables.dots2; }
                if ((Convert.ToDecimal(servernumber) == 3)) { this.server3result.Text = "Offline"; this.dots3.Text = Variables.dots3; }
                if ((Convert.ToDecimal(servernumber) == 4)) { this.server4result.Text = "Offline"; this.dots4.Text = Variables.dots4; }
                if ((Convert.ToDecimal(servernumber) == 5)) { this.server5result.Text = "Offline"; this.dots5.Text = Variables.dots5; }
                if ((Convert.ToDecimal(servernumber) == 6)) { this.server6result.Text = "Offline"; this.dots6.Text = Variables.dots6; }

                if (Convert.ToDecimal(servernumber) == 1) { this.server1result.ForeColor = Color.Red; }
                if (Convert.ToDecimal(servernumber) == 2) { this.server2result.ForeColor = Color.Red; }
                if (Convert.ToDecimal(servernumber) == 3) { this.server3result.ForeColor = Color.Red; }
                if (Convert.ToDecimal(servernumber) == 4) { this.server4result.ForeColor = Color.Red; }
                if (Convert.ToDecimal(servernumber) == 5) { this.server5result.ForeColor = Color.Red; }
                if (Convert.ToDecimal(servernumber) == 6) { this.server6result.ForeColor = Color.Red; }

                Variables.lostpackets++;
                Variables.totalpackets++;
                packetloss.Text = Variables.lostpackets + "/" + Variables.totalpackets;
            }
        }

        public void updateserver(long latency, int servernumber)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate () { updateserver(latency, servernumber); }));
            }
            else
            {
                if ((Convert.ToDecimal(servernumber) == 1) && (this.label8.Text != "Online")) { this.label8.Text = "Online"; }
                if ((Convert.ToDecimal(servernumber) == 2) && (this.label9.Text != "Online")) { this.label9.Text = "Online"; }
                if ((Convert.ToDecimal(servernumber) == 3) && (this.label10.Text != "Online")) { this.label10.Text = "Online"; }
                if ((Convert.ToDecimal(servernumber) == 4) && (this.label11.Text != "Online")) { this.label11.Text = "Online"; }
                if ((Convert.ToDecimal(servernumber) == 5) && (this.label12.Text != "Online")) { this.label12.Text = "Online"; }
                if ((Convert.ToDecimal(servernumber) == 6) && (this.label13.Text != "Online")) { this.label13.Text = "Online"; }

                if (Convert.ToDecimal(servernumber) == 1) { if (Variables.dots1 == ".....") { Variables.dots1 = "."; } else { Variables.dots1 = Variables.dots1 + "."; } }
                if (Convert.ToDecimal(servernumber) == 2) { if (Variables.dots2 == ".....") { Variables.dots2 = "."; } else { Variables.dots2 = Variables.dots2 + "."; } }
                if (Convert.ToDecimal(servernumber) == 3) { if (Variables.dots3 == ".....") { Variables.dots3 = "."; } else { Variables.dots3 = Variables.dots3 + "."; } }
                if (Convert.ToDecimal(servernumber) == 4) { if (Variables.dots4 == ".....") { Variables.dots4 = "."; } else { Variables.dots4 = Variables.dots4 + "."; } }
                if (Convert.ToDecimal(servernumber) == 5) { if (Variables.dots5 == ".....") { Variables.dots5 = "."; } else { Variables.dots5 = Variables.dots5 + "."; } }
                if (Convert.ToDecimal(servernumber) == 6) { if (Variables.dots6 == ".....") { Variables.dots6 = "."; } else { Variables.dots6 = Variables.dots6 + "."; } }

                if ((Convert.ToDecimal(servernumber) == 1)) { this.server1result.Text = latency + "ms"; this.dots1.Text = Variables.dots1; }
                if ((Convert.ToDecimal(servernumber) == 2)) { this.server2result.Text = latency + "ms"; this.dots2.Text = Variables.dots2; }
                if ((Convert.ToDecimal(servernumber) == 3)) { this.server3result.Text = latency + "ms"; this.dots3.Text = Variables.dots3; }
                if ((Convert.ToDecimal(servernumber) == 4)) { this.server4result.Text = latency + "ms"; this.dots4.Text = Variables.dots4; }
                if ((Convert.ToDecimal(servernumber) == 5)) { this.server5result.Text = latency + "ms"; this.dots5.Text = Variables.dots5; }
                if ((Convert.ToDecimal(servernumber) == 6)) { this.server6result.Text = latency + "ms"; this.dots6.Text = Variables.dots6; }

                if ((Convert.ToDecimal(servernumber) == 1) && (this.server1result.ForeColor == Color.Red)) { this.server1result.ForeColor = Color.Black; }
                if ((Convert.ToDecimal(servernumber) == 2) && (this.server2result.ForeColor == Color.Red)) { this.server2result.ForeColor = Color.Black; }
                if ((Convert.ToDecimal(servernumber) == 3) && (this.server3result.ForeColor == Color.Red)) { this.server3result.ForeColor = Color.Black; }
                if ((Convert.ToDecimal(servernumber) == 4) && (this.server4result.ForeColor == Color.Red)) { this.server4result.ForeColor = Color.Black; }
                if ((Convert.ToDecimal(servernumber) == 5) && (this.server5result.ForeColor == Color.Red)) { this.server5result.ForeColor = Color.Black; }
                if ((Convert.ToDecimal(servernumber) == 6) && (this.server6result.ForeColor == Color.Red)) { this.server6result.ForeColor = Color.Black; }

                if (Variables.minping == -1)
                {
                    Variables.minping = latency;
                    this.minping.Text = Convert.ToString(latency) + "ms" + " (ser" + servernumber + ")";
                }

                if (Variables.maxping == -1)
                {
                    Variables.maxping = latency;
                    this.maxping.Text = Convert.ToString(latency) + "ms" + " (ser" + servernumber + ")";
                }

                if (Variables.averageping == -1)
                {
                    Variables.averageping = latency;
                }

                if (latency > Convert.ToInt32(Variables.maxping))
                {
                    Variables.maxping = latency;
                    this.maxping.Text = Convert.ToString(Variables.maxping) + "ms" + " (ser" + servernumber + ")";
                }

                if (latency < Convert.ToInt32(Variables.minping))
                {
                    Variables.minping = latency;
                    this.minping.Text = Convert.ToString(Variables.minping) + "ms" + " (ser" + servernumber + ")";
                }

                Variables.averagetick++;
                Variables.totalpackets++;

                packetloss.Text = Variables.lostpackets + "/" + Variables.totalpackets;


                Variables.averagetotal = Variables.averagetotal + latency;
                Variables.averageping = Variables.averagetotal / Variables.averagetick;
                this.averageping.Text = Convert.ToString(Variables.averageping) + "ms";

                if (servernumber == 1) { Variables.server1live = latency; }
                if (servernumber == 2) { Variables.server2live = latency; }
                if (servernumber == 3) { Variables.server3live = latency; }
                if (servernumber == 4) { Variables.server4live = latency; }
                if (servernumber == 5) { Variables.server5live = latency; }
                if (servernumber == 6) { Variables.server6live = latency; }

            }
        }

        public void resetstopbutton()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate () { resetstopbutton(); }));
            }
            else
            {
                dots1.Text = "";
                dots2.Text = "";
                dots3.Text = "";
                dots4.Text = "";
                dots5.Text = "";
                dots6.Text = "";

                this.server1result.ForeColor = Color.Black;
                this.server2result.ForeColor = Color.Black;
                this.server3result.ForeColor = Color.Black;
                this.server4result.ForeColor = Color.Black;
                this.server5result.ForeColor = Color.Black;
                this.server6result.ForeColor = Color.Black;

                perthservers.Enabled = true;

                Variables.minping = -1;
                Variables.maxping = -1;
                Variables.averageping = -1;
                Variables.averagetick = 0;
                Variables.averagetotal = 0;
                Variables.packetloss = 0;
                Variables.totalpackets = 0;

                Variables.dots1 = "";
                Variables.dots2 = "";
                Variables.dots3 = "";
                Variables.dots4 = "";
                Variables.dots5 = "";
                Variables.dots6 = "";

                averageping.Text = "...";
                minping.Text = "...";
                maxping.Text = "...";
                packetloss.Text = "...";
                liveaverage.Text = "...";

                label8.Text = "(Status)";
                label9.Text = "(Status)";
                label10.Text = "(Status)";
                label11.Text = "(Status)";
                label12.Text = "(Status)";
                label13.Text = "(Status)";

                // ServerAmount = 1
                if (serveramount.SelectedItem == "1")
                {
                    server1result.Text = "Idle";
                    server2result.Text = "Disabled";
                    server3result.Text = "Disabled";
                    server4result.Text = "Disabled";
                    server5result.Text = "Disabled";
                    server6result.Text = "Disabled";
                }

                // ServerAmount = 2
                if (serveramount.SelectedItem == "2")
                {
                    server1result.Text = "Idle";
                    server2result.Text = "Idle";
                    server3result.Text = "Disabled";
                    server4result.Text = "Disabled";
                    server5result.Text = "Disabled";
                    server6result.Text = "Disabled";
                }

                // ServerAmount = 3
                if (serveramount.SelectedItem == "3")
                {
                    server1result.Text = "Idle";
                    server2result.Text = "Idle";
                    server3result.Text = "Idle";
                    server4result.Text = "Disabled";
                    server5result.Text = "Disabled";
                    server6result.Text = "Disabled";
                }

                // ServerAmount = 4
                if (serveramount.SelectedItem == "4")
                {
                    server1result.Text = "Idle";
                    server2result.Text = "Idle";
                    server3result.Text = "Idle";
                    server4result.Text = "Idle";
                    server5result.Text = "Disabled";
                    server6result.Text = "Disabled";
                }

                // ServerAmount = 5
                if (serveramount.SelectedItem == "5")
                {
                    server1result.Text = "Idle";
                    server2result.Text = "Idle";
                    server3result.Text = "Idle";
                    server4result.Text = "Idle";
                    server5result.Text = "Idle";
                    server6result.Text = "Disabled";
                }

                // ServerAmount = 6
                if (serveramount.SelectedItem == "6")
                {
                    server1result.Text = "Idle";
                    server2result.Text = "Idle";
                    server3result.Text = "Idle";
                    server4result.Text = "Idle";
                    server5result.Text = "Idle";
                    server6result.Text = "Idle";
                }


                // ServerAmount = 1
                if (serveramount.SelectedItem == "1")
                {
                    server1address.Enabled = true;
                    server2address.Enabled = false;
                    server3address.Enabled = false;
                    server4address.Enabled = false;
                    server5address.Enabled = false;
                    server6address.Enabled = false;
                }

                // ServerAmount = 2
                if (serveramount.SelectedItem == "2")
                {
                    server1address.Enabled = true;
                    server2address.Enabled = true;
                    server3address.Enabled = false;
                    server4address.Enabled = false;
                    server5address.Enabled = false;
                    server6address.Enabled = false;
                }

                // ServerAmount = 3
                if (serveramount.SelectedItem == "3")
                {
                    server1address.Enabled = true;
                    server2address.Enabled = true;
                    server3address.Enabled = true;
                    server4address.Enabled = false;
                    server5address.Enabled = false;
                    server6address.Enabled = false;
                }

                // ServerAmount = 4
                if (serveramount.SelectedItem == "4")
                {
                    server1address.Enabled = true;
                    server2address.Enabled = true;
                    server3address.Enabled = true;
                    server4address.Enabled = true;
                    server5address.Enabled = false;
                    server6address.Enabled = false;
                }

                // ServerAmount = 5
                if (serveramount.SelectedItem == "5")
                {
                    server1address.Enabled = true;
                    server2address.Enabled = true;
                    server3address.Enabled = true;
                    server4address.Enabled = true;
                    server5address.Enabled = true;
                    server6address.Enabled = false;
                }

                // ServerAmount = 6
                if (serveramount.SelectedItem == "6")
                {
                    server1address.Enabled = true;
                    server2address.Enabled = true;
                    server3address.Enabled = true;
                    server4address.Enabled = true;
                    server5address.Enabled = true;
                    server6address.Enabled = true;
                }

                startbutton.Text = "Start";
                serveramount.Enabled = true;
                resetbutton.Enabled = true;
            }
        }

        public void checkurl(string url)
        {
            if (url == "")
            {
                MessageBox.Show(Variables.error1);
                PingAndPing.CancelAsync();
                resetstopbutton();
                return;
            }

            if (url.Contains(":") && url.Contains("/"))
            {
                MessageBox.Show(Variables.error4);
                PingAndPing.CancelAsync();
                resetstopbutton();
                return;
            }

            if (url.Contains("/"))
            {
                MessageBox.Show(Variables.error2);
                PingAndPing.CancelAsync();
                resetstopbutton();
                return;
            }

            if (url.Contains(":"))
            {
                MessageBox.Show(Variables.error3);
                PingAndPing.CancelAsync();
                resetstopbutton();
                return;
            }
            return;
        }

        private void resetbutton_Click(object sender, EventArgs e)
        {
            resetstopbutton();
            serveramount.SelectedItem = "1";
            server1address.Text = "";
            server2address.Text = "";
            server3address.Text = "";
            server4address.Text = "";
            server5address.Text = "";
            server6address.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Start Program
            dots1.Text = "";
            dots2.Text = "";
            dots3.Text = "";
            dots4.Text = "";
            dots5.Text = "";
            dots6.Text = "";
            serveramount.SelectedItem = "1";
        }



        private void serveramount_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ServerAmount = 1
            if (serveramount.SelectedItem == "1")
            {
                server1address.Enabled = true;
                server1result.Text = "Idle";
                server2address.Enabled = false;
                server2address.Text = "";
                server2result.Text = "Disabled";
                server3address.Enabled = false;
                server3address.Text = "";
                server3result.Text = "Disabled";
                server4address.Enabled = false;
                server4address.Text = "";
                server4result.Text = "Disabled";
                server5address.Enabled = false;
                server5address.Text = "";
                server5result.Text = "Disabled";
                server6address.Enabled = false;
                server6address.Text = "";
                server6result.Text = "Disabled";
            }

            // ServerAmount = 2
            if (serveramount.SelectedItem == "2")
            {
                server1address.Enabled = true;
                server1result.Text = "Idle";
                server2address.Enabled = true;
                server2result.Text = "Idle";
                server3address.Enabled = false;
                server3address.Text = "";
                server3result.Text = "Disabled";
                server4address.Enabled = false;
                server4address.Text = "";
                server4result.Text = "Disabled";
                server5address.Enabled = false;
                server5address.Text = "";
                server5result.Text = "Disabled";
                server6address.Enabled = false;
                server6address.Text = "";
                server6result.Text = "Disabled";
            }

            // ServerAmount = 3
            if (serveramount.SelectedItem == "3")
            {
                server1address.Enabled = true;
                server1result.Text = "Idle";
                server2address.Enabled = true;
                server2result.Text = "Idle";
                server3address.Enabled = true;
                server3result.Text = "Idle";
                server4address.Enabled = false;
                server4address.Text = "";
                server4result.Text = "Disabled";
                server5address.Enabled = false;
                server5address.Text = "";
                server5result.Text = "Disabled";
                server6address.Enabled = false;
                server6address.Text = "";
                server6result.Text = "Disabled";
            }

            // ServerAmount = 4
            if (serveramount.SelectedItem == "4")
            {
                server1address.Enabled = true;
                server1result.Text = "Idle";
                server2address.Enabled = true;
                server2result.Text = "Idle";
                server3address.Enabled = true;
                server3result.Text = "Idle";
                server4address.Enabled = true;
                server4result.Text = "Idle";
                server5address.Enabled = false;
                server5address.Text = "";
                server5result.Text = "Disabled";
                server6address.Enabled = false;
                server6address.Text = "";
                server6result.Text = "Disabled";
            }

            // ServerAmount = 5
            if (serveramount.SelectedItem == "5")
            {
                server1address.Enabled = true;
                server1result.Text = "Idle";
                server2address.Enabled = true;
                server2result.Text = "Idle";
                server3address.Enabled = true;
                server3result.Text = "Idle";
                server4address.Enabled = true;
                server4result.Text = "Idle";
                server5address.Enabled = true;
                server5result.Text = "Idle";
                server6address.Enabled = false;
                server6address.Text = "";
                server6result.Text = "Disabled";
            }

            // ServerAmount = 6
            if (serveramount.SelectedItem == "6")
            {
                server1address.Enabled = true;
                server1result.Text = "Idle";
                server2address.Enabled = true;
                server2result.Text = "Idle";
                server3address.Enabled = true;
                server3result.Text = "Idle";
                server4address.Enabled = true;
                server4result.Text = "Idle";
                server5address.Enabled = true;
                server5result.Text = "Idle";
                server6address.Enabled = true;
                server6result.Text = "Idle";
            }
        }

        private void perthservers_Click(object sender, EventArgs e)
        {
            serveramount.SelectedItem = "5";
            server1address.Text = "speedtest-per.cdn.on.net";
            server2address.Text = "speedtest.waia.asn.au";
            server3address.Text = "speedcheck.cdn.on.net";
            server4address.Text = "perthrackspace.com.au";
            server5address.Text = "murbak.com.au";
        }

        private void adelaidservers_Click(object sender, EventArgs e)
        {
            server1address.Text = "";
            server2address.Text = "";
            server3address.Text = "";
            server4address.Text = "";
            server5address.Text = "";
            server6address.Text = "";
        }

        private void sydneyservers_Click(object sender, EventArgs e)
        {
            serveramount.SelectedItem = "5";
            server1address.Text = "";
            server2address.Text = "";
            server3address.Text = "";
            server4address.Text = "";
            server5address.Text = "";
            server6address.Text = "";
        }

        private void brisbaneservers_Click(object sender, EventArgs e)
        {
            server1address.Text = "";
            server2address.Text = "";
            server3address.Text = "";
            server4address.Text = "";
            server5address.Text = "";
            server6address.Text = "";
        }

        private void sanfranciscoservers_Click(object sender, EventArgs e)
        {
            server1address.Text = "";
            server2address.Text = "";
            server3address.Text = "";
            server4address.Text = "";
            server5address.Text = "";
            server6address.Text = "";
        }

        private void losangelesservers_Click(object sender, EventArgs e)
        {
            server1address.Text = "";
            server2address.Text = "";
            server3address.Text = "";
            server4address.Text = "";
            server5address.Text = "";
            server6address.Text = "";
        }

        private void parisservers_Click(object sender, EventArgs e)
        {
            server1address.Text = "";
            server2address.Text = "";
            server3address.Text = "";
            server4address.Text = "";
            server5address.Text = "";
            server6address.Text = "";
        }

        private void singaporeservers_Click(object sender, EventArgs e)
        {
            server1address.Text = "";
            server2address.Text = "";
            server3address.Text = "";
            server4address.Text = "";
            server5address.Text = "";
            server6address.Text = "";
        }

        private void threadsleepdelay_ValueChanged(object sender, EventArgs e)
        {
            Variables.sleeptime = Convert.ToInt32(threadsleepdelay.Value * 1000);
        }


        public void about_Click(object sender, EventArgs e)
        {

            Form about = new aboutform();
            about.ShowDialog();
        }
    }
}
