using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Netsh_Parser
{
    public partial class ConnectionStatus : Form
    {
        private List<string> InterfaceStatusList = new List<string>();
        private List<string> InterfaceNameList = new List<string>();
        private List<string> NetworkNameList = new List<string>();
        private List<string> NetworkTypeList = new List<string>();
        private List<string> AuthenTypeList = new List<string>();
        private List<string> EncryptTypeList = new List<string>();
        private List<string> RadioTypeList = new List<string>();

        public ConnectionStatus()
        {
            InitializeComponent();
        }

        internal void CheckConnectionStatus()
        {
            interfaceComboBox.Items.Clear();

            string[] InterfacesResults = LoadInterfaces();

            for (int ii = 0; ii < InterfacesResults.Length; ii++)
            {
                interfaceComboBox.Items.Add(InterfacesResults[ii].Trim());
                if (ii == 0)
                    interfaceComboBox.Text = InterfacesResults[ii].Trim();
            }

            ReadInformation(interfaceComboBox.Text);

            this.ShowDialog();
        }

        private void ReadInformation(string interfaceName)
        {
            for (int ii = 0; ii < InterfaceNameList.Count; ii++)
            {
                if (interfaceName == InterfaceNameList[ii])
                {
                    ifNameTB.Text = InterfaceNameList[ii];
                    ifStatusTB.Text = InterfaceStatusList[ii].Substring(0, 1).ToUpper() + InterfaceStatusList[ii].Substring(1).ToLower();

                    netSsidTB.Text = NetworkNameList[ii];
                    netTypeTB.Text = NetworkTypeList[ii];
                    radioTypeTB.Text = RadioTypeList[ii];

                    authTypeTB.Text = AuthenTypeList[ii];
                    encryptTypeTB.Text = EncryptTypeList[ii];

                }
            }
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
                string connectionstatus = "";
                bool EmptyPass = false;

                for (int ii = 0; ii < OutputCache.Count; ii++)
                {
                    garbagecan = OutputCache[ii];

                    if (DelayRead == 0)
                    {
                        if (garbagecan.ToLower().Contains("name"))
                        {
                            output.Add(garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim());
                            InterfaceNameList.Add(garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim());
                        }
                        else if (garbagecan.ToLower().Contains("state"))
                        {
                            InterfaceStatusList.Add(garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim());
                            connectionstatus = garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim();
                        }

                        if (connectionstatus != "" && !connectionstatus.Contains("disconnected"))
                        {
                            if (garbagecan.ToLower().Contains("ssid") && !garbagecan.ToLower().Contains("bssid"))
                            {
                                NetworkNameList.Add(garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim());
                            }
                            else if (garbagecan.ToLower().Contains("network type"))
                            {
                                NetworkTypeList.Add(garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim());
                            }
                            else if (garbagecan.ToLower().Contains("radio type"))
                            {
                                RadioTypeList.Add(garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim());
                            }
                            else if (garbagecan.ToLower().Contains("authentication"))
                            {
                                AuthenTypeList.Add(garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim());
                            }
                            else if (garbagecan.ToLower().Contains("cipher"))
                            {
                                EncryptTypeList.Add(garbagecan.Substring(garbagecan.IndexOf(":") + 1).Trim());
                            }
                        }
                        else if (connectionstatus != "" && connectionstatus.Contains("disconnected"))
                        {
                            if (!EmptyPass)
                            {
                                EmptyPass = true;

                                NetworkNameList.Add("");
                                NetworkTypeList.Add("");
                                AuthenTypeList.Add("");
                                EncryptTypeList.Add("");
                                RadioTypeList.Add("");
                            }
                        }
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

        private void interfaceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadInformation(interfaceComboBox.SelectedItem.ToString());
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            refreshButton.Enabled = false;

            interfaceComboBox.Items.Clear();
            RadioTypeList.Clear();
            AuthenTypeList.Clear();
            EncryptTypeList.Clear();
            NetworkTypeList.Clear();
            NetworkNameList.Clear();
            InterfaceStatusList.Clear();
            InterfaceNameList.Clear();

            string[] InterfacesResults = LoadInterfaces();

            for (int ii = 0; ii < InterfacesResults.Length; ii++)
            {
                interfaceComboBox.Items.Add(InterfacesResults[ii].Trim());
                if (ii == 0)
                    interfaceComboBox.Text = InterfacesResults[ii].Trim();
            }

            ReadInformation(interfaceComboBox.Text);

            refreshButton.Enabled = true;
        }
    }
}
