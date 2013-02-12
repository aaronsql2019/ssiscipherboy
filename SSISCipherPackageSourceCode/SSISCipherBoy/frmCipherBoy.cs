using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Diagnostics;

namespace SSISCipherBoy
{
    public partial class frmCipherBoy : Form
    {
        #region static members

        public static List<string> decryptorCode = default(List<string>);
        public static string treeNodeTextToEdit = default(string);

        #endregion

        #region instance members

        XmlDocument xmlDoc = default(XmlDocument);
        FileStream xmlStream = default(FileStream);
        List<string> intendedKeyNodes = default(List<string>);
        bool isLevel4NodeChecked = default(bool);
        TreeNode selectedNode;
        string newEditedNodeValue = default(string);
        TreeNode level2ParentOfEditedNode = default(TreeNode);

        #endregion

        #region event handlers

        public frmCipherBoy()
        {
            InitializeComponent();
        }

        private void frmCipherBoy_Load(object sender, EventArgs e)
        {
            //check and install SSISCipherUtil.dll to GAC
            AssemblyAdministration.RunOnce();

            btnDPAPIEncrypt.Enabled = false;
            btnDPAPIDecrypt.Enabled = false;
            btnDPAPICommitChanges.Enabled = false;
            btnDPAPIGenerateDecryptorSource.Enabled = false;
            btnDPAPILockUnlock.Enabled = false;

            btnRSAEncrypt.Enabled = false;
            btnRSADecrypt.Enabled = false;
            btnRSACommitChanges.Enabled = false;
            btnRSAGenerateDecryptorSource.Enabled = false;
            btnRSALockUnlock.Enabled = false;

            btnLoadXmlConfigFile.Enabled = false;
            btnUnloadXmlConfigFile.Enabled = false;
            btnUnloadXmlConfigFile.Visible = false;


            txtXmlConfigFilePath.ForeColor = Color.Gray;
            txtKeyContainerName.ForeColor = Color.Gray;
        }

        private void txtXmlConfigFilePath_Enter(object sender, EventArgs e)
        {
            if (string.Compare(txtXmlConfigFilePath.Text, @"Input the full path of an SSIS XML config file or use the Browse button to pick or drag and drop inside the empty space", true) == 0)
            {
                txtXmlConfigFilePath.Clear();
            }
        }

        private void txtXmlConfigFilePath_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtXmlConfigFilePath.Text))
            {
                txtXmlConfigFilePath.Text = @"Input the full path of an SSIS XML config file or use the Browse button to pick or drag and drop inside the empty space";
                txtXmlConfigFilePath.ForeColor = Color.Gray;
                btnLoadXmlConfigFile.Enabled = false;
            }
        }

        private void txtXmlConfigFilePath_TextChanged(object sender, EventArgs e)
        {
            if (string.Compare(txtXmlConfigFilePath.Text, @"Input the full path of an SSIS XML config file or use the Browse button to pick or drag and drop inside the empty space", true) != 0)
            {
                txtXmlConfigFilePath.ForeColor = Color.Black;
                btnLoadXmlConfigFile.Enabled = true;
            }
        }

        private void txtKeyContainerName_Enter(object sender, EventArgs e)
        {
            if (string.Compare(txtKeyContainerName.Text, @"Allowed Chars: a-zA-Z0-9", true) == 0)
            {
                txtKeyContainerName.Clear();
            }
        }

        private void txtKeyContainerName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKeyContainerName.Text))
            {
                txtKeyContainerName.Text = @"Allowed Chars: a-zA-Z0-9";
                txtKeyContainerName.ForeColor = Color.Gray;
            }
        }

        private void txtKeyContainerName_TextChanged(object sender, EventArgs e)
        {
            if (string.Compare(txtXmlConfigFilePath.Text, @"Allowed Chars: a-zA-Z0-9", true) != 0)
                txtKeyContainerName.ForeColor = Color.Black;
        }

        private void btnBrowseXmlConfigFile_Click(object sender, EventArgs e)
        {
            ofdXmlConfigFile.Filter = "Integration Services Configuration|*.dtsconfig;*.config|All Files|*.*";

            if (string.Compare(txtXmlConfigFilePath.Text, @"Input the full path of an SSIS XML config file or use the Browse button to pick or drag and drop inside the empty space", true) != 0)
            {
                ofdXmlConfigFile.FileName = txtXmlConfigFilePath.Text;
            }

            ofdXmlConfigFile.Title = "Browse for Integration Services Configuration File";
            DialogResult dr = ofdXmlConfigFile.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(ofdXmlConfigFile.FileName))
                    txtXmlConfigFilePath.Text = ofdXmlConfigFile.FileName;

                if (File.Exists(txtXmlConfigFilePath.Text))
                {
                }
                else
                {
                    MessageBox.Show(text: "Specified File Could not be found.", caption: "Something went wrong!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                }
            }

        }

        private void tvXmlConfigDisplay_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //unsubscribe and resubscribe to the event to avoid infinite loop
            tvXmlConfigDisplay.AfterCheck -= tvXmlConfigDisplay_AfterCheck;

            if (e.Node.Checked == true)
            {
                ApplyToChildNodes("check", e.Node);
            }
            else if (e.Node.Checked == false)
            {
                ApplyToChildNodes("uncheck", e.Node);
                ConditionalEnableLockUnlockButton(tvXmlConfigDisplay.Nodes[0]);
            }

            tvXmlConfigDisplay.AfterCheck += new TreeViewEventHandler(tvXmlConfigDisplay_AfterCheck);
        }

        private void btnLoadXmlConfigFile_Click(object sender, EventArgs e)
        {
            TryTreeViewLoad();
        }

        private void btnUnloadXmlConfigFile_Click(object sender, EventArgs e)
        {
            UnloadTreeView();

            btnLoadXmlConfigFile.Enabled = true;
            btnUnloadXmlConfigFile.Enabled = false;
            btnUnloadXmlConfigFile.Visible = false;
            lblDragDropHere.Visible = true;


            DisableLockUnlockButtons();
            tvXmlConfigDisplay.Enabled = true;
        }

        private void btnDPAPILockUnlock_Click(object sender, EventArgs e)
        {
            if (tvXmlConfigDisplay.Enabled)
            {
                tvXmlConfigDisplay.Enabled = false;
                btnDPAPIEncrypt.Enabled = true;
                btnDPAPIDecrypt.Enabled = true;
               // btnDPAPICommitChanges.Enabled = true;
                btnDPAPIGenerateDecryptorSource.Enabled = true;
            }
            else
            {
                tvXmlConfigDisplay.Enabled = true;
                btnDPAPIEncrypt.Enabled = false;
                btnDPAPIDecrypt.Enabled = false;
               // btnDPAPICommitChanges.Enabled = false;
                btnDPAPIGenerateDecryptorSource.Enabled = false;
            }
        }

        private void btnDPAPIEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (AreNodesSelected())
                {
                    SSISCipherUtil.Utils.StartTransforming(xmlDoc, intendedKeyNodes.ToArray(), "cipher", SSISCipherUtil.EncryptionProvider.DPAPI, "");


                    MessageBox.Show(text: "Selected nodes encrypted. Hit Commit Changes button to save changes to the original configuration file." + sfdExportKeys.FileName, caption: "Success!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);

                    //refresh treeview
                    RefreshTreeView();

                    btnDPAPICommitChanges.Enabled = true;
                }
                else
                {
                    MessageBox.Show(text: "Operation valid only when configuration entry values are selected in tree view.", caption: "Invalid Operation", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                }
            }
            catch (Exception eX)
            {
                MessageBox.Show(text: eX.Message, caption: "Something went wrong!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);

            }
        }

        private void btnDPAPIDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (AreNodesSelected())
                {
                    SSISCipherUtil.Utils.StartTransforming(xmlDoc, intendedKeyNodes.ToArray(), "decipher", SSISCipherUtil.EncryptionProvider.DPAPI, "");

                    MessageBox.Show(text: "Selected nodes decrypted. Hit Commit Changes button to save changes to the original configuration file." + sfdExportKeys.FileName, caption: "Success!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);

                    //refresh treeview
                    RefreshTreeView();
                    btnDPAPICommitChanges.Enabled = true;
                }
                else
                {
                    MessageBox.Show(text: "Operation valid only when configuration entry values are selected in tree view.", caption: "Invalid Operation", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                }
            }
            catch (Exception eX)
            {
                MessageBox.Show(text: eX.Message, caption: "Something went wrong!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void btnRSALockUnlock_Click(object sender, EventArgs e)
        {
            if (tvXmlConfigDisplay.Enabled)
            {
                tvXmlConfigDisplay.Enabled = false;
                btnRSAEncrypt.Enabled = true;
                btnRSADecrypt.Enabled = true;
                //btnRSACommitChanges.Enabled = true;
                btnRSAGenerateDecryptorSource.Enabled = true;
            }
            else
            {
                tvXmlConfigDisplay.Enabled = true;
                btnRSAEncrypt.Enabled = false;
                btnRSADecrypt.Enabled = false;
                //btnRSACommitChanges.Enabled = false;
                btnRSAGenerateDecryptorSource.Enabled = false;
            }
        }

        private void btnDPAPICommitChanges_Click(object sender, EventArgs e)
        {
            try
            {
                SaveStream();

                MessageBox.Show(text: "Changes committed to the file successfully.", caption: "Success!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
            }
            catch (Exception eX)
            {
                MessageBox.Show(text: eX.Message, caption: "Something went wrong!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);

            }

            AfterCommitChanges();
        }

        private void btnRSAEncrypt_Click(object sender, EventArgs e)
        {
            if (!SSISCipherUtil.Utils.CheckForRegExMatch(txtKeyContainerName.Text, @"^[a-zA-Z0-9]{8,32}$", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                MessageBox.Show(text: "Invalid Key container name. Only alphabets or numbers string without a whitespace ranging from 8 to 32 characters is allowed.", caption: "Invalid Input", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                txtKeyContainerName.Focus();
                
                return;
            }

            try
            {
                if (AreNodesSelected())
                {
                    SSISCipherUtil.Utils.StartTransforming(xmlDoc, intendedKeyNodes.ToArray(), "cipher", SSISCipherUtil.EncryptionProvider.RSA, txtKeyContainerName.Text);

                    MessageBox.Show(text: "Selected nodes encrypted. Hit Commit Changes button to save changes to the original configuration file." + sfdExportKeys.FileName, caption: "Success!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                    //refresh treeview
                    RefreshTreeView();
                    btnRSACommitChanges.Enabled = true;
                }
                else
                {
                    MessageBox.Show(text: "Operation valid only when configuration entry values are selected in tree view.", caption: "Invalid Operation", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                }
            }
            catch (Exception eX)
            {
                MessageBox.Show(text: eX.Message, caption: "Something went wrong!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);

            }            
        }

        private void btnRSADecrypt_Click(object sender, EventArgs e)
        {
            if (!SSISCipherUtil.Utils.CheckForRegExMatch(txtKeyContainerName.Text, @"^[a-zA-Z0-9]{8,32}$", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                MessageBox.Show(text: "Invalid Key container name. Only alphabets or numbers without a whitespace ranging from 8 to 32 characters is allowed.", caption: "Invalid Input", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                txtKeyContainerName.Focus();
                return;
            }

            try
            {
                if (AreNodesSelected())
                {
                    SSISCipherUtil.Utils.StartTransforming(xmlDoc, intendedKeyNodes.ToArray(), "decipher", SSISCipherUtil.EncryptionProvider.RSA, txtKeyContainerName.Text);

                    MessageBox.Show(text: "Selected nodes decrypted. Hit Commit Changes button to save changes to the original configuration file." + sfdExportKeys.FileName, caption: "Success!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                    //refresh treeview
                    RefreshTreeView();
                    btnRSACommitChanges.Enabled = true;
                }
                else
                {
                    MessageBox.Show(text: "Operation valid only when configuration entry values are selected in tree view.", caption: "Invalid Operation", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                }
            }
            catch (Exception eX)
            {
                MessageBox.Show(text: eX.Message, caption: "Something went wrong!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                
            }
            
        }

        private void btnRSAExport_Click(object sender, EventArgs e)
        {
            if (string.Compare(txtKeyContainerName.Text, @"Allowed Chars: a-zA-Z0-9", true) == 0)
            {
                MessageBox.Show(text: "Please change the key container name. Only alphabets or numbers without a whitespace is allowed.", caption: "Invalid Input", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                txtKeyContainerName.Focus();
                return;
            }

            DialogResult confirm = MessageBox.Show(text: "Do you want to export an RSA keypair from the container name \"" + txtKeyContainerName.Text + "\"", caption: "Export?", buttons: MessageBoxButtons.YesNoCancel, icon: MessageBoxIcon.Question);

            switch (confirm)
            {
                case System.Windows.Forms.DialogResult.Yes:
                    {
                        sfdExportKeys.Filter = "Xml File|*.xml";
                        sfdExportKeys.FileName = txtKeyContainerName.Text + ".xml";
                        DialogResult dr = sfdExportKeys.ShowDialog();

                        if (dr == System.Windows.Forms.DialogResult.OK)
                        {
                            try
                            {
                                SSISCipherUtil.SSISInterceptor.ExportKeyAsXmlFile(sfdExportKeys.FileName, txtKeyContainerName.Text, true);
                            }
                            catch (Exception eX)
                            {
                                MessageBox.Show(text: eX.Message, caption: "Something went wrong!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);

                            }
                        }


                        MessageBox.Show(text: "RSA key pair exported to file - " + sfdExportKeys.FileName, caption: "Success!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                        break;
                    }
                default:
                    break;
            }
        }

        private void btnRSAImport_Click(object sender, EventArgs e)
        {
            if (string.Compare(txtKeyContainerName.Text, @"Allowed Chars: a-zA-Z0-9", true) == 0)
            {
                MessageBox.Show(text: "Please change the key container name. Only alphabets or numbers without a whitespace is allowed.", caption: "Invalid Input", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                txtKeyContainerName.Focus();
                return;
            }

            ofdImportKeys.Filter = "Xml File|*.xml|All Files|*.*";
            ofdImportKeys.FileName = txtKeyContainerName.Text + ".xml";
            DialogResult dr = ofdImportKeys.ShowDialog();

            switch (dr)
            {
                case System.Windows.Forms.DialogResult.OK:
                    {
                        DialogResult confirm = MessageBox.Show(text: "Do you want to import the specified RSA keypair into the container named \"" + txtKeyContainerName.Text + "\"", caption: "Import?", buttons: MessageBoxButtons.YesNoCancel, icon: MessageBoxIcon.Question);

                        if (confirm == System.Windows.Forms.DialogResult.Yes)
                        {
                            try
                            {
                            SSISCipherUtil.SSISInterceptor.ImportKeyFromXmlFile(ofdImportKeys.FileName, txtKeyContainerName.Text);
                            }
                            catch (Exception eX)
                            {
                                MessageBox.Show(text: eX.Message, caption: "Something went wrong!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);

                            }

                            MessageBox.Show(text: "RSA key pair imported from file - " + ofdImportKeys.FileName, caption: "Success!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                        }
                        break;
                    }
                default:
                    break;
            }
        }

        private void btnRSACommitChanges_Click(object sender, EventArgs e)
        {
            try
            {
                SaveStream();

                MessageBox.Show(text: "Changes committed to the file successfully.", caption: "Success!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
            }
            catch (Exception eX)
            {
                MessageBox.Show(text: eX.Message, caption: "Something went wrong!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);

            }

            AfterCommitChanges();

        }

        private void btnRSAGenerateDecryptorSource_Click(object sender, EventArgs e)
        {
            try
            {
                if (AreNodesSelected())
                {
                    decryptorCode = SSISCipherUtil.DecryptionCodeEntityCollection.ObtainDecryptorCode(intendedKeyNodes.ToArray());

                    new frmDecryptorCode().ShowDialog();
                }
                else
                {
                    MessageBox.Show(text: "Operation valid only when configuration entry values are selected in tree view.", caption: "Invalid Operation", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                }

            }
            catch (Exception eX)
            {
                MessageBox.Show(text: eX.Message, caption: "Something went wrong!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void btnDPAPIGenerateDecryptorSource_Click(object sender, EventArgs e)
        {
            try
            {
                if (AreNodesSelected())
                {
                    decryptorCode = SSISCipherUtil.DecryptionCodeEntityCollection.ObtainDecryptorCode(intendedKeyNodes.ToArray());
                    //decryptorCode = SSISCipherUtil.Utils.GenerateSSISDecryptorCode(xmlDoc, intendedKeyNodes.ToArray());

                    new frmDecryptorCode().ShowDialog();
                }
                else
                {
                    MessageBox.Show(text: "Operation valid only when configuration entry values are selected in tree view.", caption: "Invalid Operation", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                }

            }
            catch (Exception eX)
            {
                MessageBox.Show(text: eX.Message, caption: "Something went wrong!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void llblAssemblyAdministration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmAssemblyAdministration().ShowDialog();
        }

        private void tvXmlConfigDisplay_Click(object sender, EventArgs e)
        {
            
        }

        private void tvXmlConfigDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                TreeNode nodeClicked = tvXmlConfigDisplay.GetNodeAt(e.X, e.Y);
                this.tvXmlConfigDisplay.SelectedNode = nodeClicked;
                cmTreeView.Show(tvXmlConfigDisplay, new Point(e.X, e.Y));
            }
        }

        private void miCopy_Click(object sender, EventArgs e)
        {
             
        }

        private void miCopy_MouseDown(object sender, MouseEventArgs e)
        {
            GetSelectedNode(tvXmlConfigDisplay.Nodes[0]);
            Clipboard.SetText(selectedNode.Text, TextDataFormat.Text);
        }

        private void miEdit_Click(object sender, EventArgs e)
        {
            GetSelectedNode(tvXmlConfigDisplay.Nodes[0]);
            treeNodeTextToEdit = selectedNode.Text;

            if (treeNodeTextToEdit != null)
            {
                frmEditTreeNode editTreeNode;
                if (selectedNode.Level != 4)
                {
                    //open this as read only
                    //MessageBox.Show(text: "Editing this node is not supported! Only the value of <ConfiguredValue> nodes are editable. However this will be opened read-only", caption: "Invalid Operation", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                    editTreeNode = new frmEditTreeNode();
                    editTreeNode.isReadOnly = true;
                    editTreeNode.ShowDialog();
                }
                else
                {
                    editTreeNode = new frmEditTreeNode();
                    editTreeNode.ShowDialog();
                    
                    
                    if (editTreeNode.isSaveClicked)
                    {
                        //update the treeNode text
                        selectedNode.Text = editTreeNode.txtEditTreeNode.Text;
                        //update the XML dom
                        newEditedNodeValue = selectedNode.Text;
                        level2ParentOfEditedNode = selectedNode.Parent.Parent;
                        UpdateXmlDomWithEditedNodeValue(xmlDoc, level2ParentOfEditedNode);
                    }
                }              
            }

        }

        private void tvXmlConfigDisplay_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                if (e.Node.Level != 4)
                {
                    MessageBox.Show(text: "Editing this node is not supported! Only the value of <ConfiguredValue> nodes are editable.", caption: "Invalid Operation", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                    e.CancelEdit = true;
                    return;
                }
                if (e.Label.Length > 0)
                {
                    e.Node.EndEdit(true);

                    //update the XML dom
                    newEditedNodeValue = e.Label;                    
                    level2ParentOfEditedNode = e.Node.Parent.Parent;
                    UpdateXmlDomWithEditedNodeValue(xmlDoc, level2ParentOfEditedNode);
                }
                else
                {
                    e.CancelEdit = true;
                    MessageBox.Show(text: "Value cant be empty.", caption: "Invalid Operation", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                    e.Node.BeginEdit();
                }

                tvXmlConfigDisplay.LabelEdit = false;
            }
        }

        private void tvXmlConfigDisplay_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
        }

        private void llblAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmAboutBox().ShowDialog();
        }

        private void llblHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", "about:blank");
        }

        private void tvXmlConfigDisplay_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[]) e.Data.GetData(DataFormats.FileDrop);
            txtXmlConfigFilePath.Text = files[0];

            if (File.Exists(txtXmlConfigFilePath.Text))
            {
                TryTreeViewLoad();
            }
            else
            {
                MessageBox.Show(text: "Specified File Could not be found.", caption: "Something went wrong!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
            }

        }

        private void tvXmlConfigDisplay_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
        }

#endregion

        #region instance methods

        private void ConditionalEnableLockUnlockButton(TreeNode treeNode)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                if (node.Level == 4 && node.Checked == true)
                {
                    EnableLockUnlockButtons();
                    return;
                }
                ConditionalEnableLockUnlockButton(node);
            }
        }

        private void ApplyToChildNodes(string action, TreeNode treeNode)
        {
            switch (action)
            {
                case "check":
                    {
                        treeNode.Checked = true;

                        //color change
                        if (treeNode.Level == 4)
                        {
                            treeNode.ForeColor = Color.DarkRed;
                            treeNode.BackColor = Color.GreenYellow;

                            //check the level 3 and level 2 nodes, if level 4 node is checked
                            treeNode.Parent.Checked = treeNode.Parent.Parent.Checked = true;
                            EnableLockUnlockButtons();
                        }
                        break;
                    }
                case "uncheck":
                    {
                        treeNode.Checked = false;

                        if (treeNode.Level == 4)
                        {
                            if (treeNode.Text.IndexOf("[DPAPI]", StringComparison.InvariantCultureIgnoreCase) == 0 || treeNode.Text.IndexOf("[RSA-", StringComparison.InvariantCultureIgnoreCase) == 0)
                            {
                                treeNode.ForeColor = Color.DarkGreen;
                            }
                            else
                            {
                                treeNode.ForeColor = Color.DarkRed;
                            }

                            //color change
                            treeNode.BackColor = Color.White;

                            //uncheck the level 3 and level 2 nodes, if level 4 node is unchecked
                            treeNode.Parent.Checked = treeNode.Parent.Parent.Checked = false;
                            DisableLockUnlockButtons();
                        }
                        break;
                    }
            }

            if (treeNode.Level == 4 && treeNode.Checked == true)
            {
                isLevel4NodeChecked = true;
            }
            else
            {
                isLevel4NodeChecked = false;
            }

            foreach (TreeNode node in treeNode.Nodes)
            {
                ApplyToChildNodes(action, node);
            }
        }

        private void GetAllIntendedItemsToTransform(TreeNode treeNode)
        {
            // Keys are in Level 2 of the treeView
            // Identify Level 4 items that are checked and get their corresponding Level 2 xml element.
            // Xml element in level 2 has an attribute called Path, that represents the key (or property name)

            if (treeNode.Level == 4 && treeNode.Checked == true)
            {
                intendedKeyNodes.Add(treeNode.Parent.Parent.Text);
            }

            foreach (TreeNode tn in treeNode.Nodes)
            {
                GetAllIntendedItemsToTransform(tn);
            }
        }

        private void GetSelectedNode(TreeNode treeNode)
        {
            if (treeNode.IsSelected)
            {
                selectedNode = treeNode;
            }

            foreach (TreeNode tn in treeNode.Nodes)
            {
                GetSelectedNode(tn);
            }
        }

        private void RefreshTreeView()
        {
            tvXmlConfigDisplay.Nodes.Clear();
            SSISCipherUtil.Utils.ConvertXmlNodeToTreeNode(xmlDoc, tvXmlConfigDisplay.Nodes);
            tvXmlConfigDisplay.Nodes[0].ExpandAll();
            tvXmlConfigDisplay.Nodes[0].EnsureVisible();
        }

        private bool LoadXmlDom()
        {
            xmlStream = new FileStream(txtXmlConfigFilePath.Text, FileMode.Open, FileAccess.ReadWrite);
            xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlStream);
                return true;
            }
            catch (Exception)
            {
                UnloadTreeView();
                return false;
            }
        }

        private void UnloadTreeView()
        {
            xmlStream.Close();
            xmlStream.Dispose();
            xmlDoc = null;
            if (tvXmlConfigDisplay.Nodes != null)
            {
                tvXmlConfigDisplay.Nodes.Clear();
            }
        }

        private void SaveStream()
        {
            xmlStream.SetLength(0);
            xmlStream.Position = 0;

            xmlDoc.Save(xmlStream);

            xmlStream.Flush();


            //Apply the dirty fix
            #region dirty fix justification
            /*
             * 
             * * ********************************************* problem *******************************************************
             * 
             * 
             * Note: If there is a empty value for an xml node (i.e., a ssis property value that is empty and is exported)
             *          SSIS configuration manager exports it as <ConfiguredValue></ConfiguredValue>.
             *          However, when read with an XmlDocument, and written back, the xmlDoc.Save method represents the empty value as
             *          <ConfiguredValue>    </ConfiguredValue>
             *          
             *          that is.. when you open two files in a notepad, there are four white space characters..
             *          
             *          while the XmlDocument understands it properly, the ssis package seems to have trouble understanding it.
             *          
             *          Repro steps: create an FTP connection manager, connect to a local FTP server with Anonymous authentication,
             *          (which means no password needs to be supplied) exprort the FTP connection manager properties as below
             *          
             * <?xml version="1.0"?>
<DTSConfiguration>
  <DTSConfigurationHeading>
    <DTSConfigurationFileInfo GeneratedBy="comp\maran" GeneratedFromPackageName="ssisFTPConn" GeneratedFromPackageID="{B3048A59-C4ED-4859-8EEC-36768E42B1A7}" GeneratedDate="10/31/2012 9:41:29 PM"/>
  </DTSConfigurationHeading>
  <Configuration ConfiguredType="Property" Path="\Package.Connections[FTP Connection Manager].Properties[ServerName]" ValueType="String">
    <ConfiguredValue>localhost</ConfiguredValue>
  </Configuration>
  <Configuration ConfiguredType="Property" Path="\Package.Connections[FTP Connection Manager].Properties[ServerPassword]" ValueType="String">
    <ConfiguredValue></ConfiguredValue>
  </Configuration>
</DTSConfiguration>
             * 
             *          In the above configuration if 
             *          
             *   <Configuration ConfiguredType="Property" Path="\Package.Connections[FTP Connection Manager].Properties[ServerPassword]" ValueType="String">
    <ConfiguredValue></ConfiguredValue>
  </Configuration>
             * 
             * 
             *          is replaced with 
             *          
             *   <Configuration ConfiguredType="Property" Path="\Package.Connections[FTP Connection Manager].Properties[ServerPassword]" ValueType="String">
    <ConfiguredValue>
    </ConfiguredValue>
  </Configuration>
             * 
             *          the package would not work, and throws an error like below
             *          
             * Error: 2012-10-31 21:53:22.72
   Code: 0xC0016030
   Source: ssisFTPConn Connection manager "FTP Connection Manager"
   Description: Changing current directory to "\". 500 '    ': command not understood
.
End Error
Error: 2012-10-31 21:53:22.73
   Code: 0xC002F304
   Source: FTP Task FTP Task
   Description: An error occurred with the following error message: "Changing current directory to "\". 500 '    ': command not understood
.
".
End Error
             * 
             * 
             * 
             * 
             * ********************************************* Fix *******************************************************
             * 
             * seems like a corner case. spent enough time to replicate, thats why calling it a dirty fix.
             * 
             * Once the Xmldoc is written back to the file system, use a text reader, read the entire string, replace the four whitespace chars with null
             * 
             */
            #endregion

            xmlStream.Position = 0;
            TextReader textReader = new StreamReader(xmlStream);
            string xmlText = textReader.ReadToEnd();
            string pattern = @"<ConfiguredValue>" + Environment.NewLine + "    " + @"</ConfiguredValue>";
            string replacement = @"<ConfiguredValue></ConfiguredValue>";
            xmlText = xmlText.Replace(pattern, replacement);

            xmlStream.SetLength(0);
            xmlStream.Position = 0;
            TextWriter textWriter = new StreamWriter(xmlStream);
            textWriter.Write(xmlText);
            textWriter.Flush();
        }

        private void EnableLockUnlockButtons()
        {
            btnDPAPILockUnlock.Enabled = true;
            btnRSALockUnlock.Enabled = true;
        }

        private void DisableLockUnlockButtons()
        {
            btnDPAPILockUnlock.Enabled = false;
            btnRSALockUnlock.Enabled = false;
        }

        private bool AreNodesSelected()
        {
            bool retVal = default(bool);

            intendedKeyNodes = new List<string>();
            GetAllIntendedItemsToTransform(tvXmlConfigDisplay.Nodes[0]);

            if (intendedKeyNodes.Count > 0)
                retVal = true;

            foreach (string s in intendedKeyNodes)
            {
                if (!SSISCipherUtil.Utils.CheckForAllowedDtsItem(s))
                    throw new SSISCipherUtil.DtsItemNotAllowedException();
                if (!SSISCipherUtil.Utils.CheckForAllowedDataType(s))
                    throw new SSISCipherUtil.DataTypeNotAllowedException();
            }

            return retVal;
        }

        private void AfterCommitChanges()
        {
            btnDPAPICommitChanges.Enabled = false;
            btnDPAPIEncrypt.Enabled = false;
            btnDPAPIDecrypt.Enabled = false;
            tvXmlConfigDisplay.Enabled = true;

            btnRSACommitChanges.Enabled = false;
            btnRSAEncrypt.Enabled = false;
            btnRSADecrypt.Enabled = false;
            tvXmlConfigDisplay.Enabled = true;
        }

        private void TryTreeViewLoad()
        {
            try
            {
                if (File.Exists(txtXmlConfigFilePath.Text))
                {
                    if (LoadXmlDom())
                    {

                        RefreshTreeView();

                        btnLoadXmlConfigFile.Enabled = false;
                        btnUnloadXmlConfigFile.Enabled = true;
                        btnUnloadXmlConfigFile.Visible = true;

                        lblDragDropHere.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show(text: "The document could not be loaded. Please check if it is a valid xml document.", caption: "Error loading Xml Dom!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(text: "Specified File Could not be found. Please use the Browse button to specify an exact path if you are not sure about the location of the config file.", caption: "Open File Failed!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                }
            }
            catch (Exception eX)
            {
                MessageBox.Show(text: eX.Message, caption: "Something went wrong!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void UpdateXmlDomWithEditedNodeValue(XmlNode xNode, TreeNode pathKeyToUpdate)
        {
            if (xNode.Name.IndexOf("Configuration", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                string xNodePathKey = ObtainPathKey(xNode.OuterXml);
                string treeNodePathKey = ObtainPathKey(pathKeyToUpdate.Text);

                if (xNodePathKey.IndexOf(treeNodePathKey, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    xNode.ChildNodes[0].InnerText = newEditedNodeValue;
                }
            }

            foreach (XmlNode childNode in xNode.ChildNodes)
            {
                UpdateXmlDomWithEditedNodeValue(childNode, pathKeyToUpdate);
            }
        }

        private string ObtainPathKey(string level2Node)
        {
            string searchKey = level2Node;
            int startPos, endPos, subStringLength;

            startPos = searchKey.IndexOf("Path=\"", StringComparison.InvariantCultureIgnoreCase) + 6;
            endPos = searchKey.IndexOf("\"", startPos, StringComparison.InvariantCultureIgnoreCase);

            subStringLength = endPos - startPos;

            searchKey = searchKey.Substring(startPos, subStringLength);
            return searchKey;
        }

        #endregion
    }
}
