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
    public partial class ImportProfileWin : Form
    {
        public ImportProfileWin()
        {
            InitializeComponent();
        }

        private void interfaceComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            if (loadProfileXmlFileDialog.ShowDialog() == DialogResult.OK)
            {
                profileFileTextBox.Text = loadProfileXmlFileDialog.FileName;
            }
        }

        private string ImportProfile(string InterfaceName, string fileName)
        {
            string cmdLine = "wlan add profile filename=\"" + fileName + "\"  interface=\"" + InterfaceName + "\" user=all";
            //wlan add profile filename="C:\Users\Student-ID\Documents\Visual Studio 2010\Projects\Netsh_Parser\Netsh_Parser\bin\Debug\Wi-Fi-Infernal.xml" interface="Wi-Fi" user=all
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

                for (int ii = 0; ii < OutputCache.Count; ii++)
                {
                    garbagecan = OutputCache[ii];

                    output.Add(garbagecan);
                }
            }

            string outputLine = "";

            for (int ii = 0; ii < 1; ii++)
            {
                outputLine += output[ii].Trim().Substring(output[ii].LastIndexOf('>') + 1).Trim();
            }

            return outputLine;
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

        internal DialogResult Import()
        {
            interfaceComboBox.Items.Clear();

            string[] InterfacesResults = LoadInterfaces();

            for (int ii = 0; ii < InterfacesResults.Length; ii++)
            {
                interfaceComboBox.Items.Add(InterfacesResults[ii].Trim());
                if (ii == 0)
                    interfaceComboBox.Text = InterfacesResults[ii].Trim();
            }

            return this.ShowDialog();
        }

        private void ImportProfileWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (profileFileTextBox.Text != String.Empty && File.Exists(profileFileTextBox.Text))
                    MessageBox.Show(ImportProfile(interfaceComboBox.Text, profileFileTextBox.Text), "Importing Profile...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("You cannot apply a non-existent profile!", "No Ghostbusters in Town!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }
    }
}
