using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SSISCipherBoy
{
    public partial class frmInputPackagePassword : Form
    {
        public frmInputPackagePassword()
        {
            InitializeComponent();
        }

        public string password = "";
        public string packageName = "";

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Password Cant be empty");
            }
            else
            {
                password = txtPassword.Text;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            this.Close();
        }

        private void frmInputPackagePassword_Load(object sender, EventArgs e)
        {
            lblText.Text = string.Format(lblText.Text, packageName);
            chkMaskPassword.Checked = true;   
        }

        private void chkMaskPassword_CheckedChanged(object sender, EventArgs e)
        {
            CheckState state = chkMaskPassword.CheckState;
            switch (state)
            {
                case CheckState.Checked:
                    {
                        this.txtPassword.UseSystemPasswordChar = true;
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        this.txtPassword.UseSystemPasswordChar = false;
                        break;
                    }
            }
        }
    }
}
