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
    public partial class InterfaceSelection : Form
    {
        public InterfaceSelection()
        {
            InitializeComponent();
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

        internal DialogResult SelectInterface(out string result, string statusString)
        {
            statusLabel.Text = statusString;

            return SelectInterface(out result);
        }

        internal DialogResult SelectInterface(out string result)
        {
            DialogResult dResult;

            interfaceComboBox.Items.Clear();

            string[] InterfacesResults = LoadInterfaces();

            for (int ii = 0; ii < InterfacesResults.Length; ii++)
            {
                interfaceComboBox.Items.Add(InterfacesResults[ii].Trim());
                if (ii == 0)
                    interfaceComboBox.Text = InterfacesResults[ii].Trim();
            }

            if ((dResult = this.ShowDialog()) == DialogResult.OK)
                result = interfaceComboBox.Text;
            else
                result = "";

            return dResult;
        }



        internal string SelectInterface()
        {
            interfaceComboBox.Items.Clear();

            string[] InterfacesResults = LoadInterfaces();

            for (int ii = 0; ii < InterfacesResults.Length; ii++)
            {
                interfaceComboBox.Items.Add(InterfacesResults[ii].Trim());
                if (ii == 0)
                    interfaceComboBox.Text = InterfacesResults[ii].Trim();
            }

            if (this.ShowDialog() == DialogResult.OK)
                return interfaceComboBox.Text;
            else
                return "";
        }
    }
}
