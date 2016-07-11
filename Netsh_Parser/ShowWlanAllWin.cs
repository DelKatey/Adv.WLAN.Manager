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
    public partial class ShowWlanAllWin : Form
    {
        private string ReadOutput = "";
        private bool ReadEnd = false;

        public ShowWlanAllWin()
        {
            InitializeComponent();
        }

        internal void ShowDetails()
        {
            timer1.Start();
            
            this.Cursor = Cursors.WaitCursor;
            displayRTB.Cursor = Cursors.WaitCursor;
            groupBox1.Cursor = Cursors.WaitCursor;

            backgroundWorker1.RunWorkerAsync();

            this.ShowDialog();
        }

        private string ShowAllWlan()
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
            netsh.StandardInput.WriteLine("wlan show all");
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

                for (int ii = 0; ii < OutputCache.Count; ii++)
                {
                    garbagecan = OutputCache[ii];

                    if (DelayRead == 0)
                    {
                        output.Add(garbagecan);
                    }
                    else
                        DelayRead--;
                }
            }

            string outputLine = "";

            for (int ii = 0; ii < output.Count; ii++)
            {
                if (!output[ii].Contains("netsh"))
                    outputLine += output[ii].Trim() + Environment.NewLine;
                else
                    outputLine = outputLine.Substring(0, outputLine.LastIndexOf(Environment.NewLine) - Environment.NewLine.Length);
            }

            return outputLine;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ReadOutput = ShowAllWlan();
            ReadEnd = true;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;
            displayRTB.Cursor = Cursors.Default;
            groupBox1.Cursor = Cursors.Default;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ReadEnd)
            {
                displayRTB.Text = ReadOutput;
                ReadOutput = "";
                timer1.Stop();
            }
        }

        private void ShowWlanAllWin_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(520, Screen.PrimaryScreen.Bounds.Height);
        }
    }
}
