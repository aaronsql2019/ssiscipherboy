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
    public partial class frmAssemblyAdministration : Form
    {
        public frmAssemblyAdministration()
        {
            InitializeComponent();
        }

        private void frmAssemblyAdministration_Load(object sender, EventArgs e)
        {
            txtDescription.Text = "#### SSISCipherUtil.dll is at the heart of this encryption routine which is embedded as a part of this executable. \r\n\r\n#### In order for the SSIS Script Task to load this assembly during runtime, this needs to be deployed in the GAC. \r\n\r\n#### If you encounter any assembly load failure errors, possible reasons are the SSISCipherUtil.dll is not available in the GAC or there is a version mismatch. \r\n\r\n#### Use the below options to administer the correct SSISCipherUtil.dll";
        }

        private void btnInstallDllToGAC_Click(object sender, EventArgs e)
        {
            try
            {
                AssemblyAdministration.WriteAssemblyAndInstall();
            }
            catch (Exception eX)
            {
                MessageBox.Show(text: eX.Message, caption: "Something went wrong!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void btnUninstallDllFromGAC_Click(object sender, EventArgs e)
        {
            try
            {
                AssemblyAdministration.WriteAssemblyAndUninstall();
            }
            catch (Exception eX)
            {
                MessageBox.Show(text: eX.Message, caption: "Something went wrong!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void btnEmitDllToWorkingDir_Click(object sender, EventArgs e)
        {
            try
            {
                AssemblyAdministration.WriteAssemblyToFile(AssemblyAdministration.targetAssemblyName);
                MessageBox.Show(text: "Assembly write success - " + AssemblyAdministration.targetAssemblyName, caption: "Success", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
            }
            catch (Exception eX)
            {
                MessageBox.Show(text: eX.Message, caption: "Something went wrong!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void btnEmitDllToSpecificLocation_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfdSaveDecryptorCode = new SaveFileDialog();
                sfdSaveDecryptorCode.Filter = "Assembly|*.dll";
                sfdSaveDecryptorCode.FileName = AssemblyAdministration.targetAssemblyName;
                DialogResult dr = sfdSaveDecryptorCode.ShowDialog();

                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    AssemblyAdministration.WriteAssemblyToFile(sfdSaveDecryptorCode.FileName);
                    MessageBox.Show(text: "Assembly write success - " + sfdSaveDecryptorCode.FileName, caption: "Success", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                }
            }

            catch (Exception eX)
            {
                MessageBox.Show(text: eX.Message, caption: "Something went wrong!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }






    }
}
