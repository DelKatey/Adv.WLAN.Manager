using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace Netsh_Parser
{
    public partial class mainWin : Form
    {
        List<string> ErrorCache = new List<string>();

        public mainWin()
        {
            InitializeComponent();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadProfiles();
        }

        internal void LoadProfiles()
        {
            profileList.Items.Clear();

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
                    catch (Exception e)
                    {
                        garbagecan = "FA1L3d!";
                        ErrorCache.Add("Exception: " + e.Message);
                        ErrorCache.Add("Inner Msg: " + e.InnerException);
                        ErrorCache.Add("Stack Trace: " + e.StackTrace);
                        ErrorCache.Add("");
                    }

                    if (garbagecan != "FA1L3d" && garbagecan != null)
                        OutputCache.Add(garbagecan);
                    else
                    {
                        statusLabel.Text = "An error occured. Loading unsuccessful. Try again later.";
                        statusLabel.BackColor = Color.PaleVioletRed;
                        loadButton.Text = "Load";
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

            for (int ii = 0; ii < output.Count; ii++)
            {
                string outputLine = "";

                if (output[ii].ToLower().Contains("all user profile"))
                {
                    outputLine = output[ii].Substring(output[ii].IndexOf(':') + 1);
                }
                else
                    outputLine = output[ii];

                profileList.Items.Add(outputLine);
            }

            loadButton.Text = "Reload";
            statusLabel.Text = "Profiles has been loaded. To refresh data, click \"Reload\".";
            statusLabel.BackColor = Color.LightGreen;
            controlsSelectGroupBox.Enabled = true;
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (detailsComboBox.Text.ToString() == "Current Global Wireless LAN Settings")
                {
                    CurrWifiWin objCurrWifiSettings = new CurrWifiWin();
                    objCurrWifiSettings.ShowDialog();
                }
                else if (detailsComboBox.Text.ToString() == "Current Wireless LAN Mode")
                {
                    CurrModeWin objCurrMode = new CurrModeWin();
                    objCurrMode.ShowDialog();
                }
                else if (detailsComboBox.Text.ToString() == "Wireless LAN Interfaces")
                {
                    ShowWlanIntWin objWlanInterfaces = new ShowWlanIntWin();
                    objWlanInterfaces.ShowDetails();
                }
                else if (detailsComboBox.Text.ToString() == "Wireless LAN Drivers")
                {
                    ShowWlanDriversWin objWlanDrivers = new ShowWlanDriversWin();
                    objWlanDrivers.ShowDetails();
                }
                else if (detailsComboBox.Text.ToString() == "All Information (Dump)")
                {
                    ShowWlanAllWin objWlanAll = new ShowWlanAllWin();
                    objWlanAll.ShowDetails();
                }
                else if (detailsComboBox.Text.ToString() == "About This Program")
                {
                    AboutWin objAbout = new AboutWin();
                    objAbout.ShowDialog();
                }
                else if (detailsComboBox.Text.ToString() == "View WLAN Status")
                {
                    ConnectionStatus objStatus = new ConnectionStatus();
                    objStatus.CheckConnectionStatus();
                }
                else if (detailsComboBox.Text.ToString() == "View Nearby Networks")
                {
                    SignalStrAnalyser objSignals = new SignalStrAnalyser();
                    objSignals.ViewDetails();
                }
                else
                    MessageBox.Show("You must select an option first! You jerk.", "Nothing Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //catch (Exception ee) { ErrorBox objError = new ErrorBox(); objError.Show("Initial Exception: " + ee.Message + Environment.NewLine + Environment.NewLine + "Source: " + ee.Source + Environment.NewLine + Environment.NewLine + "Stack Trace: " + ee.StackTrace + Environment.NewLine + Environment.NewLine + "Inner Exception: " + ee.InnerException); } //MessageBox.Show("You must select an option first! You jerk.", "Nothing Selected", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (profileList.SelectedIndex != -1)
            {
                if (MessageBox.Show("Are you sure you want to delete the selected network?", "Deleting Network...", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
                    MessageBox.Show(ForgetNetwork(profileList.SelectedItem.ToString().Trim()), "Results of Network Profile Removal", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Please select a network and try again!", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);

            LoadProfiles();
        }

        private string ForgetNetwork(string profileName)
        {
            string cmdLine = "wlan delete profile name=\"" + profileName.Trim() + "\"";

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

            result = netsh.StandardOutput.ReadLine().Substring("netsh>".Length);

            return result;
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            if (profileList.SelectedIndex != -1)
            {
                if (MessageBox.Show("Are you sure you want to set the selected network as the preferred network (as in #1)?", "Changing Network Priority...", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
                    MessageBox.Show(SetAsPreferredNetwork(profileList.SelectedItem.ToString()), "Results of Network Prioritization", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Please select a network and try again!", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private string SetAsPreferredNetwork(string profileName)
        {
            string tempInterface = "";
            InterfaceSelection objSelect = new InterfaceSelection();

            if (objSelect.SelectInterface(out tempInterface, "Please select below the interface that you wish to set the preferred network for.") == DialogResult.OK)
            {
                string cmdLine = "wlan set profileorder name=\"" + profileName.Trim() + "\" interface=\"" + tempInterface + "\" priority=1";

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

                result = netsh.StandardOutput.ReadLine().Substring("netsh>".Length);

                return result;
            }
            else
                return null;
        }

        private void plaintextButton_Click(object sender, EventArgs e)
        {
            ShowPassWin objShowPass = new ShowPassWin();

            if (profileList.SelectedIndex != -1)
            {
                objShowPass.ShowPassword(profileList.SelectedItem.ToString().Trim(), ViewStoredPasswordInPlaintext(profileList.SelectedItem.ToString()));

                //MessageBox.Show("Password for " + profileList.SelectedItem.ToString().Trim() + ": " + ViewStoredPasswordInPlaintext(profileList.SelectedItem.ToString()), profileList.SelectedItem.ToString().Trim() + "'s password", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Please select a network and try again!", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private string ViewStoredPasswordInPlaintext(string profileName)
        {
            string cmdLine = "wlan show profiles name=\"" + profileName.Trim() + "\" key=clear";

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
                if (OutputCache[ii].ToLower().Contains("key content"))
                {
                    result = OutputCache[ii].Substring(OutputCache[ii].IndexOf(':') + 1).Trim();
                }
            }

            return result;
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            NetworkDetailsWin objNetDetails = new NetworkDetailsWin();

            if (profileList.SelectedIndex != -1)
            {
                objNetDetails.ShowDetails(profileList.SelectedItem.ToString().Trim());
            }
            else
                MessageBox.Show("Please select a network and try again!", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AdHocSelectionScreen objSelection = new AdHocSelectionScreen();
            objSelection.ShowDialog();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            CreateAdHocManager objCreate = new CreateAdHocManager();
            //objCreate.CreateAdhocNetwork();
            objCreate.ShowNormally();
        }

        private string ModifyConnectionMode(string profileName, string mode)
        {
            string cmdLine = "netsh wlan set profileparameter name=\"" + profileName + "\" connectionmode=" + mode;

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

            result = netsh.StandardOutput.ReadLine().Substring("netsh>".Length);

            return result;
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (controlsComboBox.Text.ToString() == "Create Ad-Hoc Network")
                {
                    MessageBox.Show("You will need to give approval to most of the actions in the next few screens.", "Admin Approval Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CreateAdHocManager objCreate = new CreateAdHocManager();
                    objCreate.ShowNormally();

                    //createButton
                }
                else if (controlsComboBox.Text.ToString() == "Connect Ad-Hoc Network")
                {
                    AdHocSelectionScreen objSelection = new AdHocSelectionScreen();
                    objSelection.ShowDialog();

                    LoadProfiles();
                    //addButton
                }
                else if (controlsComboBox.Text.ToString() == "View Network Details")
                {
                    NetworkDetailsWin objNetDetails = new NetworkDetailsWin();

                    if (profileList.SelectedIndex != -1)
                    {
                        objNetDetails.ShowDetails(profileList.SelectedItem.ToString().Trim());
                    }
                    else
                        MessageBox.Show("Please select a network and try again!", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //readButton
                }
                else if (controlsComboBox.Text.ToString() == "Set as Preferred Network")
                {
                    if (profileList.SelectedIndex != -1)
                    {
                        string tempResult = "";
                        if (MessageBox.Show("Are you sure you want to set the selected network as the preferred network (as in #1)?", "Changing Network Priority...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            tempResult = SetAsPreferredNetwork(profileList.SelectedItem.ToString());
                            
                        if (tempResult == null)
                            tempResult = "You cancelled the change.";
                        else if (tempResult.Trim() == "")
                            tempResult = "You cancelled the change.";

                        MessageBox.Show(tempResult, "Results of Network Prioritization", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Please select a network and try again!", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //setButton
                }
                else if (controlsComboBox.Text.ToString() == "Show Password")
                {
                    ShowPassWin objShowPass = new ShowPassWin();

                    if (profileList.SelectedIndex != -1)
                    {
                        objShowPass.ShowPassword(profileList.SelectedItem.ToString().Trim(), ViewStoredPasswordInPlaintext(profileList.SelectedItem.ToString()));

                        //MessageBox.Show("Password for " + profileList.SelectedItem.ToString().Trim() + ": " + ViewStoredPasswordInPlaintext(profileList.SelectedItem.ToString()), profileList.SelectedItem.ToString().Trim() + "'s password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Please select a network and try again!", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //plaintextButton
                }
                else if (controlsComboBox.Text.ToString() == "Forget Network")
                {
                    if (profileList.SelectedIndex != -1)
                    {
                        if (MessageBox.Show("Are you sure you want to delete the selected network?", "Deleting Network...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            MessageBox.Show(ForgetNetwork(profileList.SelectedItem.ToString().Trim()), "Results of Network Profile Removal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Please select a network and try again!", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    LoadProfiles();

                    //deleteButton
                }
                else if (controlsComboBox.Text.ToString() == "Modify Connection Mode")
                {
                    string mode = "";
                    if (profileList.SelectedIndex != -1)
                    {
                        if (MessageBox.Show("Do you want the network, " + profileList.SelectedItem.ToString() + ", to be connected to automatically?" + Environment.NewLine + Environment.NewLine + "Click \"Yes\" for Automatic, or \"No\" for Manual.", "Connection Mode", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            mode = "auto";
                        else
                            mode = "manual";

                        MessageBox.Show(ModifyConnectionMode(profileList.SelectedItem.ToString(), mode), "Results of Connection Mode Change", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Please select a network and try again!", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //modify
                }
                else if (controlsComboBox.Text.ToString() == "Export Network Profile")
                {
                    if (profileList.SelectedIndex != -1)
                    {

                        if (MessageBox.Show("Are you sure you want to export the network profile for " + profileList.SelectedItem.ToString().Trim() + "?", "Exporting Profile...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            MessageBox.Show(ExportNetworkProfile(profileList.SelectedItem.ToString()), "Exporting Profile...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        MessageBox.Show("Please select a network and try again!", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (controlsComboBox.Text.ToString() == "Import Network Profile")
                {
                    ImportProfileWin objImportProfile = new ImportProfileWin();

                    if (objImportProfile.Import() == DialogResult.OK)
                        LoadProfiles();
                }
                else if (controlsComboBox.Text.ToString() == "Disconnect WLAN From Network")
                {
                    DisconnectFromNetwork();
                }
                else if (controlsComboBox.Text.ToString() == "Connect Infrastructure Network")
                {
                    ConnectInfrastructureNetwork objConnectInfra = new ConnectInfrastructureNetwork();
                    objConnectInfra.ConnectNetwork();
                }
                else
                    MessageBox.Show("You must select an option first! You jerk.", "Nothing Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ee) { ErrorBox objError = new ErrorBox(); objError.Show("Initial Exception: " + ee.Message + Environment.NewLine + Environment.NewLine + "Source: " + ee.Source + Environment.NewLine + Environment.NewLine + "Stack Trace: " + ee.StackTrace + Environment.NewLine + Environment.NewLine + "Inner Exception: " + ee.InnerException); } //MessageBox.Show("You must select an option first! You jerk.", "Nothing Selected", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void DisconnectFromNetwork()
        {
            InterfaceSelection objInterface = new InterfaceSelection();

            string interfaceName = "";

            objInterface.SelectInterface(out interfaceName, "Please select below the interface which you wish to disconnect from its network.");

            if (interfaceName == "")
            {
                MessageBox.Show("Operation cancelled!", "Disconnecting from Network...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string cmdLine = "wlan disconnect interface=\"" + interfaceName + "\"";

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

                string ResultLine = "";

                if (OutputCache[0].Substring("netsh>".Length).Trim() != "")
                    ResultLine = OutputCache[0].Substring("netsh>".Length).Trim();
                else
                    ResultLine = "The WLAN interface was not connected to any networks, so there was nothing to disconnect it from. Please don't waste ours and your time. Geez.";

                MessageBox.Show(ResultLine, "Disonnecting from Network...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string ExportNetworkProfile(string profileName)
        {
            string result = "";

            string cmdLine = "wlan export profile name=\"" + profileName.Trim() + "\"";

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
            result = netsh.StandardOutput.ReadLine();
            result = netsh.StandardOutput.ReadLine();

            return result;
        }

        private void detailsComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                viewButton.PerformClick();
            }
            else if (e.KeyChar == (char)Keys.Up || e.KeyChar == (char)Keys.Down)
            {

            }
            else
                e.Handled = true;
        }

        private void controlsComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                selectButton.PerformClick();
            }
            else if (e.KeyChar == (char)Keys.Up || e.KeyChar == (char)Keys.Down)
            {

            }
            else
                e.Handled = true;
        }
    }
}

// References:
//
// How to forget a WiFi Network in Windows 8:
// http://www.fixedbyvonnie.com/2013/06/how-to-forget-a-wifi-network-in-windows-8/#.UnZSlHCnqR4
//
// Revealing your WLAN password using netsh:
// http://poweradmin.se/blog/2010/03/14/revealing-your-wlan-password-using-netsh-and-powershell/
//
// Restrict only width for WinForms
// http://stackoverflow.com/questions/13527142/is-it-possible-to-set-the-maximum-width-for-a-form-but-leave-the-maximum-height
//
// View Wireless Networks
// http://www.etherhex.com/2013/01/using-netsh-for-viewing-wireless-networks/
//
// How to create wireless Ad-Hoc Internet Connection in Windows 8
// http://www.addictivetips.com/windows-tips/how-to-create-wireless-ad-hoc-internet-connection-in-windows-8/
//
// Show, Start, and Stop HostedNetwork
// http://stackoverflow.com/questions/18431634/netsh-wlan-start-hostednetwork-command-not-working-no-matter-what-i-try
//
// About the Wireless Hosted Network
// https://msdn.microsoft.com/en-us/library/dd815243%28VS.85%29.aspx?f=255&MSPPError=-2147217396
//
// How do I clear/delete hostednetwork configuration
// https://social.technet.microsoft.com/Forums/office/en-US/25c9bae5-7aa5-4361-99d0-26e734820a6c/how-do-i-clear-delete-hostednetwork-configuration?forum=w8itpronetworking
//
// Using Netsh Commands for Wi-Fi Management in Windows 8
// http://www.serverwatch.com/server-tutorials/using-netsh-commands-for-wi-fi-management-in-windows-8.html
//
//
//