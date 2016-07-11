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
    public partial class AdHocManagerWin : Form
    {
        internal static string ssidName = "";
        internal static string interfaceName = "";

        public AdHocManagerWin()
        {
            InitializeComponent();
        }

        internal void StartAdhocManager()
        {
            networkListView.Items.Clear();

            interfaceComboBox.Items.Clear();

            string[] InterfacesResults = LoadInterfaces();

            for (int ii = 0; ii < InterfacesResults.Length; ii++)
            {
                interfaceComboBox.Items.Add(InterfacesResults[ii].Trim());
                if (ii == 0)
                    interfaceComboBox.Text = InterfacesResults[ii].Trim();
            }

            List<List<string>> NetworkList = FindNetworks(interfaceComboBox.Text.Trim());

            for (int ii = 0; ii < NetworkList[0].Count; ii++)
            {
                ListViewItem lvi = new ListViewItem(NetworkList[0][ii]);
                lvi.SubItems.Add(NetworkList[1][ii]);

                networkListView.Items.Add(lvi);
            }

            this.ShowDialog();
        }

        private List<List<string>> FindNetworks()
        {
            List<List<string>> results = new List<List<string>>();

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
            netsh.StandardInput.WriteLine("wlan show networks");
            netsh.StandardInput.WriteLine("exit");

            List<string> output = new List<string>();
            string garbagecan = "";
            int DelayRead = 1;
            List<string> OutputCache = new List<string>();

            List<string> AuthenType = new List<string>();

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
                string secondLastString = "";

                for (int ii = 0; ii < OutputCache.Count; ii++)
                {
                    garbagecan = OutputCache[ii];

                    if (DelayRead == 0)
                    {
                        if (garbagecan.ToLower().Contains("infrastructure"))
                            output.Add(lastString.Substring(lastString.IndexOf(":") + 1).Trim());
                        else if (garbagecan.ToLower().Contains("authentication"))
                        {
                            for (int iii = 0; iii < output.Count; iii++)
                            {
                                if (secondLastString.Contains(output[iii]))
                                    AuthenType.Add(garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim());
                            }
                        }
                    }
                    else
                        DelayRead--;

                    secondLastString = lastString;
                    lastString = garbagecan;
                }
            }

            List<string> tempResults = new List<string>();

            for (int ii = 0; ii < output.Count; ii++)
            {
                if (!output[ii].Contains("netsh"))
                    tempResults.Add(output[ii].Trim());
            }

            results.Add(tempResults);
            results.Add(AuthenType);
            return results;
        }

        private List<List<string>> FindNetworks(string interfaceName)
        {
            List<List<string>> results = new List<List<string>>();

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
            netsh.StandardInput.WriteLine("wlan show networks interface=" +interfaceName);
            netsh.StandardInput.WriteLine("exit");

            List<string> output = new List<string>();
            string garbagecan = "";
            int DelayRead = 1;
            List<string> OutputCache = new List<string>();

            List<string> AuthenType = new List<string>();

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
                string secondLastString = "";

                for (int ii = 0; ii < OutputCache.Count; ii++)
                {
                    garbagecan = OutputCache[ii];

                    if (DelayRead == 0)
                    {
                        if (garbagecan.ToLower().Contains("adhoc")) //infrastructure or adhoc
                            output.Add(lastString.Substring(lastString.IndexOf(":") + 1).Trim());
                        else if (garbagecan.ToLower().Contains("authentication"))
                        {
                            for (int iii = 0; iii < output.Count; iii++)
                            {
                                if (secondLastString.Contains(output[iii]))
                                    AuthenType.Add(garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim());
                            }
                        }
                    }
                    else
                        DelayRead--;

                    secondLastString = lastString;
                    lastString = garbagecan;
                }
            }

            List<string> tempResults = new List<string>();

            for (int ii = 0; ii < output.Count; ii++)
            {
                if (!output[ii].Contains("netsh"))
                    tempResults.Add(output[ii].Trim());
            }

            results.Add(tempResults);
            results.Add(AuthenType);
            return results;
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

        private void AdHocManagerWin_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(330, Screen.PrimaryScreen.Bounds.Height);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            networkListView.Items.Clear();

            interfaceComboBox.Items.Clear();

            string[] InterfacesResults = LoadInterfaces();

            for (int ii = 0; ii < InterfacesResults.Length; ii++)
            {
                interfaceComboBox.Items.Add(InterfacesResults[ii].Trim());
                if (ii == 0)
                    interfaceComboBox.Text = InterfacesResults[ii].Trim();
            }

            List<List<string>> NetworkList = FindNetworks(interfaceComboBox.Text.Trim());

            for (int ii = 0; ii < NetworkList[0].Count; ii++)
            {
                ListViewItem lvi = new ListViewItem(NetworkList[0][ii]);
                lvi.SubItems.Add(NetworkList[1][ii]);

                networkListView.Items.Add(lvi);
            }
        }

        private void otherLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ManualAdHocConnect objManual = new ManualAdHocConnect();

            if (objManual.ShowDialog() == DialogResult.OK)
            {
                string filePath = Directory.GetCurrentDirectory() + "\\Ad-Hoc-" + ssidName.Trim().Replace(" ", "_") + ".xml";

                try
                {
                    GenerateXMLFile(CreateNewAdhocProfileNoAuth(ssidName), filePath);

                    string cmdLine = "wlan add profile filename=\"" + filePath + "\"  interface=\"" + interfaceComboBox.Text.Trim() + "\" user=all";

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

                    MessageBox.Show(OutputCache[0].Substring("netsh>".Length).Trim());

                    //MessageBox.Show("The network profile has been successfully created, and added!", "Adding Network Profile...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch 
                {
                    MessageBox.Show("Something went wrong while attempting to manually create the network profile!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string[] CreateNewAdhocProfileNoAuth(string profileName)
        {
            List<string> ProfileXMLConfiguration = new List<string>();

            string connectiontype = "IBSS";
            string connectionmode = "manual";
            string nonbroadcast = "false";
            string authentication = "open";
            string encryption = "none";
            string UseOneX = "false";

            ProfileXMLConfiguration.Add("<?xml version=\"1.0\"?>");
            ProfileXMLConfiguration.Add("<WLANProfile xmlns=\"http://www.microsoft.com/networking/WLAN/profile/v1\">");
            ProfileXMLConfiguration.Add("\t<name>" + profileName +  "</name>");
            ProfileXMLConfiguration.Add("\t<SSIDConfig>");
            ProfileXMLConfiguration.Add("\t\t<SSID>");
            ProfileXMLConfiguration.Add("\t\t\t<name>" + profileName + "</name>");
            ProfileXMLConfiguration.Add("\t\t</SSID>");
            ProfileXMLConfiguration.Add("\t\t<nonBroadcast>" + nonbroadcast + "</nonBroadcast>");
            ProfileXMLConfiguration.Add("\t</SSIDConfig>");
            ProfileXMLConfiguration.Add("\t<connectionType>" + connectiontype + "</connectionType>");
            ProfileXMLConfiguration.Add("\t<connectionMode>" + connectionmode + "</connectionMode>");
            ProfileXMLConfiguration.Add("\t<MSM>");
            ProfileXMLConfiguration.Add("\t\t<security>");
            ProfileXMLConfiguration.Add("\t\t\t<authEncryption>");
            ProfileXMLConfiguration.Add("\t\t\t\t<authentication>" + authentication + "</authentication>");
            ProfileXMLConfiguration.Add("\t\t\t\t<encryption>" + encryption + "</encryption>");
            ProfileXMLConfiguration.Add("\t\t\t\t<useOneX>" + UseOneX + "</useOneX>");
            ProfileXMLConfiguration.Add("\t\t\t</authEncryption>");
            ProfileXMLConfiguration.Add("\t\t</security>");
            ProfileXMLConfiguration.Add("\t</MSM>");
            ProfileXMLConfiguration.Add("</WLANProfile>");

            return ProfileXMLConfiguration.ToArray();
        }

        private void GenerateXMLFile(string[] XMLConfiguration, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                for (int ii = 0; ii < XMLConfiguration.Length; ii++)
                {
                    writer.WriteLine(XMLConfiguration[ii]);
                }
            }
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            string AuthType = networkListView.Items[networkListView.SelectedIndices[0]].SubItems[1].Text.ToLower();
            if (AuthType != "open")
            {
                MessageBox.Show("Sorry, this software is unable to support the connecting of Ad-Hoc networks with passwords by default! You will need to follow the instructions in the next message to add a new wireless profile just for it first.", "Unsupported Feature", MessageBoxButtons.OK, MessageBoxIcon.Error);

                MessageBox.Show("1) Go to \"Network and Sharing Center\" by right-clicking network icon in notification area" + Environment.NewLine +
                    "2) Click \"Set up a new connection or network\"" + Environment.NewLine +
                    "3) Double click \"Manually connect to a wireless network\"" + Environment.NewLine +
                    "4) Enter the SSID of the ad-hoc network (as shown by \"netsh wlan show networks\") into the \"Network name\" field" + Environment.NewLine +
                    "5) Configure security settings accordingly, i.e. Authentication: Open, Encryption: None" + Environment.NewLine +
                    "6) Un-check \"Start this connection automatically\" (important)" + Environment.NewLine +
                    "7) Click \"Next\", then \"Close\"" + Environment.NewLine + Environment.NewLine + "When you have completed the above steps, click \"OK\".", "Unsupported Feature", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MessageBox.Show("Now, after completing all the prior steps, run this command (important), and replace \"SSIDNameHere\" with the SSID of the Ad-Hoc network:" + Environment.NewLine + Environment.NewLine +
                    "> netsh wlan set profileparameter name=\"SSIDNameHere\" connectiontype=ibss", "Unsupported Feature", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    string filePath = Directory.GetCurrentDirectory() + "\\Ad-Hoc-" + networkListView.Items[networkListView.SelectedIndices[0]].Text.Trim() + ".xml";

                    GenerateXMLFile(CreateNewAdhocProfileNoAuth(networkListView.Items[networkListView.SelectedIndices[0]].Text.Trim()), filePath);

                    string cmdLine = "wlan add profile filename=\"" + filePath + "\"  interface=\"" + interfaceComboBox.Text.Trim() + "\" user=all";

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

                    MessageBox.Show(OutputCache[0].Substring("netsh>".Length).Trim());

                    if (MessageBox.Show("Would you like to try to connect to the network now?", "Connect to Ad-Hoc Network", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        ConnectToNetwork(networkListView.Items[networkListView.SelectedIndices[0]].Text.Trim(), interfaceComboBox.Text.Trim());
                    }

                    this.Close();
                    //MessageBox.Show("The network profile has been successfully created, and added!", "Adding Network Profile...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Something went wrong while attempting to connect to the network!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void interfaceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<List<string>> NetworkList = FindNetworks(interfaceComboBox.Text);

            for (int ii = 0; ii < NetworkList[0].Count; ii++)
            {
                ListViewItem lvi = new ListViewItem(NetworkList[0][ii]);
                lvi.SubItems.Add(NetworkList[1][ii]);

                networkListView.Items.Add(lvi);
            }
        }
    }
}
