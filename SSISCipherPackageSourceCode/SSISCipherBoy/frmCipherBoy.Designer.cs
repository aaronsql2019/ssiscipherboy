namespace SSISCipherBoy
{
    partial class frmCipherBoy
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCipherBoy));
            this.txtXmlConfigFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowseXmlConfigFile = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageRSA = new System.Windows.Forms.TabPage();
            this.lblRSADescription = new System.Windows.Forms.Label();
            this.btnRSAGenerateDecryptorSource = new System.Windows.Forms.Button();
            this.btnRSACommitChanges = new System.Windows.Forms.Button();
            this.btnRSAImport = new System.Windows.Forms.Button();
            this.btnRSAExport = new System.Windows.Forms.Button();
            this.btnRSADecrypt = new System.Windows.Forms.Button();
            this.btnRSAEncrypt = new System.Windows.Forms.Button();
            this.btnRSALockUnlock = new System.Windows.Forms.Button();
            this.lblKeyContainerName = new System.Windows.Forms.Label();
            this.txtKeyContainerName = new System.Windows.Forms.TextBox();
            this.tabPageDPAPI = new System.Windows.Forms.TabPage();
            this.lblDPAPIDescription = new System.Windows.Forms.Label();
            this.btnDPAPIGenerateDecryptorSource = new System.Windows.Forms.Button();
            this.btnDPAPIDecrypt = new System.Windows.Forms.Button();
            this.btnDPAPILockUnlock = new System.Windows.Forms.Button();
            this.btnDPAPICommitChanges = new System.Windows.Forms.Button();
            this.btnDPAPIEncrypt = new System.Windows.Forms.Button();
            this.tvXmlConfigDisplay = new System.Windows.Forms.TreeView();
            this.ofdXmlConfigFile = new System.Windows.Forms.OpenFileDialog();
            this.ofdImportKeys = new System.Windows.Forms.OpenFileDialog();
            this.sfdExportKeys = new System.Windows.Forms.SaveFileDialog();
            this.btnLoadXmlConfigFile = new System.Windows.Forms.Button();
            this.btnUnloadXmlConfigFile = new System.Windows.Forms.Button();
            this.llblAssemblyAdministration = new System.Windows.Forms.LinkLabel();
            this.cmTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.miEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.llblAbout = new System.Windows.Forms.LinkLabel();
            this.llblHelp = new System.Windows.Forms.LinkLabel();
            this.lblDragDropHere = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageRSA.SuspendLayout();
            this.tabPageDPAPI.SuspendLayout();
            this.cmTreeView.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtXmlConfigFilePath
            // 
            this.txtXmlConfigFilePath.Location = new System.Drawing.Point(21, 25);
            this.txtXmlConfigFilePath.Name = "txtXmlConfigFilePath";
            this.txtXmlConfigFilePath.Size = new System.Drawing.Size(739, 20);
            this.txtXmlConfigFilePath.TabIndex = 1;
            this.txtXmlConfigFilePath.Text = "Input the full path of an SSIS XML config file or use the Browse button to pick o" +
                "r drag and drop inside the empty space";
            this.txtXmlConfigFilePath.TextChanged += new System.EventHandler(this.txtXmlConfigFilePath_TextChanged);
            this.txtXmlConfigFilePath.Enter += new System.EventHandler(this.txtXmlConfigFilePath_Enter);
            this.txtXmlConfigFilePath.Leave += new System.EventHandler(this.txtXmlConfigFilePath_Leave);
            // 
            // btnBrowseXmlConfigFile
            // 
            this.btnBrowseXmlConfigFile.Location = new System.Drawing.Point(771, 25);
            this.btnBrowseXmlConfigFile.Name = "btnBrowseXmlConfigFile";
            this.btnBrowseXmlConfigFile.Size = new System.Drawing.Size(137, 23);
            this.btnBrowseXmlConfigFile.TabIndex = 0;
            this.btnBrowseXmlConfigFile.Text = "Browse";
            this.btnBrowseXmlConfigFile.UseVisualStyleBackColor = true;
            this.btnBrowseXmlConfigFile.Click += new System.EventHandler(this.btnBrowseXmlConfigFile_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageRSA);
            this.tabControl1.Controls.Add(this.tabPageDPAPI);
            this.tabControl1.Location = new System.Drawing.Point(632, 81);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(280, 536);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPageRSA
            // 
            this.tabPageRSA.Controls.Add(this.lblRSADescription);
            this.tabPageRSA.Controls.Add(this.btnRSAGenerateDecryptorSource);
            this.tabPageRSA.Controls.Add(this.btnRSACommitChanges);
            this.tabPageRSA.Controls.Add(this.btnRSAImport);
            this.tabPageRSA.Controls.Add(this.btnRSAExport);
            this.tabPageRSA.Controls.Add(this.btnRSADecrypt);
            this.tabPageRSA.Controls.Add(this.btnRSAEncrypt);
            this.tabPageRSA.Controls.Add(this.btnRSALockUnlock);
            this.tabPageRSA.Controls.Add(this.lblKeyContainerName);
            this.tabPageRSA.Controls.Add(this.txtKeyContainerName);
            this.tabPageRSA.Location = new System.Drawing.Point(4, 22);
            this.tabPageRSA.Name = "tabPageRSA";
            this.tabPageRSA.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRSA.Size = new System.Drawing.Size(272, 510);
            this.tabPageRSA.TabIndex = 1;
            this.tabPageRSA.Text = "RSA";
            this.tabPageRSA.UseVisualStyleBackColor = true;
            // 
            // lblRSADescription
            // 
            this.lblRSADescription.AutoSize = true;
            this.lblRSADescription.Location = new System.Drawing.Point(6, 23);
            this.lblRSADescription.Name = "lblRSADescription";
            this.lblRSADescription.Size = new System.Drawing.Size(257, 104);
            this.lblRSADescription.TabIndex = 9;
            this.lblRSADescription.Text = resources.GetString("lblRSADescription.Text");
            // 
            // btnRSAGenerateDecryptorSource
            // 
            this.btnRSAGenerateDecryptorSource.Location = new System.Drawing.Point(9, 448);
            this.btnRSAGenerateDecryptorSource.Name = "btnRSAGenerateDecryptorSource";
            this.btnRSAGenerateDecryptorSource.Size = new System.Drawing.Size(247, 23);
            this.btnRSAGenerateDecryptorSource.TabIndex = 8;
            this.btnRSAGenerateDecryptorSource.Text = "Generate decryption code";
            this.btnRSAGenerateDecryptorSource.UseVisualStyleBackColor = true;
            this.btnRSAGenerateDecryptorSource.Click += new System.EventHandler(this.btnRSAGenerateDecryptorSource_Click);
            // 
            // btnRSACommitChanges
            // 
            this.btnRSACommitChanges.Location = new System.Drawing.Point(6, 408);
            this.btnRSACommitChanges.Name = "btnRSACommitChanges";
            this.btnRSACommitChanges.Size = new System.Drawing.Size(250, 23);
            this.btnRSACommitChanges.TabIndex = 7;
            this.btnRSACommitChanges.Text = "Commit changes to the config file";
            this.btnRSACommitChanges.UseVisualStyleBackColor = true;
            this.btnRSACommitChanges.Click += new System.EventHandler(this.btnRSACommitChanges_Click);
            // 
            // btnRSAImport
            // 
            this.btnRSAImport.Location = new System.Drawing.Point(135, 357);
            this.btnRSAImport.Name = "btnRSAImport";
            this.btnRSAImport.Size = new System.Drawing.Size(121, 23);
            this.btnRSAImport.TabIndex = 6;
            this.btnRSAImport.Text = "Import Rsa key pair";
            this.btnRSAImport.UseVisualStyleBackColor = true;
            this.btnRSAImport.Click += new System.EventHandler(this.btnRSAImport_Click);
            // 
            // btnRSAExport
            // 
            this.btnRSAExport.Location = new System.Drawing.Point(6, 357);
            this.btnRSAExport.Name = "btnRSAExport";
            this.btnRSAExport.Size = new System.Drawing.Size(123, 23);
            this.btnRSAExport.TabIndex = 5;
            this.btnRSAExport.Text = "Export Rsa key pair";
            this.btnRSAExport.UseVisualStyleBackColor = true;
            this.btnRSAExport.Click += new System.EventHandler(this.btnRSAExport_Click);
            // 
            // btnRSADecrypt
            // 
            this.btnRSADecrypt.Location = new System.Drawing.Point(135, 306);
            this.btnRSADecrypt.Name = "btnRSADecrypt";
            this.btnRSADecrypt.Size = new System.Drawing.Size(121, 23);
            this.btnRSADecrypt.TabIndex = 4;
            this.btnRSADecrypt.Text = "Decrypt";
            this.btnRSADecrypt.UseVisualStyleBackColor = true;
            this.btnRSADecrypt.Click += new System.EventHandler(this.btnRSADecrypt_Click);
            // 
            // btnRSAEncrypt
            // 
            this.btnRSAEncrypt.Location = new System.Drawing.Point(6, 306);
            this.btnRSAEncrypt.Name = "btnRSAEncrypt";
            this.btnRSAEncrypt.Size = new System.Drawing.Size(123, 23);
            this.btnRSAEncrypt.TabIndex = 3;
            this.btnRSAEncrypt.Text = "Encrypt";
            this.btnRSAEncrypt.UseVisualStyleBackColor = true;
            this.btnRSAEncrypt.Click += new System.EventHandler(this.btnRSAEncrypt_Click);
            // 
            // btnRSALockUnlock
            // 
            this.btnRSALockUnlock.Location = new System.Drawing.Point(6, 205);
            this.btnRSALockUnlock.Name = "btnRSALockUnlock";
            this.btnRSALockUnlock.Size = new System.Drawing.Size(250, 23);
            this.btnRSALockUnlock.TabIndex = 2;
            this.btnRSALockUnlock.Text = "Lock/Unlock Selection";
            this.btnRSALockUnlock.UseVisualStyleBackColor = true;
            this.btnRSALockUnlock.Click += new System.EventHandler(this.btnRSALockUnlock_Click);
            // 
            // lblKeyContainerName
            // 
            this.lblKeyContainerName.AutoSize = true;
            this.lblKeyContainerName.Location = new System.Drawing.Point(6, 257);
            this.lblKeyContainerName.Name = "lblKeyContainerName";
            this.lblKeyContainerName.Size = new System.Drawing.Size(107, 13);
            this.lblKeyContainerName.TabIndex = 1;
            this.lblKeyContainerName.Text = "Key Container Name:";
            // 
            // txtKeyContainerName
            // 
            this.txtKeyContainerName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKeyContainerName.Location = new System.Drawing.Point(116, 254);
            this.txtKeyContainerName.Name = "txtKeyContainerName";
            this.txtKeyContainerName.Size = new System.Drawing.Size(150, 20);
            this.txtKeyContainerName.TabIndex = 0;
            this.txtKeyContainerName.Text = "Allowed Chars: a-zA-Z0-9";
            this.txtKeyContainerName.TextChanged += new System.EventHandler(this.txtKeyContainerName_TextChanged);
            this.txtKeyContainerName.Enter += new System.EventHandler(this.txtKeyContainerName_Enter);
            this.txtKeyContainerName.Leave += new System.EventHandler(this.txtKeyContainerName_Leave);
            // 
            // tabPageDPAPI
            // 
            this.tabPageDPAPI.Controls.Add(this.lblDPAPIDescription);
            this.tabPageDPAPI.Controls.Add(this.btnDPAPIGenerateDecryptorSource);
            this.tabPageDPAPI.Controls.Add(this.btnDPAPIDecrypt);
            this.tabPageDPAPI.Controls.Add(this.btnDPAPILockUnlock);
            this.tabPageDPAPI.Controls.Add(this.btnDPAPICommitChanges);
            this.tabPageDPAPI.Controls.Add(this.btnDPAPIEncrypt);
            this.tabPageDPAPI.Location = new System.Drawing.Point(4, 22);
            this.tabPageDPAPI.Name = "tabPageDPAPI";
            this.tabPageDPAPI.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDPAPI.Size = new System.Drawing.Size(272, 510);
            this.tabPageDPAPI.TabIndex = 0;
            this.tabPageDPAPI.Text = "DPAPI";
            this.tabPageDPAPI.UseVisualStyleBackColor = true;
            // 
            // lblDPAPIDescription
            // 
            this.lblDPAPIDescription.AutoSize = true;
            this.lblDPAPIDescription.Location = new System.Drawing.Point(6, 18);
            this.lblDPAPIDescription.Name = "lblDPAPIDescription";
            this.lblDPAPIDescription.Size = new System.Drawing.Size(266, 130);
            this.lblDPAPIDescription.TabIndex = 10;
            this.lblDPAPIDescription.Text = resources.GetString("lblDPAPIDescription.Text");
            // 
            // btnDPAPIGenerateDecryptorSource
            // 
            this.btnDPAPIGenerateDecryptorSource.Location = new System.Drawing.Point(7, 445);
            this.btnDPAPIGenerateDecryptorSource.Name = "btnDPAPIGenerateDecryptorSource";
            this.btnDPAPIGenerateDecryptorSource.Size = new System.Drawing.Size(258, 23);
            this.btnDPAPIGenerateDecryptorSource.TabIndex = 4;
            this.btnDPAPIGenerateDecryptorSource.Text = "Generate decryption code";
            this.btnDPAPIGenerateDecryptorSource.UseVisualStyleBackColor = true;
            this.btnDPAPIGenerateDecryptorSource.Click += new System.EventHandler(this.btnDPAPIGenerateDecryptorSource_Click);
            // 
            // btnDPAPIDecrypt
            // 
            this.btnDPAPIDecrypt.Location = new System.Drawing.Point(146, 345);
            this.btnDPAPIDecrypt.Name = "btnDPAPIDecrypt";
            this.btnDPAPIDecrypt.Size = new System.Drawing.Size(100, 23);
            this.btnDPAPIDecrypt.TabIndex = 2;
            this.btnDPAPIDecrypt.Text = "Decrypt";
            this.btnDPAPIDecrypt.UseVisualStyleBackColor = true;
            this.btnDPAPIDecrypt.Click += new System.EventHandler(this.btnDPAPIDecrypt_Click);
            // 
            // btnDPAPILockUnlock
            // 
            this.btnDPAPILockUnlock.Location = new System.Drawing.Point(7, 281);
            this.btnDPAPILockUnlock.Name = "btnDPAPILockUnlock";
            this.btnDPAPILockUnlock.Size = new System.Drawing.Size(259, 23);
            this.btnDPAPILockUnlock.TabIndex = 0;
            this.btnDPAPILockUnlock.Text = "Lock/Unlock Selection";
            this.btnDPAPILockUnlock.UseVisualStyleBackColor = true;
            this.btnDPAPILockUnlock.Click += new System.EventHandler(this.btnDPAPILockUnlock_Click);
            // 
            // btnDPAPICommitChanges
            // 
            this.btnDPAPICommitChanges.Location = new System.Drawing.Point(6, 401);
            this.btnDPAPICommitChanges.Name = "btnDPAPICommitChanges";
            this.btnDPAPICommitChanges.Size = new System.Drawing.Size(259, 25);
            this.btnDPAPICommitChanges.TabIndex = 3;
            this.btnDPAPICommitChanges.Text = "Commit changes to the config file";
            this.btnDPAPICommitChanges.UseVisualStyleBackColor = true;
            this.btnDPAPICommitChanges.Click += new System.EventHandler(this.btnDPAPICommitChanges_Click);
            // 
            // btnDPAPIEncrypt
            // 
            this.btnDPAPIEncrypt.Location = new System.Drawing.Point(27, 345);
            this.btnDPAPIEncrypt.Name = "btnDPAPIEncrypt";
            this.btnDPAPIEncrypt.Size = new System.Drawing.Size(113, 23);
            this.btnDPAPIEncrypt.TabIndex = 1;
            this.btnDPAPIEncrypt.Text = "Encrypt";
            this.btnDPAPIEncrypt.UseVisualStyleBackColor = true;
            this.btnDPAPIEncrypt.Click += new System.EventHandler(this.btnDPAPIEncrypt_Click);
            // 
            // tvXmlConfigDisplay
            // 
            this.tvXmlConfigDisplay.AllowDrop = true;
            this.tvXmlConfigDisplay.CheckBoxes = true;
            this.tvXmlConfigDisplay.FullRowSelect = true;
            this.tvXmlConfigDisplay.Location = new System.Drawing.Point(21, 81);
            this.tvXmlConfigDisplay.Name = "tvXmlConfigDisplay";
            this.tvXmlConfigDisplay.Size = new System.Drawing.Size(605, 536);
            this.tvXmlConfigDisplay.TabIndex = 3;
            this.tvXmlConfigDisplay.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvXmlConfigDisplay_BeforeLabelEdit);
            this.tvXmlConfigDisplay.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvXmlConfigDisplay_AfterLabelEdit);
            this.tvXmlConfigDisplay.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvXmlConfigDisplay_AfterCheck);
            this.tvXmlConfigDisplay.Click += new System.EventHandler(this.tvXmlConfigDisplay_Click);
            this.tvXmlConfigDisplay.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvXmlConfigDisplay_DragDrop);
            this.tvXmlConfigDisplay.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvXmlConfigDisplay_DragEnter);
            this.tvXmlConfigDisplay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tvXmlConfigDisplay_MouseClick);
            // 
            // btnLoadXmlConfigFile
            // 
            this.btnLoadXmlConfigFile.Location = new System.Drawing.Point(21, 52);
            this.btnLoadXmlConfigFile.Name = "btnLoadXmlConfigFile";
            this.btnLoadXmlConfigFile.Size = new System.Drawing.Size(249, 23);
            this.btnLoadXmlConfigFile.TabIndex = 4;
            this.btnLoadXmlConfigFile.Text = "Load file in Tree View";
            this.btnLoadXmlConfigFile.UseVisualStyleBackColor = true;
            this.btnLoadXmlConfigFile.Click += new System.EventHandler(this.btnLoadXmlConfigFile_Click);
            // 
            // btnUnloadXmlConfigFile
            // 
            this.btnUnloadXmlConfigFile.Location = new System.Drawing.Point(276, 52);
            this.btnUnloadXmlConfigFile.Name = "btnUnloadXmlConfigFile";
            this.btnUnloadXmlConfigFile.Size = new System.Drawing.Size(246, 23);
            this.btnUnloadXmlConfigFile.TabIndex = 5;
            this.btnUnloadXmlConfigFile.Text = "Unload Tree View and Close File";
            this.btnUnloadXmlConfigFile.UseVisualStyleBackColor = true;
            this.btnUnloadXmlConfigFile.Click += new System.EventHandler(this.btnUnloadXmlConfigFile_Click);
            // 
            // llblAssemblyAdministration
            // 
            this.llblAssemblyAdministration.AutoSize = true;
            this.llblAssemblyAdministration.Location = new System.Drawing.Point(771, 62);
            this.llblAssemblyAdministration.Name = "llblAssemblyAdministration";
            this.llblAssemblyAdministration.Size = new System.Drawing.Size(131, 13);
            this.llblAssemblyAdministration.TabIndex = 6;
            this.llblAssemblyAdministration.TabStop = true;
            this.llblAssemblyAdministration.Text = "Assembly Administration ...";
            this.llblAssemblyAdministration.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblAssemblyAdministration_LinkClicked);
            // 
            // cmTreeView
            // 
            this.cmTreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCopy,
            this.miEdit});
            this.cmTreeView.Name = "cmTreeView";
            this.cmTreeView.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmTreeView.ShowImageMargin = false;
            this.cmTreeView.Size = new System.Drawing.Size(110, 48);
            // 
            // miCopy
            // 
            this.miCopy.Name = "miCopy";
            this.miCopy.Size = new System.Drawing.Size(109, 22);
            this.miCopy.Text = "Copy Value";
            this.miCopy.Click += new System.EventHandler(this.miCopy_Click);
            this.miCopy.MouseDown += new System.Windows.Forms.MouseEventHandler(this.miCopy_MouseDown);
            // 
            // miEdit
            // 
            this.miEdit.Name = "miEdit";
            this.miEdit.Size = new System.Drawing.Size(109, 22);
            this.miEdit.Text = "Edit Value";
            this.miEdit.Click += new System.EventHandler(this.miEdit_Click);
            // 
            // llblAbout
            // 
            this.llblAbout.AutoSize = true;
            this.llblAbout.LinkColor = System.Drawing.Color.Indigo;
            this.llblAbout.Location = new System.Drawing.Point(873, 0);
            this.llblAbout.Name = "llblAbout";
            this.llblAbout.Size = new System.Drawing.Size(35, 13);
            this.llblAbout.TabIndex = 7;
            this.llblAbout.TabStop = true;
            this.llblAbout.Text = "About";
            this.llblAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblAbout_LinkClicked);
            // 
            // llblHelp
            // 
            this.llblHelp.AutoSize = true;
            this.llblHelp.LinkColor = System.Drawing.Color.Indigo;
            this.llblHelp.Location = new System.Drawing.Point(838, 0);
            this.llblHelp.Name = "llblHelp";
            this.llblHelp.Size = new System.Drawing.Size(29, 13);
            this.llblHelp.TabIndex = 10;
            this.llblHelp.TabStop = true;
            this.llblHelp.Text = "Help";
            this.llblHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblHelp_LinkClicked);
            // 
            // lblDragDropHere
            // 
            this.lblDragDropHere.AutoSize = true;
            this.lblDragDropHere.BackColor = System.Drawing.Color.White;
            this.lblDragDropHere.ForeColor = System.Drawing.Color.Gray;
            this.lblDragDropHere.Location = new System.Drawing.Point(101, 332);
            this.lblDragDropHere.Name = "lblDragDropHere";
            this.lblDragDropHere.Size = new System.Drawing.Size(370, 13);
            this.lblDragDropHere.TabIndex = 11;
            this.lblDragDropHere.Text = "Drag and drop an SSIS XML config file here or use the Browse button to pick";
            // 
            // frmCipherBoy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 631);
            this.Controls.Add(this.lblDragDropHere);
            this.Controls.Add(this.llblHelp);
            this.Controls.Add(this.llblAbout);
            this.Controls.Add(this.txtXmlConfigFilePath);
            this.Controls.Add(this.llblAssemblyAdministration);
            this.Controls.Add(this.btnUnloadXmlConfigFile);
            this.Controls.Add(this.btnLoadXmlConfigFile);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tvXmlConfigDisplay);
            this.Controls.Add(this.btnBrowseXmlConfigFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmCipherBoy";
            this.Text = "SSISCipherBoy";
            this.Load += new System.EventHandler(this.frmCipherBoy_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageRSA.ResumeLayout(false);
            this.tabPageRSA.PerformLayout();
            this.tabPageDPAPI.ResumeLayout(false);
            this.tabPageDPAPI.PerformLayout();
            this.cmTreeView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtXmlConfigFilePath;
        private System.Windows.Forms.Button btnBrowseXmlConfigFile;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageRSA;
        private System.Windows.Forms.Button btnRSACommitChanges;
        private System.Windows.Forms.Button btnRSAImport;
        private System.Windows.Forms.Button btnRSAExport;
        private System.Windows.Forms.Button btnRSADecrypt;
        private System.Windows.Forms.Button btnRSAEncrypt;
        private System.Windows.Forms.Button btnRSALockUnlock;
        private System.Windows.Forms.Label lblKeyContainerName;
        private System.Windows.Forms.TextBox txtKeyContainerName;
        private System.Windows.Forms.TreeView tvXmlConfigDisplay;
        private System.Windows.Forms.OpenFileDialog ofdXmlConfigFile;
        private System.Windows.Forms.OpenFileDialog ofdImportKeys;
        private System.Windows.Forms.SaveFileDialog sfdExportKeys;
        private System.Windows.Forms.Button btnLoadXmlConfigFile;
        private System.Windows.Forms.TabPage tabPageDPAPI;
        private System.Windows.Forms.Button btnDPAPIDecrypt;
        private System.Windows.Forms.Button btnDPAPILockUnlock;
        private System.Windows.Forms.Button btnDPAPICommitChanges;
        private System.Windows.Forms.Button btnDPAPIEncrypt;
        private System.Windows.Forms.Button btnUnloadXmlConfigFile;
        private System.Windows.Forms.Button btnRSAGenerateDecryptorSource;
        private System.Windows.Forms.Button btnDPAPIGenerateDecryptorSource;
        private System.Windows.Forms.LinkLabel llblAssemblyAdministration;
        private System.Windows.Forms.ContextMenuStrip cmTreeView;
        private System.Windows.Forms.ToolStripMenuItem miCopy;
        private System.Windows.Forms.ToolStripMenuItem miEdit;
        private System.Windows.Forms.Label lblRSADescription;
        private System.Windows.Forms.Label lblDPAPIDescription;
        private System.Windows.Forms.LinkLabel llblAbout;
        private System.Windows.Forms.LinkLabel llblHelp;
        private System.Windows.Forms.Label lblDragDropHere;
    }
}

