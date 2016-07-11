using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Netsh_Parser
{
    public partial class AdHocSelectionScreen : Form
    {
        public AdHocSelectionScreen()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AdHocManagerWin objAdhocManager = new AdHocManagerWin();
            objAdhocManager.StartAdhocManager();

            this.Close();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            ConnectAdHocNetwork objConnectNetwork = new ConnectAdHocNetwork();
            objConnectNetwork.ConnectNetwork();

            this.Close();
        }
    }
}
