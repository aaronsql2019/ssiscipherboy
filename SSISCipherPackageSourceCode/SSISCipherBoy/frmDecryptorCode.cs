using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace SSISCipherBoy
{
    public partial class frmDecryptorCode : Form
    {
        #region instance members

        private List<FileInfo> packageList = new List<FileInfo>();
        private string decryptorCode = default(string);

        #endregion

        #region event handlers

        public frmDecryptorCode()
        {
            InitializeComponent();
        }

        private void frmDecryptorCode_Load(object sender, EventArgs e)
        {
            lblDragAndDrop.Text = "Drag and Drop SSIS Packages here" + Environment.NewLine + "double click to Browse";
            lblDragAndDrop.TextAlign = ContentAlignment.MiddleCenter;
            try
            {
                string temp = GetScriptMainDotCsCode();
                StringBuilder refParameter = new StringBuilder().Append(temp);
                decryptorCode = SSISCipherUtil.DecryptionCodeEntityCollection.ReplaceScriptMainDotCs(frmCipherBoy.decryptorCode, ref refParameter);

                txtDecryptorCode.Text = decryptorCode;
                txtDecryptorCode.ReadOnly = true;
            }
            catch (Exception eX)
            {
                MessageBox.Show(text: eX.Message, caption: "Something went wrong!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, txtDecryptorCode.Text);
        }

        private void btnEditContents_Click(object sender, EventArgs e)
        {
            txtDecryptorCode.ReadOnly = false;
        }

        private void btnSaveContentAs_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfdSaveDecryptorCode = new SaveFileDialog();
                sfdSaveDecryptorCode.Filter = "Text File|*.txt|All Files|*.*";
                DialogResult dr = sfdSaveDecryptorCode.ShowDialog();

                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    SSISCipherUtil.Utils.WriteStringToFile(txtDecryptorCode.Text, sfdSaveDecryptorCode.FileName);
                    MessageBox.Show(text: "Contents written to file.", caption: "Success", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                }
            }

            catch (Exception eX)
            {
                MessageBox.Show(text: eX.Message, caption: "Something went wrong!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void btnConnectionStringHelp_Click(object sender, EventArgs e)
        {
            if (btnConnectionStringHelp.Text == "Remove ConnectionString setting help")
            {
                txtDecryptorCode.Text = decryptorCode.Replace("\n", Environment.NewLine);
                btnConnectionStringHelp.Text = "Code sample for ConnectionString setting";
            }
            else
            {
                string connStrDirectSetting = "//Once the ConnectionString value is decrypted from the config file, just set it right back" 
                    + Environment.NewLine + "//and it will be available automatically outside of the Script Task."
                    + Environment.NewLine + "Dts.Connections[\"ConnectionName\"].ConnectionString = decryptedConnectionString;";

                string connStringViaAcquireConnection = "//or you may also choose to perform some operation using the connection string on the script task itself" 
                    + Environment.NewLine + "//via the regular AcquireConnection method like below"
                    + Environment.NewLine + "SqlConnection connection = Dts.Connections[\"ConnectionName\"].AcquireConnection(null) as SqlConnection;" 
                    + Environment.NewLine + "connection.Open();";

                string connStringIndivPropValues = "//or you may also choose to update the individual properties of a Connection Manager as below"
                    + Environment.NewLine + "ConnectionManager ftpConnectionManager = Dts.Connections[\"FTP Connection Manager\"];"
                    + Environment.NewLine + "ftpConnectionManager.Properties[\"ServerName\"].SetValue(ftpConnectionManager, ftpServerName);"
                    + Environment.NewLine + "ftpConnectionManager.Properties[\"ServerPort\"].SetValue(ftpConnectionManager, ftpServerPort);"
                    + Environment.NewLine + "ftpConnectionManager.Properties[\"ServerUserName\"].SetValue(ftpConnectionManager, ftpServerUserName);"
                    + Environment.NewLine + Environment.NewLine
                    + Environment.NewLine + "ConnectionManager odbcConnectionManager = Dts.Connections[\"AdventureWorksConn\"];"
                    + Environment.NewLine + "odbcConnectionManager.Properties[\"ServerName\"].SetValue(odbcConnectionManager, sqlServerName);"
                    + Environment.NewLine + "odbcConnectionManager.Properties[\"InitialCatalog\"].SetValue(odbcConnectionManager, sqlInitialCatalog);";

                txtDecryptorCode.Text = connStrDirectSetting + Environment.NewLine + Environment.NewLine + connStringViaAcquireConnection + Environment.NewLine + Environment.NewLine + Environment.NewLine + connStringIndivPropValues + Environment.NewLine + Environment.NewLine + Environment.NewLine + txtDecryptorCode.Text;

                btnConnectionStringHelp.Text = "Remove ConnectionString setting help";
            }


        }

        private void frmDecryptorCode_Shown(object sender, EventArgs e)
        {
            MessageBox.Show(text: "You can copy the decryption code created for you in the right pane and create a ScriptTask task by yourself, or Drag and Drop an SSIS package to auto-generate a OnPreExecute EventHandler with a ScriptTask that will automatically decrypt the encrypted values for you at run time.", caption: "Tip", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
        }

        private void lbDropPackageHere_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                bool allowed = true;
                string[] files = (string[]) e.Data.GetData(DataFormats.FileDrop);
                //check all files for .dtsx extension
                foreach (string file in files)
                {
                    if (!file.EndsWith(".dtsx", StringComparison.InvariantCultureIgnoreCase))
                    {
                        allowed = false;
                        if (!allowed)
                            break;
                    }
                }
                if (allowed)
                    e.Effect = DragDropEffects.All;
            }
        }

        private void lblDragAndDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                bool allowed = true;
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                //check all files for .dtsx extension
                foreach (string file in files)
                {
                    if (!file.EndsWith(".dtsx", StringComparison.InvariantCultureIgnoreCase))
                    {
                        allowed = false;
                        if (!allowed)
                            break;
                    }
                }
                if (allowed)
                    e.Effect = DragDropEffects.All;
            }
        }

        private void lblDragAndDrop_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            LoadListBox(files);
        }

        private void lbDropPackageHere_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            LoadListBox(files);
        }

        private void lbDropPackageHere_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowOpenFileDialog();
        }

        private void lblDragAndDrop_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowOpenFileDialog();
        }

        private void btnStartPtocessingPackages_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(text: "The action you are going to does the below tasks\r\n\r\n1. Creates an OnPreExecute EventHandler with a ScriptTask to decrypt and set the encrypted entries.\r\n2. That ScriptTask created for decryption runs only once when the package starts executing.\r\n3. Sets DelayValidation property to true for the package\r\n4. Unchecks the Enable Configuration item from SSIS configuration wizard.\r\n\r\nWhile these bring no harm to the package and meant for seamless execution of the package, if your package relies on points 3 and 4, then instead of ecrypting the connection manager property, try creating a variable and encrypt them. Or when the package is processed by this tool, amend the package as required.\r\n\r\nIf the package is password protected, you will be prompted to enter the password.\r\n\r\n\r\nAlso this task requires the below dlls (that come with Sql server and BIDS installation\r\n\r\n1. C:\\Program Files\\Microsoft SQL Server\\100\\SDK\\Assemblies\\Microsoft.SqlServer.ScriptTask.dll\r\n2. C:\\Program Files\\Microsoft SQL Server\\100\\SDK\\Assemblies\\Microsoft.SqlServer.VSTAScriptingLib.dll\r\n3. C:\\Program Files\\Microsoft SQL Server\\100\\SDK\\Assemblies\\Microsoft.SqlServer.DTSPipelineWrap.dll\r\n4. C:\\Program Files\\Microsoft SQL Server\\100\\SDK\\Assemblies\\Microsoft.SQLServer.ManagedDTS.dll\r\n5. C:\\Program Files\\Microsoft Visual Studio 9.0\\Common7\\IDE\\PublicAssemblies\\Microsoft.VisualStudio.Tools.Applications.DesignTime.v9.0.dll\r\n\r\nIf this action fails due to assembly load exceptions, then you might want to add the above dlls to the GAC or if the failure is unknown try closing all open visual studio instances and restart the program and try again.", caption: "Warning", buttons: MessageBoxButtons.OKCancel, icon: MessageBoxIcon.Information);
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                bool overwrite = false;
                bool success = false;
                if (lbDropPackageHere.Items.Count == 0)
                {
                    MessageBox.Show(text: "You kidding me?! There ain't no packages to process. Add some packages first and then hit me please.", caption: "Oops!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                }

                //Iterate the radio control for SaveAs options
                if (rdOverwitePackage.Checked)
                {
                    overwrite = true;
                }

                foreach (string fileName in lbDropPackageHere.Items)
                {
                    try
                    {
                        if (overwrite)
                        {
                            new SSISPackageEditor().MakePackageReadyForDecryption(fileName, ref decryptorCode, AssemblyAdministration.targetAssemblyFullName, overwrite, "");
                        }
                        else
                        {
                            new SSISPackageEditor().MakePackageReadyForDecryption(fileName, ref decryptorCode, AssemblyAdministration.targetAssemblyFullName, overwrite, "");
                        }
                        success = true;
                    }
                    catch (SSISCipherUtil.PasswordNotProvidedException)
                    {
                        string packageName = "";
                        if (fileName.LastIndexOf("\\") >= 0)
                        {
                            packageName = fileName.Substring(fileName.LastIndexOf("\\") + 1, fileName.Length - fileName.LastIndexOf("\\") - 1);
                        }
                        else
                        {
                            packageName = fileName;
                        }

                        frmInputPackagePassword inputPasswordPassword = new frmInputPackagePassword();
                        inputPasswordPassword.packageName = packageName;
                        inputPasswordPassword.Name = "Enter Password for package - " + packageName;
                        inputPasswordPassword.ShowDialog();
                        string password = inputPasswordPassword.password;
                        if (!string.IsNullOrEmpty(password))
                        {
                            try
                            {
                                if (overwrite)
                                    new SSISPackageEditor().MakePackageReadyForDecryption(fileName, ref decryptorCode, AssemblyAdministration.targetAssemblyFullName, overwrite, password);
                                else
                                {
                                    new SSISPackageEditor().MakePackageReadyForDecryption(fileName, ref decryptorCode, AssemblyAdministration.targetAssemblyFullName, overwrite, password);
                                }
                                success = true;
                            }
                            catch (Exception eX)
                            {
                                MessageBox.Show(text: eX.Message, caption: "Something went wrong!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show(text: "Password provided is null or empty, Quitting now.", caption: "Not acceptable", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception eX)
                    {
                        MessageBox.Show(text: eX.Message, caption: "Something went wrong!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                    }

                    if (success)
                    {
                        if (overwrite)
                            MessageBox.Show(text: "Successfully processed the package \"" + fileName + "\" for decryption. Provided package was overwritten.", caption: "Success", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                        else
                        {
                            MessageBox.Show(text: "Successfully processed the package \"" + fileName + "\" for decryption. Processed package saved to the same location with a -Mod suffix. For instance a package named AdvWrksLocalLoad2.dtsx would have been saved as AdvWrksLocalLoad2-Mod.dtsx.", caption: "Success", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                        }
                        
                    }
                }
            }
        }

        private void RadioCheckChangedPackage_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton firedRadio = (RadioButton)sender;
            foreach (RadioButton radioButton in gbSaveOptions.Controls)
            {
                if (firedRadio.Name != radioButton.Name)
                {
                    if (firedRadio.Checked)
                    {
                        radioButton.Checked = false;
                    }
                    else
                    {
                        radioButton.Checked = true;
                    }
                }
            }
        }

        #endregion

        #region instance methods

        private void LoadListBox(string[] fileNames)
        {
            foreach (string file in fileNames)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (!packageList.Contains(fileInfo))
                    packageList.Add(fileInfo);
            }
            lbDropPackageHere.Items.Clear();
            foreach (FileInfo fileInfo in packageList)
            {
                lbDropPackageHere.Items.Add(fileInfo.FullName);
            }
            if (lbDropPackageHere.Items.Count > 0)
            {
                lblDragAndDrop.Visible = false;
            }
            else
            {
                lblDragAndDrop.Visible = true;
            }
        }

        private void ShowOpenFileDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "DTSX File|*.dtsx";
            ofd.Multiselect = true;
            ofd.Title = "Browse for DTSX files";
            DialogResult dr = ofd.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                LoadListBox(ofd.FileNames);
            }
        }

        private string GetScriptMainDotCsCode()
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            string retVal = default(string);
            string[] embeddedResourcesArray = currentAssembly.GetManifestResourceNames();

            foreach (string resourceName in embeddedResourcesArray)
            {
                if (resourceName.EndsWith("scriptmain.cs", StringComparison.InvariantCultureIgnoreCase))
                {
                    Stream resourceStream = currentAssembly.GetManifestResourceStream(resourceName);
                    TextReader tr = new StreamReader(resourceStream);
                    retVal = tr.ReadToEnd();
                    resourceStream.Close();
                    tr.Close();
                }
            }
            return retVal;
        }

        #endregion

    }
}
