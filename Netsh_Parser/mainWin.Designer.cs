namespace Netsh_Parser
{
    partial class mainWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainWin));
            this.topPanel = new System.Windows.Forms.Panel();
            this.loadingGroupBox = new System.Windows.Forms.GroupBox();
            this.loadStatusPanel = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.loadBtnPanel = new System.Windows.Forms.Panel();
            this.loadButton = new System.Windows.Forms.Button();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.detailsComboBox = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.viewButton = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.controlsSelectGroupBox = new System.Windows.Forms.GroupBox();
            this.controlsComboBox = new System.Windows.Forms.ComboBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.selectButton = new System.Windows.Forms.Button();
            this.profilesGroupBox = new System.Windows.Forms.GroupBox();
            this.profileList = new System.Windows.Forms.ListBox();
            this.listPanel = new System.Windows.Forms.Panel();
            this.topPanel.SuspendLayout();
            this.loadingGroupBox.SuspendLayout();
            this.loadStatusPanel.SuspendLayout();
            this.loadBtnPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.controlsSelectGroupBox.SuspendLayout();
            this.panel9.SuspendLayout();
            this.profilesGroupBox.SuspendLayout();
            this.listPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.loadingGroupBox);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.topPanel.Size = new System.Drawing.Size(414, 72);
            this.topPanel.TabIndex = 0;
            // 
            // loadingGroupBox
            // 
            this.loadingGroupBox.Controls.Add(this.loadStatusPanel);
            this.loadingGroupBox.Controls.Add(this.loadBtnPanel);
            this.loadingGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadingGroupBox.Location = new System.Drawing.Point(5, 7);
            this.loadingGroupBox.Name = "loadingGroupBox";
            this.loadingGroupBox.Size = new System.Drawing.Size(404, 58);
            this.loadingGroupBox.TabIndex = 0;
            this.loadingGroupBox.TabStop = false;
            this.loadingGroupBox.Text = "Loading";
            // 
            // loadStatusPanel
            // 
            this.loadStatusPanel.Controls.Add(this.statusLabel);
            this.loadStatusPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadStatusPanel.Location = new System.Drawing.Point(3, 16);
            this.loadStatusPanel.Name = "loadStatusPanel";
            this.loadStatusPanel.Padding = new System.Windows.Forms.Padding(7);
            this.loadStatusPanel.Size = new System.Drawing.Size(310, 39);
            this.loadStatusPanel.TabIndex = 1;
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.Color.White;
            this.statusLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLabel.Location = new System.Drawing.Point(7, 7);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(296, 25);
            this.statusLabel.TabIndex = 1;
            this.statusLabel.Text = "Profiles Unloaded. Click \"Load\" to begin loading data.";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loadBtnPanel
            // 
            this.loadBtnPanel.Controls.Add(this.loadButton);
            this.loadBtnPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.loadBtnPanel.Location = new System.Drawing.Point(313, 16);
            this.loadBtnPanel.Name = "loadBtnPanel";
            this.loadBtnPanel.Padding = new System.Windows.Forms.Padding(7);
            this.loadBtnPanel.Size = new System.Drawing.Size(88, 39);
            this.loadBtnPanel.TabIndex = 0;
            // 
            // loadButton
            // 
            this.loadButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadButton.Location = new System.Drawing.Point(7, 7);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(74, 25);
            this.loadButton.TabIndex = 0;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.groupBox1);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 279);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.bottomPanel.Size = new System.Drawing.Size(414, 55);
            this.bottomPanel.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.detailsComboBox);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(7, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 45);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details Selection View";
            // 
            // detailsComboBox
            // 
            this.detailsComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsComboBox.FormattingEnabled = true;
            this.detailsComboBox.Items.AddRange(new object[] {
            "Current Global Wireless LAN Settings",
            "Current Wireless LAN Mode",
            "View WLAN Status",
            "View Nearby Networks",
            "Wireless LAN Interfaces",
            "Wireless LAN Drivers",
            "All Information (Dump)",
            "About This Program"});
            this.detailsComboBox.Location = new System.Drawing.Point(3, 16);
            this.detailsComboBox.Name = "detailsComboBox";
            this.detailsComboBox.Size = new System.Drawing.Size(298, 21);
            this.detailsComboBox.TabIndex = 0;
            this.detailsComboBox.Text = "Select an option to view the associated details...";
            this.detailsComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.detailsComboBox_KeyPress);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(301, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 26);
            this.panel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.viewButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(311, 16);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.panel1.Size = new System.Drawing.Size(86, 26);
            this.panel1.TabIndex = 1;
            // 
            // viewButton
            // 
            this.viewButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewButton.Location = new System.Drawing.Point(0, 0);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(86, 23);
            this.viewButton.TabIndex = 0;
            this.viewButton.Text = "View";
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Click += new System.EventHandler(this.viewButton_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.controlsSelectGroupBox);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 334);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.panel7.Size = new System.Drawing.Size(414, 55);
            this.panel7.TabIndex = 5;
            // 
            // controlsSelectGroupBox
            // 
            this.controlsSelectGroupBox.Controls.Add(this.controlsComboBox);
            this.controlsSelectGroupBox.Controls.Add(this.panel8);
            this.controlsSelectGroupBox.Controls.Add(this.panel9);
            this.controlsSelectGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlsSelectGroupBox.Enabled = false;
            this.controlsSelectGroupBox.Location = new System.Drawing.Point(7, 5);
            this.controlsSelectGroupBox.Name = "controlsSelectGroupBox";
            this.controlsSelectGroupBox.Size = new System.Drawing.Size(400, 45);
            this.controlsSelectGroupBox.TabIndex = 0;
            this.controlsSelectGroupBox.TabStop = false;
            this.controlsSelectGroupBox.Text = "Controls Selection";
            // 
            // controlsComboBox
            // 
            this.controlsComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlsComboBox.FormattingEnabled = true;
            this.controlsComboBox.Items.AddRange(new object[] {
            "Create Ad-Hoc Network",
            "Connect Ad-Hoc Network",
            "Connect Infrastructure Network",
            "Disconnect WLAN From Network",
            "View Network Details",
            "Set as Preferred Network",
            "Show Password",
            "Forget Network",
            "Modify Connection Mode",
            "Export Network Profile",
            "Import Network Profile"});
            this.controlsComboBox.Location = new System.Drawing.Point(3, 16);
            this.controlsComboBox.Name = "controlsComboBox";
            this.controlsComboBox.Size = new System.Drawing.Size(298, 21);
            this.controlsComboBox.TabIndex = 0;
            this.controlsComboBox.Text = "Select an option to run the associated actions..";
            this.controlsComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.controlsComboBox_KeyPress);
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(301, 16);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(10, 26);
            this.panel8.TabIndex = 2;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.selectButton);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(311, 16);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.panel9.Size = new System.Drawing.Size(86, 26);
            this.panel9.TabIndex = 1;
            // 
            // selectButton
            // 
            this.selectButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectButton.Location = new System.Drawing.Point(0, 0);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(86, 23);
            this.selectButton.TabIndex = 0;
            this.selectButton.Text = "Select";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // profilesGroupBox
            // 
            this.profilesGroupBox.Controls.Add(this.profileList);
            this.profilesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profilesGroupBox.Location = new System.Drawing.Point(7, 7);
            this.profilesGroupBox.Name = "profilesGroupBox";
            this.profilesGroupBox.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.profilesGroupBox.Size = new System.Drawing.Size(400, 193);
            this.profilesGroupBox.TabIndex = 0;
            this.profilesGroupBox.TabStop = false;
            this.profilesGroupBox.Text = "Profiles List";
            // 
            // profileList
            // 
            this.profileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profileList.FormattingEnabled = true;
            this.profileList.Location = new System.Drawing.Point(5, 16);
            this.profileList.Name = "profileList";
            this.profileList.Size = new System.Drawing.Size(390, 174);
            this.profileList.TabIndex = 0;
            // 
            // listPanel
            // 
            this.listPanel.Controls.Add(this.profilesGroupBox);
            this.listPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listPanel.Location = new System.Drawing.Point(0, 72);
            this.listPanel.Name = "listPanel";
            this.listPanel.Padding = new System.Windows.Forms.Padding(7);
            this.listPanel.Size = new System.Drawing.Size(414, 207);
            this.listPanel.TabIndex = 2;
            // 
            // mainWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 389);
            this.Controls.Add(this.listPanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.panel7);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(430, 428);
            this.Name = "mainWin";
            this.Text = "Advanced WLAN Manager";
            this.topPanel.ResumeLayout(false);
            this.loadingGroupBox.ResumeLayout(false);
            this.loadStatusPanel.ResumeLayout(false);
            this.loadBtnPanel.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.controlsSelectGroupBox.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.profilesGroupBox.ResumeLayout(false);
            this.listPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.GroupBox loadingGroupBox;
        private System.Windows.Forms.Panel loadStatusPanel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Panel loadBtnPanel;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox detailsComboBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button viewButton;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.GroupBox controlsSelectGroupBox;
        private System.Windows.Forms.ComboBox controlsComboBox;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.GroupBox profilesGroupBox;
        private System.Windows.Forms.ListBox profileList;
        private System.Windows.Forms.Panel listPanel;
    }
}

