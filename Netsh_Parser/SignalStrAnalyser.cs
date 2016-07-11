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
    public partial class SignalStrAnalyser : Form
    {
        private List<string> BssidsNInfo = new List<string>();
        private List<List<string>> NetworkInfo = new List<List<string>>();

        public SignalStrAnalyser()
        {
            InitializeComponent();
        }

        private void LoadNetworkInfo(List<List<string>> jaggedList, string networkName)
        {
            for (int ii = 0; ii < jaggedList.Count; ii++)
            {
                if (jaggedList[ii][0].ToLower().Contains(networkName.ToLower()))
                {
                    ssidNameTB.Text = jaggedList[ii][0];
                    netTypeTB.Text = jaggedList[ii][1];
                    authTB.Text = jaggedList[ii][2];
                    encryptTB.Text = jaggedList[ii][3];
                }
            }
        }

        private void LoadBssids(List<string> bssidList)
        {
            bssidComboBox.Items.Clear();

            for (int ii = 0; ii < bssidList.Count; ii++)
            {
                if (bssidList[ii].ToLower().Contains("bssid"))
                {
                    bssidComboBox.Items.Add(bssidList[ii].Substring(0, bssidList[ii].IndexOf(":") - 1).Trim());

                    if (ii == 0)
                        bssidComboBox.Text = bssidList[ii].Substring(0, bssidList[ii].IndexOf(":") - 1).Trim();
                }
            }
        }

        private void LoadBssidInfo(List<string> bssidInfoList)
        {
            bool FoundIt = false;
            string lastString = "";
            bool FoundItAgain = false;
            string garbagecan = "";

            for (int ii = 0; ii < bssidInfoList.Count; ii++)
            {
                garbagecan = bssidInfoList[ii];

                if (!FoundIt)
                {
                    if (garbagecan.ToLower().Contains("bssid"))
                    {
                        macTB.Text = garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim();
                        FoundIt = true;
                    }
                }
                else
                {
                    if (!FoundItAgain && garbagecan.ToLower().Contains("bssid"))
                    {
                        FoundItAgain = true;
                    }
                    else if (!FoundItAgain && !garbagecan.ToLower().Contains("bssid"))
                    {
                        if (garbagecan.ToLower().Trim().Contains("signal"))
                        {
                            strengthTB.Text = garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim();
                        }
                        else if (garbagecan.ToLower().Trim().Contains("radio type"))
                        {
                            radioTypeTB.Text = garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim();
                        }
                        else if (garbagecan.ToLower().Trim().Contains("channel"))
                        {
                            channelTB.Text = garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim();
                        }
                        else if (garbagecan.ToLower().Trim().Contains("basic rates (mbps)"))
                        {
                            basicRatesTB.Text = garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim().Replace(" ", ", ");
                        }
                        else if (garbagecan.ToLower().Trim().Contains("other rates (mbps)"))
                        {
                            otherRatesTB.Text = garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim().Replace(" ", ", ");
                        }
                        else if (garbagecan.ToLower().Trim().Contains("bssid"))
                        {
                            FoundItAgain = true;
                            break;
                        }
                    }
                    else if (FoundItAgain)
                        break;
                }

                lastString = bssidInfoList[ii];
            }
        }

        internal void ViewDetails()
        {
            RefreshInterfaces();

            LoadNetworks();

            GatherBssidInfo();

            LoadBssids(BssidsNInfo);

            LoadNetworkInfo(NetworkInfo, networkComboBox.Text);

            this.ShowDialog();
        }

        private void GatherBssidInfo()
        {
            BssidsNInfo = FindBSSIDs(networkComboBox.Text, interfaceComboBox.Text);
        }

        private void LoadNetworks()
        {
            networkComboBox.Items.Clear();

            List<string> NetworkList = FindNetworks(interfaceComboBox.Text.Trim());

            for (int ii = 0; ii < NetworkList.Count; ii++)
            {
                networkComboBox.Items.Add(NetworkList[ii].Trim());
                if (ii == 0)
                    networkComboBox.Text = NetworkList[ii].Trim();
            }
        }

        private List<string> FindBSSIDs(string networkSSID, string interfaceName)
        {
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
            netsh.StandardInput.WriteLine("wlan show networks interface=\"" + interfaceName + "\" mode=bssid");
            netsh.StandardInput.WriteLine("exit");

            List<string> output = new List<string>();
            string garbagecan = "";
            int DelayRead = 3;
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
                bool StartRead = false;
                List<string> Output2 = new List<string>();
                bool NetInfoAdded = false;

                for (int ii = 0; ii < OutputCache.Count; ii++)
                {
                    garbagecan = OutputCache[ii];
                    if (!StartRead)
                    {
                        if (!garbagecan.ToLower().Contains("bssid") && garbagecan.ToLower().Contains("ssid") && garbagecan.ToLower().Contains(networkSSID.ToLower())) //infrastructure or adhoc
                        {
                            Output2.Add(garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim());
                            StartRead = true;
                        }
                    }
                    else if (StartRead && garbagecan != "")
                    {
                        if (DelayRead == 0)
                        {
                            bool TestForStartText = garbagecan.ToLower().StartsWith("ssid");
                            if (!TestForStartText)
                            {
                                if (!NetInfoAdded)
                                {
                                    NetInfoAdded = true;
                                    NetworkInfo.Add(Output2);
                                }
                                output.Add(garbagecan); //output.Add(garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim());
                            }
                            else
                            {

                                break;
                            }
                        }
                        else
                        {
                            DelayRead--;
                            if (garbagecan.ToLower().Contains("network type"))
                            {
                                Output2.Add(garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim());
                            }
                            else if (garbagecan.ToLower().Contains("authentication"))
                            {
                                Output2.Add(garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim());
                            }
                            else if (garbagecan.ToLower().Contains("encryption"))
                            {
                                Output2.Add(garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim());
                            }
                        }
                    }
                    
                    secondLastString = lastString;
                    lastString = garbagecan;
                }
            }

            for (int ii = 0; ii < output.Count; ii++)
            {
                if (!output[ii].Contains("netsh"))
                    results.Add(output[ii].Trim());
            }

            return results;
        }

        private List<string> FindNetworks(string interfaceName)
        {
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
            netsh.StandardInput.WriteLine("wlan show networks interface=\"" + interfaceName + "\" mode=bssid");
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
                        if (!garbagecan.ToLower().Contains("bssid") && garbagecan.ToLower().Contains("ssid")) //infrastructure or adhoc
                            output.Add(garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim());
                        //else if (garbagecan.ToLower().Contains("authentication"))
                        //{
                        //    for (int iii = 0; iii < output.Count; iii++)
                        //    {
                        //        if (secondLastString.Contains(output[iii]))
                        //            AuthenType.Add(garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim());
                        //    }
                        //}
                    }
                    else
                        DelayRead--;

                    secondLastString = lastString;
                    lastString = garbagecan;
                }
            }

            //List<string> tempResults = new List<string>();

            for (int ii = 0; ii < output.Count; ii++)
            {
                if (!output[ii].Contains("netsh"))
                    results.Add(output[ii].Trim());
            }

            //results.Add(tempResults);
            //results.Add(AuthenType);
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

        private void RefreshInterfaces()
        {
            interfaceComboBox.Items.Clear();

            string[] InterfacesResults = LoadInterfaces();

            for (int ii = 0; ii < InterfacesResults.Length; ii++)
            {
                interfaceComboBox.Items.Add(InterfacesResults[ii].Trim());
                if (ii == 0)
                    interfaceComboBox.Text = InterfacesResults[ii].Trim();
            }
        }

        private void interfaceRefreshButton_Click(object sender, EventArgs e)
        {
            RefreshInterfaces();

            LoadNetworks();
        }

        private void interfaceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadNetworks();
        }

        private void networkComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GatherBssidInfo();

            LoadBssids(BssidsNInfo);

            LoadNetworkInfo(NetworkInfo, networkComboBox.Text);
        }

        private void bssidComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearAllFields();

            LoadNetworkInfo(NetworkInfo, networkComboBox.Text);

            GetUpdatedBssidInfo(bssidComboBox.Text, BssidsNInfo);
        }

        private void ClearAllFields()
        {
            ssidNameTB.Clear();
            netTypeTB.Clear();
            radioTypeTB.Clear();

            macTB.Clear();
            channelTB.Clear();
            strengthTB.Clear();

            authTB.Clear();
            encryptTB.Clear();

            basicRatesTB.Clear();
            otherRatesTB.Clear();
        }

        private void GetUpdatedBssidInfo(string bssidMac, List<string> bssidInfoList)
        {
            bool FoundIt = false;
            string lastString = "";
            bool FoundItAgain = false;
            string garbagecan = "";

            for (int ii = 0; ii < bssidInfoList.Count; ii++)
            {
                garbagecan = bssidInfoList[ii];

                if (!FoundIt)
                {
                    if (garbagecan.ToLower().Contains("bssid") && garbagecan.ToLower().Contains(bssidMac.ToLower()))
                    {
                        macTB.Text = garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim();
                        FoundIt = true;
                    }
                }
                else
                {
                    if (!FoundItAgain && garbagecan.ToLower().Contains("bssid"))
                    {
                        FoundItAgain = true;
                    }
                    else if (!FoundItAgain && !garbagecan.ToLower().Contains("bssid"))
                    {
                        if (garbagecan.ToLower().Trim().Contains("signal"))
                        {
                            strengthTB.Text = garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim();
                        }
                        else if (garbagecan.ToLower().Trim().Contains("radio type"))
                        {
                            radioTypeTB.Text = garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim();
                        }
                        else if (garbagecan.ToLower().Trim().Contains("channel"))
                        {
                            channelTB.Text = garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim();
                        }
                        else if (garbagecan.ToLower().Trim().Contains("basic rates (mbps)"))
                        {
                            basicRatesTB.Text = garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim().Replace(" ", ", ");
                        }
                        else if (garbagecan.ToLower().Trim().Contains("other rates (mbps)"))
                        {
                            otherRatesTB.Text = garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim().Replace(" ", ", ");
                        }
                        else if (garbagecan.ToLower().Trim().Contains("bssid"))
                        {
                            FoundItAgain = true;
                            break;
                        }
                    }
                    else if (FoundItAgain)
                        break;
                }

                lastString = bssidInfoList[ii];
            }
        }

        private void bssidComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Up && e.KeyChar != (char)Keys.Down)
                e.Handled = true;
        }

        private void networkComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                networkRefreshButton.PerformClick();
            }
            else if (e.KeyChar != (char)Keys.Up && e.KeyChar != (char)Keys.Down)
                e.Handled = true;
        }

        private void interfaceComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                interfaceRefreshButton.PerformClick();
            }
            else if (e.KeyChar != (char)Keys.Up && e.KeyChar != (char)Keys.Down)
                e.Handled = true;
        }

        private void refreshAllButton_Click(object sender, EventArgs e)
        {
            ClearAllFields();

            RefreshInterfaces();

            LoadNetworks();

            GatherBssidInfo();

            LoadBssids(BssidsNInfo);

            LoadNetworkInfo(NetworkInfo, networkComboBox.Text);
        }
    }
}
