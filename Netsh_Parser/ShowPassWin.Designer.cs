namespace Netsh_Parser
{
    partial class ShowPassWin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.controlsPanel = new System.Windows.Forms.Panel();
            this.doneButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.passwordPanel = new System.Windows.Forms.Panel();
            this.namePanel = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.nameTB = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.controlsPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.passwordPanel.SuspendLayout();
            this.namePanel.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Password:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // controlsPanel
            // 
            this.controlsPanel.Controls.Add(this.doneButton);
            this.controlsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlsPanel.Location = new System.Drawing.Point(0, 73);
            this.controlsPanel.Name = "controlsPanel";
            this.controlsPanel.Size = new System.Drawing.Size(348, 34);
            this.controlsPanel.TabIndex = 1;
            // 
            // doneButton
            // 
            this.doneButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.doneButton.Location = new System.Drawing.Point(113, 6);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(90, 23);
            this.doneButton.TabIndex = 0;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 0, 3, 5);
            this.panel2.Size = new System.Drawing.Size(92, 34);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(89, 12);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Window;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(92, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(256, 10);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Window;
            this.panel5.Controls.Add(this.passwordTB);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(92, 10);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.panel5.Size = new System.Drawing.Size(256, 24);
            this.panel5.TabIndex = 4;
            // 
            // passwordTB
            // 
            this.passwordTB.BackColor = System.Drawing.Color.White;
            this.passwordTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.passwordTB.Location = new System.Drawing.Point(0, 0);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.ReadOnly = true;
            this.passwordTB.Size = new System.Drawing.Size(249, 20);
            this.passwordTB.TabIndex = 0;
            this.passwordTB.Text = "[Password Here]";
            // 
            // passwordPanel
            // 
            this.passwordPanel.BackColor = System.Drawing.SystemColors.Window;
            this.passwordPanel.Controls.Add(this.panel5);
            this.passwordPanel.Controls.Add(this.panel4);
            this.passwordPanel.Controls.Add(this.panel2);
            this.passwordPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.passwordPanel.Location = new System.Drawing.Point(0, 39);
            this.passwordPanel.Name = "passwordPanel";
            this.passwordPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.passwordPanel.Size = new System.Drawing.Size(348, 39);
            this.passwordPanel.TabIndex = 5;
            // 
            // namePanel
            // 
            this.namePanel.BackColor = System.Drawing.SystemColors.Window;
            this.namePanel.Controls.Add(this.panel6);
            this.namePanel.Controls.Add(this.panel7);
            this.namePanel.Controls.Add(this.panel8);
            this.namePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.namePanel.Location = new System.Drawing.Point(0, 0);
            this.namePanel.Name = "namePanel";
            this.namePanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.namePanel.Size = new System.Drawing.Size(348, 39);
            this.namePanel.TabIndex = 6;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Window;
            this.panel6.Controls.Add(this.nameTB);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(92, 10);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.panel6.Size = new System.Drawing.Size(256, 24);
            this.panel6.TabIndex = 4;
            // 
            // nameTB
            // 
            this.nameTB.BackColor = System.Drawing.Color.White;
            this.nameTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameTB.Location = new System.Drawing.Point(0, 0);
            this.nameTB.Name = "nameTB";
            this.nameTB.ReadOnly = true;
            this.nameTB.Size = new System.Drawing.Size(249, 20);
            this.nameTB.TabIndex = 0;
            this.nameTB.Text = "[Network Name Here]";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.Window;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(92, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(256, 10);
            this.panel7.TabIndex = 3;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.Window;
            this.panel8.Controls.Add(this.label2);
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(0, 0, 3, 5);
            this.panel8.Size = new System.Drawing.Size(92, 34);
            this.panel8.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(0, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Network:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(89, 12);
            this.panel9.TabIndex = 1;
            // 
            // ShowPassWin
            // 
            this.AcceptButton = this.doneButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(348, 107);
            this.ControlBox = false;
            this.Controls.Add(this.passwordPanel);
            this.Controls.Add(this.namePanel);
            this.Controls.Add(this.controlsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowPassWin";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Password for Selected Network";
            this.Load += new System.EventHandler(this.ShowPassWin_Load);
            this.controlsPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.passwordPanel.ResumeLayout(false);
            this.namePanel.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel controlsPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Panel passwordPanel;
        private System.Windows.Forms.Panel namePanel;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel9;
    }
}