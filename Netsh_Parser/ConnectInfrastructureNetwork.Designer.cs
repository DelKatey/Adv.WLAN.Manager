namespace Netsh_Parser
{
    partial class ConnectInfrastructureNetwork
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
            this.selectPanel = new System.Windows.Forms.Panel();
            this.selectButton = new System.Windows.Forms.Button();
            this.selectComboBox = new System.Windows.Forms.GroupBox();
            this.interfaceComboBox = new System.Windows.Forms.ComboBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mainGroupBox = new System.Windows.Forms.GroupBox();
            this.networkListBox = new System.Windows.Forms.ListBox();
            this.selectPanel.SuspendLayout();
            this.selectComboBox.SuspendLayout();
            this.panel2.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.mainGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectPanel
            // 
            this.selectPanel.Controls.Add(this.selectButton);
            this.selectPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.selectPanel.Location = new System.Drawing.Point(190, 5);
            this.selectPanel.Name = "selectPanel";
            this.selectPanel.Padding = new System.Windows.Forms.Padding(5);
            this.selectPanel.Size = new System.Drawing.Size(178, 36);
            this.selectPanel.TabIndex = 1;
            // 
            // selectButton
            // 
            this.selectButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.selectButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectButton.Location = new System.Drawing.Point(5, 5);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(168, 26);
            this.selectButton.TabIndex = 0;
            this.selectButton.Text = "Connect";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // selectComboBox
            // 
            this.selectComboBox.Controls.Add(this.interfaceComboBox);
            this.selectComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectComboBox.Location = new System.Drawing.Point(7, 7);
            this.selectComboBox.Name = "selectComboBox";
            this.selectComboBox.Padding = new System.Windows.Forms.Padding(5);
            this.selectComboBox.Size = new System.Drawing.Size(354, 43);
            this.selectComboBox.TabIndex = 0;
            this.selectComboBox.TabStop = false;
            this.selectComboBox.Text = "Select Interface";
            // 
            // interfaceComboBox
            // 
            this.interfaceComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.interfaceComboBox.FormattingEnabled = true;
            this.interfaceComboBox.Location = new System.Drawing.Point(5, 18);
            this.interfaceComboBox.Name = "interfaceComboBox";
            this.interfaceComboBox.Size = new System.Drawing.Size(344, 21);
            this.interfaceComboBox.TabIndex = 0;
            // 
            // refreshButton
            // 
            this.refreshButton.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.refreshButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.refreshButton.Location = new System.Drawing.Point(5, 5);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(180, 26);
            this.refreshButton.TabIndex = 0;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.selectComboBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(7);
            this.panel2.Size = new System.Drawing.Size(368, 57);
            this.panel2.TabIndex = 8;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.panel1);
            this.bottomPanel.Controls.Add(this.selectPanel);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 220);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.bottomPanel.Size = new System.Drawing.Size(368, 41);
            this.bottomPanel.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.refreshButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(190, 36);
            this.panel1.TabIndex = 3;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.mainGroupBox);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 57);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(7);
            this.mainPanel.Size = new System.Drawing.Size(368, 163);
            this.mainPanel.TabIndex = 7;
            // 
            // mainGroupBox
            // 
            this.mainGroupBox.Controls.Add(this.networkListBox);
            this.mainGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainGroupBox.Location = new System.Drawing.Point(7, 7);
            this.mainGroupBox.Name = "mainGroupBox";
            this.mainGroupBox.Padding = new System.Windows.Forms.Padding(5);
            this.mainGroupBox.Size = new System.Drawing.Size(354, 149);
            this.mainGroupBox.TabIndex = 0;
            this.mainGroupBox.TabStop = false;
            this.mainGroupBox.Text = "Available Ad-hoc Networks";
            // 
            // networkListBox
            // 
            this.networkListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.networkListBox.FormattingEnabled = true;
            this.networkListBox.Location = new System.Drawing.Point(5, 18);
            this.networkListBox.Name = "networkListBox";
            this.networkListBox.Size = new System.Drawing.Size(344, 126);
            this.networkListBox.TabIndex = 0;
            // 
            // ConnectInfrastructureNetwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(368, 261);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(384, 300);
            this.Name = "ConnectInfrastructureNetwork";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Connect to Existing Infrastructure Network";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConnectInfrastructureNetwork_FormClosing);
            this.Load += new System.EventHandler(this.ConnectInfrastructureNetwork_Load);
            this.selectPanel.ResumeLayout(false);
            this.selectComboBox.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.mainGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel selectPanel;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.GroupBox selectComboBox;
        private System.Windows.Forms.ComboBox interfaceComboBox;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.GroupBox mainGroupBox;
        private System.Windows.Forms.ListBox networkListBox;
    }
}