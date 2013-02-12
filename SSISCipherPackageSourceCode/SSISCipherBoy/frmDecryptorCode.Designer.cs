namespace SSISCipherBoy
{
    partial class frmDecryptorCode
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbSaveOptions = new System.Windows.Forms.GroupBox();
            this.rdSaveAsPackage = new System.Windows.Forms.RadioButton();
            this.rdOverwitePackage = new System.Windows.Forms.RadioButton();
            this.btnStartPtocessingPackages = new System.Windows.Forms.Button();
            this.lblDragAndDrop = new System.Windows.Forms.Label();
            this.btnConnectionStringHelp = new System.Windows.Forms.Button();
            this.txtDecryptorCode = new System.Windows.Forms.TextBox();
            this.btnEditContents = new System.Windows.Forms.Button();
            this.btnSaveContentAs = new System.Windows.Forms.Button();
            this.btnCopyToClipboard = new System.Windows.Forms.Button();
            this.lbDropPackageHere = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.gbSaveOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbSaveOptions);
            this.panel1.Controls.Add(this.btnStartPtocessingPackages);
            this.panel1.Controls.Add(this.lblDragAndDrop);
            this.panel1.Controls.Add(this.btnConnectionStringHelp);
            this.panel1.Controls.Add(this.txtDecryptorCode);
            this.panel1.Controls.Add(this.btnEditContents);
            this.panel1.Controls.Add(this.btnSaveContentAs);
            this.panel1.Controls.Add(this.btnCopyToClipboard);
            this.panel1.Controls.Add(this.lbDropPackageHere);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1112, 478);
            this.panel1.TabIndex = 0;
            // 
            // gbSaveOptions
            // 
            this.gbSaveOptions.Controls.Add(this.rdSaveAsPackage);
            this.gbSaveOptions.Controls.Add(this.rdOverwitePackage);
            this.gbSaveOptions.Location = new System.Drawing.Point(12, 87);
            this.gbSaveOptions.Name = "gbSaveOptions";
            this.gbSaveOptions.Size = new System.Drawing.Size(437, 52);
            this.gbSaveOptions.TabIndex = 9;
            this.gbSaveOptions.TabStop = false;
            this.gbSaveOptions.Text = "Package Save Options";
            // 
            // rdSaveAsPackage
            // 
            this.rdSaveAsPackage.AutoSize = true;
            this.rdSaveAsPackage.Checked = true;
            this.rdSaveAsPackage.Location = new System.Drawing.Point(202, 29);
            this.rdSaveAsPackage.Name = "rdSaveAsPackage";
            this.rdSaveAsPackage.Size = new System.Drawing.Size(218, 17);
            this.rdSaveAsPackage.TabIndex = 9;
            this.rdSaveAsPackage.TabStop = true;
            this.rdSaveAsPackage.Text = "Save Modified package at same location";
            this.rdSaveAsPackage.UseVisualStyleBackColor = true;
            this.rdSaveAsPackage.CheckedChanged += new System.EventHandler(this.RadioCheckChangedPackage_CheckedChanged);
            // 
            // rdOverwitePackage
            // 
            this.rdOverwitePackage.AutoSize = true;
            this.rdOverwitePackage.Location = new System.Drawing.Point(28, 29);
            this.rdOverwitePackage.Name = "rdOverwitePackage";
            this.rdOverwitePackage.Size = new System.Drawing.Size(160, 17);
            this.rdOverwitePackage.TabIndex = 8;
            this.rdOverwitePackage.Text = "Overwrite Existing Packages";
            this.rdOverwitePackage.UseVisualStyleBackColor = true;
            this.rdOverwitePackage.CheckedChanged += new System.EventHandler(this.RadioCheckChangedPackage_CheckedChanged);
            // 
            // btnStartPtocessingPackages
            // 
            this.btnStartPtocessingPackages.Location = new System.Drawing.Point(3, 44);
            this.btnStartPtocessingPackages.Name = "btnStartPtocessingPackages";
            this.btnStartPtocessingPackages.Size = new System.Drawing.Size(446, 37);
            this.btnStartPtocessingPackages.TabIndex = 7;
            this.btnStartPtocessingPackages.Text = "Start Processing Below Packages";
            this.btnStartPtocessingPackages.UseVisualStyleBackColor = true;
            this.btnStartPtocessingPackages.Click += new System.EventHandler(this.btnStartPtocessingPackages_Click);
            // 
            // lblDragAndDrop
            // 
            this.lblDragAndDrop.AutoSize = true;
            this.lblDragAndDrop.BackColor = System.Drawing.Color.White;
            this.lblDragAndDrop.ForeColor = System.Drawing.Color.Gray;
            this.lblDragAndDrop.Location = new System.Drawing.Point(125, 293);
            this.lblDragAndDrop.Name = "lblDragAndDrop";
            this.lblDragAndDrop.Size = new System.Drawing.Size(0, 13);
            this.lblDragAndDrop.TabIndex = 6;
            this.lblDragAndDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblDragAndDrop_DragDrop);
            this.lblDragAndDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.lblDragAndDrop_DragEnter);
            this.lblDragAndDrop.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lblDragAndDrop_MouseDoubleClick);
            // 
            // btnConnectionStringHelp
            // 
            this.btnConnectionStringHelp.Location = new System.Drawing.Point(898, 3);
            this.btnConnectionStringHelp.Name = "btnConnectionStringHelp";
            this.btnConnectionStringHelp.Size = new System.Drawing.Size(209, 23);
            this.btnConnectionStringHelp.TabIndex = 4;
            this.btnConnectionStringHelp.Text = "Code sample for ConnectionString setting";
            this.btnConnectionStringHelp.UseVisualStyleBackColor = true;
            this.btnConnectionStringHelp.Click += new System.EventHandler(this.btnConnectionStringHelp_Click);
            // 
            // txtDecryptorCode
            // 
            this.txtDecryptorCode.Location = new System.Drawing.Point(455, 32);
            this.txtDecryptorCode.Multiline = true;
            this.txtDecryptorCode.Name = "txtDecryptorCode";
            this.txtDecryptorCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDecryptorCode.Size = new System.Drawing.Size(652, 442);
            this.txtDecryptorCode.TabIndex = 3;
            // 
            // btnEditContents
            // 
            this.btnEditContents.Location = new System.Drawing.Point(607, 3);
            this.btnEditContents.Name = "btnEditContents";
            this.btnEditContents.Size = new System.Drawing.Size(78, 23);
            this.btnEditContents.TabIndex = 2;
            this.btnEditContents.Text = "Edit contents";
            this.btnEditContents.UseVisualStyleBackColor = true;
            this.btnEditContents.Click += new System.EventHandler(this.btnEditContents_Click);
            // 
            // btnSaveContentAs
            // 
            this.btnSaveContentAs.Location = new System.Drawing.Point(691, 3);
            this.btnSaveContentAs.Name = "btnSaveContentAs";
            this.btnSaveContentAs.Size = new System.Drawing.Size(93, 23);
            this.btnSaveContentAs.TabIndex = 1;
            this.btnSaveContentAs.Text = "Save content as";
            this.btnSaveContentAs.UseVisualStyleBackColor = true;
            this.btnSaveContentAs.Click += new System.EventHandler(this.btnSaveContentAs_Click);
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.Location = new System.Drawing.Point(455, 3);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(146, 23);
            this.btnCopyToClipboard.TabIndex = 0;
            this.btnCopyToClipboard.Text = "Copy content to clipboard";
            this.btnCopyToClipboard.UseVisualStyleBackColor = true;
            this.btnCopyToClipboard.Click += new System.EventHandler(this.btnCopyToClipboard_Click);
            // 
            // lbDropPackageHere
            // 
            this.lbDropPackageHere.AllowDrop = true;
            this.lbDropPackageHere.FormattingEnabled = true;
            this.lbDropPackageHere.HorizontalScrollbar = true;
            this.lbDropPackageHere.Location = new System.Drawing.Point(3, 145);
            this.lbDropPackageHere.Name = "lbDropPackageHere";
            this.lbDropPackageHere.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbDropPackageHere.Size = new System.Drawing.Size(446, 329);
            this.lbDropPackageHere.TabIndex = 5;
            this.lbDropPackageHere.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbDropPackageHere_DragDrop);
            this.lbDropPackageHere.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbDropPackageHere_DragEnter);
            this.lbDropPackageHere.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbDropPackageHere_MouseDoubleClick);
            // 
            // frmDecryptorCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 478);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDecryptorCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DecryptorCode";
            this.Load += new System.EventHandler(this.frmDecryptorCode_Load);
            this.Shown += new System.EventHandler(this.frmDecryptorCode_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbSaveOptions.ResumeLayout(false);
            this.gbSaveOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDecryptorCode;
        private System.Windows.Forms.Button btnEditContents;
        private System.Windows.Forms.Button btnSaveContentAs;
        private System.Windows.Forms.Button btnCopyToClipboard;
        private System.Windows.Forms.Button btnConnectionStringHelp;
        private System.Windows.Forms.ListBox lbDropPackageHere;
        private System.Windows.Forms.Label lblDragAndDrop;
        private System.Windows.Forms.Button btnStartPtocessingPackages;
        private System.Windows.Forms.RadioButton rdOverwitePackage;
        private System.Windows.Forms.GroupBox gbSaveOptions;
        private System.Windows.Forms.RadioButton rdSaveAsPackage;

    }
}