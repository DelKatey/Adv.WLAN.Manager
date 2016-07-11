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
    public partial class CurrModeWin : Form
    {
        public CurrModeWin()
        {
            InitializeComponent();
        }

        public CurrModeWin(string mode)
        {
            InitializeComponent();
            modeLabel.Text = mode.Substring(0,1).ToUpper() + mode.Substring(1).ToLower();
            mode = modeLabel.Text;
        }

        private string ReadMode()
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
            netsh.StandardInput.WriteLine("wlan");
            netsh.StandardInput.WriteLine("show mode");
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

        private void CurrModeWin_Load(object sender, EventArgs e)
        {
            string mode = ReadMode();
            modeLabel.Text = mode.Substring(0, 1).ToUpper() + mode.Substring(1).ToLower();
        }
    }
}
