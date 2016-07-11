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
    public partial class CreateAdHoc : Form
    {
        public CreateAdHoc()
        {
            InitializeComponent();
        }

        private void CreateAdHoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (nameTB.Text.Trim() != "")
                {
                    CreateAdHocManager.strUsername = nameTB.Text;
                    CreateAdHocManager.strPassword = passwordTB.Text;
                    CreateAdHocManager.strPersistency = persistencyCB.Text.ToLower();
                }
                else
                {
                    MessageBox.Show("You must provide a name (SSID) for your Ad-Hoc network!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }

                if (passwordTB.Text.Trim() != "")
                {
                    if (passwordTB.Text.Length <= 7)
                    {
                        MessageBox.Show("The password, if you wanted to set one, must be at least 8 characters!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                    
                }
            }
        }

        private void persistencyCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
