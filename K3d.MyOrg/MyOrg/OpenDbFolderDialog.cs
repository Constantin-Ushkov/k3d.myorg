using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyOrg
{
    public partial class OpenDbFolderDialog : Form
    {
        public string DbFolder => uiFolderTextBox.Text;

        public OpenDbFolderDialog()
        {
            InitializeComponent();
        }

        private void uiOkButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void uiBrowseFolderButton_Click(object sender, EventArgs e)
        {
            if (uiFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                uiFolderTextBox.Text = uiFolderBrowserDialog.SelectedPath;
            }
        }
    }
}
