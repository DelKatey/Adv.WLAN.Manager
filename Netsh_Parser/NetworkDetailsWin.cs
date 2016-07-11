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
    public partial class NetworkDetailsWin : Form
    {
        public NetworkDetailsWin()
        {
            InitializeComponent();
        }

        internal void ShowDetails(string profileName)
        {

            string[] NetworkInfo = ParseNetworkInfo(profileName);

            if (NetworkInfo.Length == 19) //Windows 8, 8.1
            {
                verTB.Text = NetworkInfo[0];
                typeTB.Text = NetworkInfo[1];
                nameTB.Text = NetworkInfo[2];

                modeTB.Text = NetworkInfo[3];
                broadcastTB.Text = NetworkInfo[4];
                autoswitchTB.Text = NetworkInfo[5];


                ssidNumberTB.Text = NetworkInfo[6];
                ssidNameTB.Text = NetworkInfo[7].Replace("\"", "");
                netTypeTB.Text = NetworkInfo[8];
                radioTypeTB.Text = NetworkInfo[9].Replace("[", "").Replace("]", "");


                authTB.Text = NetworkInfo[10];
                cipherTB.Text = NetworkInfo[11];
                keyTB.Text = NetworkInfo[12];


                costTB.Text = NetworkInfo[13];
                congestTB.Text = NetworkInfo[14];
                nearTB.Text = NetworkInfo[15];
                overTB.Text = NetworkInfo[16];
                roamTB.Text = NetworkInfo[17];
                costSourceTB.Text = NetworkInfo[18];

                randomMACTB.Text = "Not supported by Windows 8 and 8.1";
            }
            else if (NetworkInfo.Length == 20) //Windows 10
            {
                verTB.Text = NetworkInfo[0];
                typeTB.Text = NetworkInfo[1];
                nameTB.Text = NetworkInfo[2];

                modeTB.Text = NetworkInfo[3];
                broadcastTB.Text = NetworkInfo[4];
                autoswitchTB.Text = NetworkInfo[5];
                randomMACTB.Text = NetworkInfo[6];

                ssidNumberTB.Text = NetworkInfo[7];
                ssidNameTB.Text = NetworkInfo[8].Replace("\"", "");
                netTypeTB.Text = NetworkInfo[9];
                radioTypeTB.Text = NetworkInfo[10].Replace("[", "").Replace("]", "");


                authTB.Text = NetworkInfo[11];
                cipherTB.Text = NetworkInfo[12];
                keyTB.Text = NetworkInfo[13];


                costTB.Text = NetworkInfo[14];
                congestTB.Text = NetworkInfo[15];
                nearTB.Text = NetworkInfo[16];
                overTB.Text = NetworkInfo[17];
                roamTB.Text = NetworkInfo[18];
                costSourceTB.Text = NetworkInfo[19];
            }
            else //Windows 7
            {
                verTB.Text = NetworkInfo[0];
                typeTB.Text = NetworkInfo[1];
                nameTB.Text = NetworkInfo[2];

                modeTB.Text = NetworkInfo[3];
                broadcastTB.Text = NetworkInfo[4];
                autoswitchTB.Text = NetworkInfo[5];


                ssidNumberTB.Text = NetworkInfo[6];
                ssidNameTB.Text = NetworkInfo[7].Replace("\"", "");
                netTypeTB.Text = NetworkInfo[8];
                radioTypeTB.Text = NetworkInfo[9].Replace("[", "").Replace("]", "");


                authTB.Text = NetworkInfo[10];
                cipherTB.Text = NetworkInfo[11];
                keyTB.Text = NetworkInfo[12];

                costTB.Text = "Not supported by Windows 7";
                congestTB.Text = "Not supported by Windows 7";
                nearTB.Text = "Not supported by Windows 7";
                overTB.Text = "Not supported by Windows 7";
                roamTB.Text = "Not supported by Windows 7";
                costSourceTB.Text = "Not supported by Windows 7";

                randomMACTB.Text = "Not supported by Windows 7";
            }

            this.ShowDialog();
        }

        private string[] ParseNetworkInfo(string profileName)
        {
            string cmdLine = "wlan show profiles name=\"" + profileName.Trim() + "\"";

            List<string> result = new List<string>();

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
                    if (OutputCache[ii].ToLower().Contains("version"))
                    {
                        result.Add(OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim());
                    }
                    else if (OutputCache[ii].ToLower().Contains("connection mode"))
                    {
                        result.Add(OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim());
                    }
                    else if (OutputCache[ii].ToLower().Contains("network broadcast"))
                    {
                        result.Add(OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim());
                    }
                    else if (OutputCache[ii].ToLower().Contains("autoswitch"))
                    {
                        result.Add(OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim());
                    }
                    else if (OutputCache[ii].ToLower().Contains("network type"))
                    {
                        result.Add(OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim());
                    }
                    else if (OutputCache[ii].ToLower().Contains("radio type"))
                    {
                        result.Add(OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim());
                    }
                    else if (OutputCache[ii].ToLower().Contains("type"))
                    {
                        result.Add(OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim());
                    }
                    else if (OutputCache[ii].ToLower().Contains("ssid name"))
                    {
                        result.Add(OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim());
                    }
                    else if (OutputCache[ii].ToLower().Contains("name"))
                    {
                        result.Add(OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim());
                    }
                    else if (OutputCache[ii].ToLower().Contains("number of ssids"))
                    {
                        result.Add(OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim());
                    }
                    else if (OutputCache[ii].ToLower().Contains("authentication"))
                    {
                        result.Add(OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim());
                    }
                    else if (OutputCache[ii].ToLower().Contains("cipher"))
                    {
                        result.Add(OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim());
                    }
                    if (OutputCache[ii].ToLower().Contains("security key"))
                    {
                        result.Add(OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim());
                    }
                    else if (OutputCache[ii].ToLower().Contains("congested"))
                    {
                        result.Add(OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim());
                    }
                    else if (OutputCache[ii].ToLower().Contains("cost settings"))
                    { }
                    else if (OutputCache[ii].ToLower().Contains("cost source"))
                    {
                        result.Add(OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim());
                    }
                    else if (OutputCache[ii].ToLower().Contains("approaching data limit"))
                    {
                        result.Add(OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim());
                    }
                    else if (OutputCache[ii].ToLower().Contains("over data limit"))
                    {
                        result.Add(OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim());
                    }
                    else if (OutputCache[ii].ToLower().Contains("roaming"))
                    {
                        result.Add(OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim());
                    }
                    else if (OutputCache[ii].ToLower().Contains("cost"))
                    {
                        result.Add(OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim());
                    }
                    else if (OutputCache[ii].ToLower().Contains("mac randomization"))
                    {
                        result.Add(OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim());
                    }
                }
                else
                {
                    if (OutputCache[ii].ToLower().Contains("profile information"))
                        StartRead = true;
                }

            }

            return result.ToArray();
        }
    }
}
