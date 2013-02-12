namespace SSISCipherBoy
{
    partial class frmAssemblyAdministration
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
            this.btnEmitDllToWorkingDir = new System.Windows.Forms.Button();
            this.btnEmitDllToSpecificLocation = new System.Windows.Forms.Button();
            this.btnInstallDllToGAC = new System.Windows.Forms.Button();
            this.btnUninstallDllFromGAC = new System.Windows.Forms.Button();
            this.gbGAC = new System.Windows.Forms.GroupBox();
            this.gbFileSystem = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.gbGAC.SuspendLayout();
            this.gbFileSystem.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEmitDllToWorkingDir
            // 
            this.btnEmitDllToWorkingDir.Location = new System.Drawing.Point(8, 19);
            this.btnEmitDllToWorkingDir.Name = "btnEmitDllToWorkingDir";
            this.btnEmitDllToWorkingDir.Size = new System.Drawing.Size(348, 23);
            this.btnEmitDllToWorkingDir.TabIndex = 0;
            this.btnEmitDllToWorkingDir.Text = "Emit SSISCipherUtil.dll to current working directory";
            this.btnEmitDllToWorkingDir.UseVisualStyleBackColor = true;
            this.btnEmitDllToWorkingDir.Click += new System.EventHandler(this.btnEmitDllToWorkingDir_Click);
            // 
            // btnEmitDllToSpecificLocation
            // 
            this.btnEmitDllToSpecificLocation.Location = new System.Drawing.Point(9, 48);
            this.btnEmitDllToSpecificLocation.Name = "btnEmitDllToSpecificLocation";
            this.btnEmitDllToSpecificLocation.Size = new System.Drawing.Size(347, 23);
            this.btnEmitDllToSpecificLocation.TabIndex = 1;
            this.btnEmitDllToSpecificLocation.Text = "Emit SSISCipherUtil.dll to a specifc location";
            this.btnEmitDllToSpecificLocation.UseVisualStyleBackColor = true;
            this.btnEmitDllToSpecificLocation.Click += new System.EventHandler(this.btnEmitDllToSpecificLocation_Click);
            // 
            // btnInstallDllToGAC
            // 
            this.btnInstallDllToGAC.Location = new System.Drawing.Point(9, 19);
            this.btnInstallDllToGAC.Name = "btnInstallDllToGAC";
            this.btnInstallDllToGAC.Size = new System.Drawing.Size(347, 23);
            this.btnInstallDllToGAC.TabIndex = 2;
            this.btnInstallDllToGAC.Text = "Install SSISCipherUtil.dll to GAC";
            this.btnInstallDllToGAC.UseVisualStyleBackColor = true;
            this.btnInstallDllToGAC.Click += new System.EventHandler(this.btnInstallDllToGAC_Click);
            // 
            // btnUninstallDllFromGAC
            // 
            this.btnUninstallDllFromGAC.Location = new System.Drawing.Point(9, 48);
            this.btnUninstallDllFromGAC.Name = "btnUninstallDllFromGAC";
            this.btnUninstallDllFromGAC.Size = new System.Drawing.Size(347, 23);
            this.btnUninstallDllFromGAC.TabIndex = 3;
            this.btnUninstallDllFromGAC.Text = "Uninstall SSISCipherUtil.dll from GAC";
            this.btnUninstallDllFromGAC.UseVisualStyleBackColor = true;
            this.btnUninstallDllFromGAC.Click += new System.EventHandler(this.btnUninstallDllFromGAC_Click);
            // 
            // gbGAC
            // 
            this.gbGAC.Controls.Add(this.btnInstallDllToGAC);
            this.gbGAC.Controls.Add(this.btnUninstallDllFromGAC);
            this.gbGAC.Location = new System.Drawing.Point(12, 197);
            this.gbGAC.Name = "gbGAC";
            this.gbGAC.Size = new System.Drawing.Size(371, 78);
            this.gbGAC.TabIndex = 4;
            this.gbGAC.TabStop = false;
            this.gbGAC.Text = "GAC Operations";
            // 
            // gbFileSystem
            // 
            this.gbFileSystem.Controls.Add(this.btnEmitDllToWorkingDir);
            this.gbFileSystem.Controls.Add(this.btnEmitDllToSpecificLocation);
            this.gbFileSystem.Location = new System.Drawing.Point(12, 289);
            this.gbFileSystem.Name = "gbFileSystem";
            this.gbFileSystem.Size = new System.Drawing.Size(371, 78);
            this.gbFileSystem.TabIndex = 5;
            this.gbFileSystem.TabStop = false;
            this.gbFileSystem.Text = "File System Operations";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(12, 13);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(371, 178);
            this.txtDescription.TabIndex = 6;
            // 
            // frmAssemblyAdministration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 377);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.gbFileSystem);
            this.Controls.Add(this.gbGAC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAssemblyAdministration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Assembly Administration";
            this.Load += new System.EventHandler(this.frmAssemblyAdministration_Load);
            this.gbGAC.ResumeLayout(false);
            this.gbFileSystem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEmitDllToWorkingDir;
        private System.Windows.Forms.Button btnEmitDllToSpecificLocation;
        private System.Windows.Forms.Button btnInstallDllToGAC;
        private System.Windows.Forms.Button btnUninstallDllFromGAC;
        private System.Windows.Forms.GroupBox gbGAC;
        private System.Windows.Forms.GroupBox gbFileSystem;
        private System.Windows.Forms.TextBox txtDescription;
    }
}