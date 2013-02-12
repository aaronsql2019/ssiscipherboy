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
    public partial class frmEditTreeNode : Form
    {
        internal bool isSaveClicked = default(bool);
        internal bool isReadOnly = default(bool);

        public frmEditTreeNode()
        {
            InitializeComponent();
        }

        private void frmEditTreeNode_Load(object sender, EventArgs e)
        {
            if (isReadOnly)
            {
                txtEditTreeNode.ReadOnly = true;
                btnCancel.Enabled = false;
                btnSave.Enabled = false;
            }

            isSaveClicked = false;
            txtEditTreeNode.Text = frmCipherBoy.treeNodeTextToEdit;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            isSaveClicked = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
