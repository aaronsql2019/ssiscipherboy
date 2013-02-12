namespace SSISCipherBoy
{
    partial class frmInputPackagePassword
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
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.lblText = new System.Windows.Forms.Label();
            this.chkMaskPassword = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(93, 35);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(238, 20);
            this.txtPassword.TabIndex = 0;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(4, 38);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(83, 13);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Input Password:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(4, 61);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(176, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(186, 61);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(191, 23);
            this.btnDone.TabIndex = 1;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(4, 9);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(244, 13);
            this.lblText.TabIndex = 4;
            this.lblText.Text = "Seems like the package {0} is password protected";
            // 
            // chkMaskPassword
            // 
            this.chkMaskPassword.AutoSize = true;
            this.chkMaskPassword.Location = new System.Drawing.Point(337, 38);
            this.chkMaskPassword.Name = "chkMaskPassword";
            this.chkMaskPassword.Size = new System.Drawing.Size(52, 17);
            this.chkMaskPassword.TabIndex = 2;
            this.chkMaskPassword.Text = "Mask";
            this.chkMaskPassword.UseVisualStyleBackColor = true;
            this.chkMaskPassword.CheckedChanged += new System.EventHandler(this.chkMaskPassword_CheckedChanged);
            // 
            // frmInputPackagePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 90);
            this.Controls.Add(this.chkMaskPassword);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInputPackagePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Package is password protected";
            this.Load += new System.EventHandler(this.frmInputPackagePassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.CheckBox chkMaskPassword;
    }
}