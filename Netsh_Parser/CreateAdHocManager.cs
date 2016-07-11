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

namespace Netsh_Parser
{
    public partial class CreateAdHocManager : Form
    {
        internal static string strUsername = "";
        internal static string strPassword = "";
        internal static string strPersistency = "";

        public CreateAdHocManager()
        {
            InitializeComponent();
        }

        internal void ShowNormally()
        {
            nameTB.Text = "";
            passwordTB.Text = "";

            GetHostedNetworkInfo();

            this.ShowDialog();
        }

        internal void CreateAdhocNetworkDirect()
        {
            CreateAdhocNetwork();

            this.ShowDialog();
        }

        private void CreateAdhocNetwork()
        {
            if (TestAdhocSupport().ToLower() == "no")
            {
                MessageBox.Show("Your WLAN network card unfortunately does not support a hosted network!", "Feature Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                CreateAdHoc objCreate = new CreateAdHoc();

                if (objCreate.ShowDialog() == DialogResult.OK)
                {
                    string cmdLine = "";

                    if (strPassword.Trim() == "")
                    {
                        cmdLine = "netsh wlan set hostednetwork mode=allow ssid=\"" + strUsername + "\" && " + "netsh wlan set hostednetwork key=";
                    }
                    else
                    {
                        cmdLine = "netsh wlan set hostednetwork mode=allow ssid=\"" + strUsername + "\" && " + "netsh wlan set hostednetwork key=" + strPassword + " keyUsage=" + strPersistency;
                    }

                    MessageBox.Show(cmdLine);

                    nameTB.Text = strUsername;
                    passwordTB.Text = strPassword;

                    string runasString = "/C";
                    string finalArgs = runasString + cmdLine;

                    ProcessStartInfo process = new ProcessStartInfo("cmd.exe", finalArgs)
                    {
                        UseShellExecute = true,
                        Verb = "runas"
                    };

                    //Process netsh = new Process()
                    //{
                    //    StartInfo = new ProcessStartInfo("cmd.exe", finalArgs)
                    //    {
                    //        //RedirectStandardInput = false,
                    //        //RedirectStandardOutput = false,
                    //        UseShellExecute = false,
                    //        //CreateNoWindow = false,
                    //        Verb = "runas"
                    //    }
                    //};

                    Process.Start(process);

                    GetHostedNetworkInfo();
                }
            }
        }

        private string TestAdhocSupport()
        {
            string cmdLine = "wlan show drivers";

            string result = "";

            Process netsh = new Process()
            {
                StartInfo = new ProcessStartInfo("netsh")
                {
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            netsh.Start();
            netsh.StandardInput.WriteLine(cmdLine);
            netsh.StandardInput.WriteLine("exit");

            string garbagecan = "";
            List<string> OutputCache = new List<string>();

            using (StreamReader reader = netsh.StandardOutput)
            {
                while (garbagecan != "FA1L3d")
                {
                    try
                    {
                        garbagecan = reader.ReadLine();
                    }
                    catch
                    {
                        garbagecan = "FA1L3d!";
                    }

                    if (garbagecan != "FA1L3d" && garbagecan != null)
                        OutputCache.Add(garbagecan);
                    else
                        break;
                }
            }

            for (int ii = 0; ii < OutputCache.Count; ii++)
            {
                if (OutputCache[ii].ToLower().Contains("hosted network supported"))
                {
                    result = OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim();
                }
            }

            return result;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            ToggleHostedNetworkState(startButton.Text);

            GetHostedNetworkInfo();

            if (statusLabel.Text.ToLower() == "not available")
            {
                MessageBox.Show("It seems as if there is an issue starting the hostednetwork. It might be due to the computer having other virtual networks..." + Environment.NewLine + "Try googling for \"hostednetwork won't start\" to find possible solutions");
            }

            string statusCheck = CheckHostedNetworkState().ToLower();

            if (statusCheck == "not available" || statusCheck == "not started")
                startButton.Text = "Start";
            else
                startButton.Text = "Stop";
        }

        private string CheckHostedNetworkState()
        {
            string cmdLine = "wlan show hostednetwork";

            string result = "";

            Process netsh = new Process()
            {
                StartInfo = new ProcessStartInfo("netsh")
                {
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            netsh.Start();
            netsh.StandardInput.WriteLine(cmdLine);
            netsh.StandardInput.WriteLine("exit");

            string garbagecan = "";
            List<string> OutputCache = new List<string>();

            using (StreamReader reader = netsh.StandardOutput)
            {
                while (garbagecan != "FA1L3d")
                {
                    try
                    {
                        garbagecan = reader.ReadLine();
                    }
                    catch
                    {
                        garbagecan = "FA1L3d!";
                    }

                    if (garbagecan != "FA1L3d" && garbagecan != null)
                        OutputCache.Add(garbagecan);
                    else
                        break;
                }
            }

            for (int ii = 0; ii < OutputCache.Count; ii++)
            {
                if (OutputCache[ii].ToLower().Contains("status"))
                {
                    result = OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim();
                }
            }

            statusLabel.Text = result;

            return result;
        }

        private void GetHostedNetworkInfo()
        {
            string cmdLine = "wlan show hostednetwork";

            CheckHostedNetworkState();

            Process netsh = new Process()
            {
                StartInfo = new ProcessStartInfo("netsh")
                {
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            netsh.Start();
            netsh.StandardInput.WriteLine(cmdLine);
            netsh.StandardInput.WriteLine("exit");

            string garbagecan = "";
            List<string> OutputCache = new List<string>();

            using (StreamReader reader = netsh.StandardOutput)
            {
                while (garbagecan != "FA1L3d")
                {
                    try
                    {
                        garbagecan = reader.ReadLine();
                    }
                    catch
                    {
                        garbagecan = "FA1L3d!";
                    }

                    if (garbagecan != "FA1L3d" && garbagecan != null)
                        OutputCache.Add(garbagecan);
                    else
                        break;
                }
            }

            for (int ii = 0; ii < OutputCache.Count; ii++)
            {
                if (OutputCache[ii].ToLower().Contains("mode"))
                {
                    modeTB.Text = OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim();
                }
                else if (OutputCache[ii].ToLower().Contains("ssid name"))
                {
                    ssidTB.Text = OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Replace("\"", "").Trim();
                }
                else if (OutputCache[ii].ToLower().Contains("max number of clients"))
                {
                    maxTB.Text = OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim();
                }
                else if (OutputCache[ii].ToLower().Contains("authentication"))
                {
                    authTB.Text = OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim();
                }
                else if (OutputCache[ii].ToLower().Contains("cipher"))
                {
                    cipherTB.Text = OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim();
                }
            }

            GetHostedNetworkPassword();
        }

        private string ToggleHostedNetworkState(string status)
        {
            string result = "";

            string cmdLine = "";

            if (status.ToLower() == "start")
            {
                cmdLine = "netsh wlan start hostednetwork";
            }
            else
            {
                cmdLine = "netsh wlan stop hostednetwork";
            }

            string runasString = "/C";
            string finalArgs = runasString + cmdLine;

            ProcessStartInfo process = new ProcessStartInfo("cmd.exe", finalArgs)
            {
                UseShellExecute = true,
                Verb = "runas"
            };

            Process netsh = new Process()
            {
                StartInfo = new ProcessStartInfo("cmd.exe", finalArgs)
                {
                    //RedirectStandardInput = false,
                    //RedirectStandardOutput = false,
                    UseShellExecute = false,
                    //CreateNoWindow = false,
                    Verb = "runas"
                }
            };

            Process.Start(process);
            //netsh.StandardInput.WriteLine(cmdLine);
            //netsh.StandardInput.WriteLine("exit");

            if (CheckHostedNetworkState().ToLower() == "not started" || CheckHostedNetworkState().ToLower() == "not available")
                result = "Start";
            else
                result = "Stop";

            return result;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteHostedNetwork();

            GetHostedNetworkInfo();
        }

        private void DeleteHostedNetwork()
        {
            string cmdLine = "netsh wlan set hostednetwork mode=disallow ssid=NA key=";

            string runasString = "/C";
            string finalArgs = runasString + cmdLine;

            ProcessStartInfo process = new ProcessStartInfo("cmd.exe", finalArgs)
            {
                UseShellExecute = true,
                Verb = "runas"
            };

            Process netsh = new Process()
            {
                StartInfo = new ProcessStartInfo("cmd.exe", finalArgs)
                {
                    UseShellExecute = false,
                    Verb = "runas"
                }
            };

            Process.Start(process);
        }

        private void GetHostedNetworkPassword()
        {
            string cmdLine = "wlan show hostednetwork security";

            CheckHostedNetworkState();

            Process netsh = new Process()
            {
                StartInfo = new ProcessStartInfo("netsh")
                {
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            netsh.Start();
            netsh.StandardInput.WriteLine(cmdLine);
            netsh.StandardInput.WriteLine("exit");

            string garbagecan = "";
            List<string> OutputCache = new List<string>();

            using (StreamReader reader = netsh.StandardOutput)
            {
                while (garbagecan != "FA1L3d")
                {
                    try
                    {
                        garbagecan = reader.ReadLine();
                    }
                    catch
                    {
                        garbagecan = "FA1L3d!";
                    }

                    if (garbagecan != "FA1L3d" && garbagecan != null)
                        OutputCache.Add(garbagecan);
                    else
                        break;
                }
            }

            for (int ii = 0; ii < OutputCache.Count; ii++)
            {
                if (OutputCache[ii].ToLower().Contains("user security key usage"))
                {
                    pwdToolTip.SetToolTip(pwdTB, "User Security Key Usage (Type): " + OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim());
                }
                else if (OutputCache[ii].ToLower().Contains("user security key"))
                {
                    pwdTB.Text = OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim();
                }
            }
        }

        private void DisableHostedNetwork()
        {
            string cmdLine = "netsh wlan set hostednetwork mode=disallow";

            string runasString = "/C";
            string finalArgs = runasString + cmdLine;

            ProcessStartInfo process = new ProcessStartInfo("cmd.exe", finalArgs)
            {
                UseShellExecute = true,
                Verb = "runas"
            };

            Process netsh = new Process()
            {
                StartInfo = new ProcessStartInfo("cmd.exe", finalArgs)
                {
                    UseShellExecute = false,
                    Verb = "runas"
                }
            };

            Process.Start(process);

            GetHostedNetworkInfo();
        }

        private void EnableHostedNetwork()
        {
            string cmdLine = "netsh wlan set hostednetwork mode=allow";

            string runasString = "/C";
            string finalArgs = runasString + cmdLine;

            ProcessStartInfo process = new ProcessStartInfo("cmd.exe", finalArgs)
            {
                UseShellExecute = true,
                Verb = "runas"
            };

            Process netsh = new Process()
            {
                StartInfo = new ProcessStartInfo("cmd.exe", finalArgs)
                {
                    UseShellExecute = false,
                    Verb = "runas"
                }
            };

            Process.Start(process);

            GetHostedNetworkInfo();
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            CreateAdhocNetwork();
        }

        private void CreateAdHocManager_Load(object sender, EventArgs e)
        {
            MessageBox.Show("If the current hostednetwork (Ad-Hoc) has a password, you can find out if it's persistent or temporary by hovering over the password box in the Information area", "Tips before starting", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
