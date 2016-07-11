namespace Netsh_Parser
{
    partial class AdHocManagerWin
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
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.otherPanel = new System.Windows.Forms.Panel();
            this.otherLinkLabel = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.selectPanel = new System.Windows.Forms.Panel();
            this.selectButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mainGroupBox = new System.Windows.Forms.GroupBox();
            this.networkListView = new System.Windows.Forms.ListView();
            this.ssidColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.authColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.selectComboBox = new System.Windows.Forms.GroupBox();
            this.interfaceComboBox = new System.Windows.Forms.ComboBox();
            this.bottomPanel.SuspendLayout();
            this.otherPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.selectPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.mainGroupBox.SuspendLayout();
            this.panel2.SuspendLayout();
            this.selectComboBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.otherPanel);
            this.bottomPanel.Controls.Add(this.panel1);
            this.bottomPanel.Controls.Add(this.selectPanel);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 210);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.bottomPanel.Size = new System.Drawing.Size(324, 41);
            this.bottomPanel.TabIndex = 0;
            // 
            // otherPanel
            // 
            this.otherPanel.Controls.Add(this.otherLinkLabel);
            this.otherPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.otherPanel.Location = new System.Drawing.Point(0, 5);
            this.otherPanel.Name = "otherPanel";
            this.otherPanel.Padding = new System.Windows.Forms.Padding(5);
            this.otherPanel.Size = new System.Drawing.Size(156, 36);
            this.otherPanel.TabIndex = 2;
            // 
            // otherLinkLabel
            // 
            this.otherLinkLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.otherLinkLabel.Location = new System.Drawing.Point(5, 5);
            this.otherLinkLabel.Name = "otherLinkLabel";
            this.otherLinkLabel.Size = new System.Drawing.Size(146, 26);
            this.otherLinkLabel.TabIndex = 0;
            this.otherLinkLabel.TabStop = true;
            this.otherLinkLabel.Text = "My network isn\'t listed...";
            this.otherLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.otherLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.otherLinkLabel_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.refreshButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(156, 5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(84, 36);
            this.panel1.TabIndex = 3;
            // 
            // refreshButton
            // 
            this.refreshButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.refreshButton.Location = new System.Drawing.Point(5, 5);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(74, 26);
            this.refreshButton.TabIndex = 0;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // selectPanel
            // 
            this.selectPanel.Controls.Add(this.selectButton);
            this.selectPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.selectPanel.Location = new System.Drawing.Point(240, 5);
            this.selectPanel.Name = "selectPanel";
            this.selectPanel.Padding = new System.Windows.Forms.Padding(5);
            this.selectPanel.Size = new System.Drawing.Size(84, 36);
            this.selectPanel.TabIndex = 1;
            // 
            // selectButton
            // 
            this.selectButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectButton.Location = new System.Drawing.Point(5, 5);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(74, 26);
            this.selectButton.TabIndex = 0;
            this.selectButton.Text = "Connect";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.mainGroupBox);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 57);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(7);
            this.mainPanel.Size = new System.Drawing.Size(324, 153);
            this.mainPanel.TabIndex = 1;
            // 
            // mainGroupBox
            // 
            this.mainGroupBox.Controls.Add(this.networkListView);
            this.mainGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainGroupBox.Location = new System.Drawing.Point(7, 7);
            this.mainGroupBox.Name = "mainGroupBox";
            this.mainGroupBox.Padding = new System.Windows.Forms.Padding(5);
            this.mainGroupBox.Size = new System.Drawing.Size(310, 139);
            this.mainGroupBox.TabIndex = 0;
            this.mainGroupBox.TabStop = false;
            this.mainGroupBox.Text = "Available Ad-hoc Networks";
            // 
            // networkListView
            // 
            this.networkListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ssidColumnHeader,
            this.authColumnHeader});
            this.networkListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.networkListView.FullRowSelect = true;
            this.networkListView.Location = new System.Drawing.Point(5, 18);
            this.networkListView.MultiSelect = false;
            this.networkListView.Name = "networkListView";
            this.networkListView.Size = new System.Drawing.Size(300, 116);
            this.networkListView.TabIndex = 0;
            this.networkListView.UseCompatibleStateImageBehavior = false;
            this.networkListView.View = System.Windows.Forms.View.Details;
            // 
            // ssidColumnHeader
            // 
            this.ssidColumnHeader.Text = "SSID";
            this.ssidColumnHeader.Width = 146;
            // 
            // authColumnHeader
            // 
            this.authColumnHeader.Text = "Authentication";
            this.authColumnHeader.Width = 150;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.selectComboBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(7);
            this.panel2.Size = new System.Drawing.Size(324, 57);
            this.panel2.TabIndex = 2;
            // 
            // selectComboBox
            // 
            this.selectComboBox.Controls.Add(this.interfaceComboBox);
            this.selectComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectComboBox.Location = new System.Drawing.Point(7, 7);
            this.selectComboBox.Name = "selectComboBox";
            this.selectComboBox.Padding = new System.Windows.Forms.Padding(5);
            this.selectComboBox.Size = new System.Drawing.Size(310, 43);
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
            this.interfaceComboBox.Size = new System.Drawing.Size(300, 21);
            this.interfaceComboBox.TabIndex = 0;
            this.interfaceComboBox.SelectedIndexChanged += new System.EventHandler(this.interfaceComboBox_SelectedIndexChanged);
            // 
            // AdHocManagerWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 251);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(340, 236);
            this.Name = "AdHocManagerWin";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ad-Hoc Connection Manager";
            this.Load += new System.EventHandler(this.AdHocManagerWin_Load);
            this.bottomPanel.ResumeLayout(false);
            this.otherPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.selectPanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.mainGroupBox.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.selectComboBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.GroupBox mainGroupBox;
        private System.Windows.Forms.Panel selectPanel;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Panel otherPanel;
        private System.Windows.Forms.LinkLabel otherLinkLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ListView networkListView;
        private System.Windows.Forms.ColumnHeader ssidColumnHeader;
        private System.Windows.Forms.ColumnHeader authColumnHeader;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox selectComboBox;
        private System.Windows.Forms.ComboBox interfaceComboBox;
    }
}