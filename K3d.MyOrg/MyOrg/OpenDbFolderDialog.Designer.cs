namespace MyOrg
{
    partial class OpenDbFolderDialog
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
            uiFolderTextBox = new TextBox();
            label1 = new Label();
            uiBrowseFolderButton = new Button();
            uiOkButton = new Button();
            uiCancelButton = new Button();
            uiFolderBrowserDialog = new FolderBrowserDialog();
            SuspendLayout();
            // 
            // uiFolderTextBox
            // 
            uiFolderTextBox.Location = new Point(12, 30);
            uiFolderTextBox.Name = "uiFolderTextBox";
            uiFolderTextBox.Size = new Size(376, 23);
            uiFolderTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 1;
            label1.Text = "DataBase Folder";
            // 
            // uiBrowseFolderButton
            // 
            uiBrowseFolderButton.Location = new Point(394, 30);
            uiBrowseFolderButton.Name = "uiBrowseFolderButton";
            uiBrowseFolderButton.Size = new Size(75, 23);
            uiBrowseFolderButton.TabIndex = 2;
            uiBrowseFolderButton.Text = "Browse...";
            uiBrowseFolderButton.UseVisualStyleBackColor = true;
            uiBrowseFolderButton.Click += this.uiBrowseFolderButton_Click;
            // 
            // uiOkButton
            // 
            uiOkButton.Location = new Point(394, 59);
            uiOkButton.Name = "uiOkButton";
            uiOkButton.Size = new Size(75, 23);
            uiOkButton.TabIndex = 3;
            uiOkButton.Text = "Ok";
            uiOkButton.UseVisualStyleBackColor = true;
            uiOkButton.Click += this.uiOkButton_Click;
            // 
            // uiCancelButton
            // 
            uiCancelButton.Location = new Point(313, 59);
            uiCancelButton.Name = "uiCancelButton";
            uiCancelButton.Size = new Size(75, 23);
            uiCancelButton.TabIndex = 4;
            uiCancelButton.Text = "Cancel";
            uiCancelButton.UseVisualStyleBackColor = true;
            // 
            // OpenDbFolderDialog
            // 
            AcceptButton = uiOkButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = uiCancelButton;
            ClientSize = new Size(486, 93);
            Controls.Add(uiCancelButton);
            Controls.Add(uiOkButton);
            Controls.Add(uiBrowseFolderButton);
            Controls.Add(label1);
            Controls.Add(uiFolderTextBox);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "OpenDbFolderDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Open DataBase Folder";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox uiFolderTextBox;
        private Label label1;
        private Button uiBrowseFolderButton;
        private Button uiOkButton;
        private Button uiCancelButton;
        private FolderBrowserDialog uiFolderBrowserDialog;
    }
}