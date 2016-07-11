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
    public partial class ConnectInfrastructureNetwork : Form
    {
        public ConnectInfrastructureNetwork()
        {
            InitializeComponent();
        }

        string[] FullProfileList;

        internal DialogResult ConnectNetwork()
        {
            string[] InterfacesResults = LoadInterfaces();

            for (int ii = 0; ii < InterfacesResults.Length; ii++)
            {
                interfaceComboBox.Items.Add(InterfacesResults[ii].Trim());
                if (ii == 0)
                    interfaceComboBox.Text = InterfacesResults[ii].Trim();
            }

            LoadProfiles();

            string[] Adhoc = RetrieveAdhocNetworks(FullProfileList);

            for (int ii = 0; ii < Adhoc.Length; ii++)
            {
                networkListBox.Items.Add(Adhoc[ii]);
            }

            return this.ShowDialog();
        }

        private string[] RetrieveAdhocNetworks(string[] ProfileList)
        {
            List<string> AdhocNetworks = new List<string>();

            for (int ii = 0; ii < ProfileList.Length; ii++)
            {
                if (GetNetworkType(ProfileList[ii]).ToLower().Trim() != "adhoc") //infrastructure or adhoc
                {
                    AdhocNetworks.Add(ProfileList[ii]);
                }
            }

            return AdhocNetworks.ToArray();
        }

        private string GetNetworkType(string profileName)
        {
            string result = "";

            string cmdLine = "wlan show profiles name=\"" + profileName.Trim() + "\"";

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
            bool StartRead = false;

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
                if (StartRead)
                {
                    if (OutputCache[ii].ToLower().Contains("network type"))
                    {
                        result = (OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim());
                        break;
                    }
                }
                else
                {
                    if (OutputCache[ii].ToLower().Contains("profile information"))
                        StartRead = true;
                }
            }

            return result;
        }

        internal void LoadProfiles()
        {
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
            netsh.StandardInput.WriteLine("wlan show profiles");
            netsh.StandardInput.WriteLine("exit");

            List<string> output = new List<string>();
            string garbagecan = "";
            int DelayRead = 1;
            bool StartRead = false;
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
                    {
                        break;
                    }
                }

                for (int ii = 0; ii < OutputCache.Count; ii++)
                {
                    garbagecan = OutputCache[ii];

                    if (StartRead)
                    {
                        if (garbagecan != String.Empty)
                        {
                            if (DelayRead == 0)
                            {
                                output.Add(garbagecan);
                            }
                            else
                                DelayRead--;
                        }
                        else
                            break;
                    }
                    else
                    {
                        if (garbagecan.ToLower().Contains("user profiles"))
                            StartRead = true;
                    }
                }
            }

            List<string> Profiles = new List<string>();

            for (int ii = 0; ii < output.Count; ii++)
            {
                string outputLine = "";

                if (output[ii].ToLower().Contains("all user profile"))
                {
                    outputLine = output[ii].Substring(output[ii].IndexOf(':') + 1);
                }
                else
                    outputLine = output[ii];

                Profiles.Add(outputLine);
            }

            FullProfileList = Profiles.ToArray();
        }

        private string[] LoadInterfaces()
        {
            string cmdLine = "wlan show interfaces";

            List<string> results = new List<string>();

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

            List<string> output = new List<string>();
            string garbagecan = "";
            int DelayRead = 1;
            List<string> OutputCache = new List<string>();

            using (StreamReader reader = netsh.StandardOutput)
            {
                while (garbagecan != "FA1L3d")
                {
                    try
                    { garbagecan = reader.ReadLine(); }
                    catch
                    { garbagecan = "FA1L3d!"; }

                    if (garbagecan != "FA1L3d" && garbagecan != null)
                        OutputCache.Add(garbagecan);
                    else
                        break;
                }

                string lastString = "";

                for (int ii = 0; ii < OutputCache.Count; ii++)
                {
                    garbagecan = OutputCache[ii];

                    if (DelayRead == 0)
                    {
                        if (garbagecan.ToLower().Contains("name"))
                            output.Add(garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim());
                    }
                    else
                        DelayRead--;

                    lastString = garbagecan;
                }
            }

            for (int ii = 0; ii < output.Count; ii++)
            {
                //if (!output[ii].Contains("netsh"))
                results.Add(output[ii].Trim());
            }

            return results.ToArray();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            interfaceComboBox.Items.Clear();

            string[] InterfacesResults = LoadInterfaces();

            for (int ii = 0; ii < InterfacesResults.Length; ii++)
            {
                interfaceComboBox.Items.Add(InterfacesResults[ii].Trim());
                if (ii == 0)
                    interfaceComboBox.Text = InterfacesResults[ii].Trim();
            }

            networkListBox.Items.Clear();

            LoadProfiles();

            string[] Adhoc = RetrieveAdhocNetworks(FullProfileList);

            for (int ii = 0; ii < Adhoc.Length; ii++)
            {
                networkListBox.Items.Add(Adhoc[ii]);
            }
        }

        private void ConnectAdHocNetwork_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Retry)
                e.Cancel = true;
        }

        private void ConnectToNetwork(string profileName, string interfaceName)
        {
            string cmdLine = "wlan connect name=\"" + profileName + "\" ssid=\"" + profileName + "\" interface=\"" + interfaceName + "\"";

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

            List<string> output = new List<string>();
            string garbagecan = "";
            List<string> OutputCache = new List<string>();

            using (StreamReader reader = netsh.StandardOutput)
            {
                while (garbagecan != "FA1L3d")
                {
                    try
                    { garbagecan = reader.ReadLine(); }
                    catch
                    { garbagecan = "FA1L3d!"; }

                    if (garbagecan != "FA1L3d" && garbagecan != null)
                        OutputCache.Add(garbagecan);
                    else
                        break;
                }

            }

            MessageBox.Show(OutputCache[0].Substring("netsh>".Length).Trim(), "Connecting to Network...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectToNetwork(networkListBox.SelectedItem.ToString().Trim(), interfaceComboBox.Text.Trim());
                this.Close();
                //MessageBox.Show("The network profile has been successfully created, and added!", "Adding Network Profile...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Something went wrong while attempting to connect to the network!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConnectInfrastructureNetwork_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(384, Screen.PrimaryScreen.Bounds.Height);
        }

        private void ConnectInfrastructureNetwork_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Retry)
                e.Cancel = true;
        }
    }
}
