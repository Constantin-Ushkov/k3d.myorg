namespace MyOrg
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            uiMainStatusStrip = new StatusStrip();
            uiMainMenuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            uiQuitMenuItem = new ToolStripMenuItem();
            uiPpenDataBaseMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            uiSpendingsMenuItem = new ToolStripMenuItem();
            uiMainMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // uiMainStatusStrip
            // 
            uiMainStatusStrip.Location = new Point(0, 831);
            uiMainStatusStrip.Name = "uiMainStatusStrip";
            uiMainStatusStrip.Size = new Size(1274, 22);
            uiMainStatusStrip.TabIndex = 0;
            uiMainStatusStrip.Text = "statusStrip1";
            // 
            // uiMainMenuStrip
            // 
            uiMainMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem });
            uiMainMenuStrip.Location = new Point(0, 0);
            uiMainMenuStrip.Name = "uiMainMenuStrip";
            uiMainMenuStrip.Size = new Size(1274, 24);
            uiMainMenuStrip.TabIndex = 1;
            uiMainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { uiQuitMenuItem, uiPpenDataBaseMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // uiQuitMenuItem
            // 
            uiQuitMenuItem.Name = "uiQuitMenuItem";
            uiQuitMenuItem.Size = new Size(180, 22);
            uiQuitMenuItem.Text = "&Quit";
            uiQuitMenuItem.Click += uiQuitMenuItem_Click;
            // 
            // uiPpenDataBaseMenuItem
            // 
            uiPpenDataBaseMenuItem.Name = "uiPpenDataBaseMenuItem";
            uiPpenDataBaseMenuItem.Size = new Size(180, 22);
            uiPpenDataBaseMenuItem.Text = "&Open DataBase...";
            uiPpenDataBaseMenuItem.Click += uiPpenDataBaseMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { uiSpendingsMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(44, 20);
            viewToolStripMenuItem.Text = "&View";
            // 
            // uiSpendingsMenuItem
            // 
            uiSpendingsMenuItem.Name = "uiSpendingsMenuItem";
            uiSpendingsMenuItem.Size = new Size(180, 22);
            uiSpendingsMenuItem.Text = "&Spendings...";
            uiSpendingsMenuItem.Click += uiSpendingsMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1274, 853);
            Controls.Add(uiMainStatusStrip);
            Controls.Add(uiMainMenuStrip);
            IsMdiContainer = true;
            MainMenuStrip = uiMainMenuStrip;
            Name = "MainForm";
            Text = "My Organizer";
            uiMainMenuStrip.ResumeLayout(false);
            uiMainMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip uiMainStatusStrip;
        private MenuStrip uiMainMenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem uiQuitMenuItem;
        private ToolStripMenuItem uiPpenDataBaseMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem uiSpendingsMenuItem;
    }
}
