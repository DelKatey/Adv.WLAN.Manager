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
    public partial class ShowPassWin : Form
    {
        public ShowPassWin()
        {
            InitializeComponent();
        }

        internal void ShowPassword(string profileName, string password)
        {
            int WinHalfLength = (int)((float)controlsPanel.Size.Width / 2F);
            int Height = 6;

            int ButtonHalfLength = (int)((float)doneButton.Size.Width / 2F);

            int FinalX = WinHalfLength - ButtonHalfLength;

            doneButton.Location = new Point(FinalX, Height);

            passwordTB.Text = password;
            nameTB.Text = profileName.Trim();

            this.ShowDialog();
        }

        private void ShowPassWin_Load(object sender, EventArgs e)
        {
            //int WinHalfLength = (int)((float)controlsPanel.Size.Width / 2F);
            //int Height = 6;

            //int ButtonHalfLength = (int)((float)doneButton.Size.Width / 2F);

            //int FinalX = WinHalfLength - ButtonHalfLength;

            //doneButton.Location = new Point(FinalX, Height);
        }
    }
}
