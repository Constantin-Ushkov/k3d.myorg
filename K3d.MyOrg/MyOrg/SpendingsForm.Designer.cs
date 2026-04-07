namespace MyOrg
{
    partial class SpendingsForm
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
            label1 = new Label();
            uiTotalSpentYearLabel = new Label();
            uiTotalSpentYearListBox = new ListBox();
            uiTotalSpentMonthListBox = new ListBox();
            label2 = new Label();
            uiTotalSpentMonthLabel = new Label();
            uiTotalSpentWeekListBox = new ListBox();
            label3 = new Label();
            uiTotalSpentWeekLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(127, 15);
            label1.TabIndex = 0;
            label1.Text = "Total Spent (This Year):";
            // 
            // uiTotalSpentYearLabel
            // 
            uiTotalSpentYearLabel.AutoSize = true;
            uiTotalSpentYearLabel.Location = new Point(145, 9);
            uiTotalSpentYearLabel.Name = "uiTotalSpentYearLabel";
            uiTotalSpentYearLabel.Size = new Size(13, 15);
            uiTotalSpentYearLabel.TabIndex = 1;
            uiTotalSpentYearLabel.Text = "0";
            // 
            // uiTotalSpentYearListBox
            // 
            uiTotalSpentYearListBox.FormattingEnabled = true;
            uiTotalSpentYearListBox.Location = new Point(12, 27);
            uiTotalSpentYearListBox.Name = "uiTotalSpentYearListBox";
            uiTotalSpentYearListBox.Size = new Size(233, 184);
            uiTotalSpentYearListBox.TabIndex = 2;
            // 
            // uiTotalSpentMonthListBox
            // 
            uiTotalSpentMonthListBox.FormattingEnabled = true;
            uiTotalSpentMonthListBox.Location = new Point(265, 27);
            uiTotalSpentMonthListBox.Name = "uiTotalSpentMonthListBox";
            uiTotalSpentMonthListBox.Size = new Size(233, 184);
            uiTotalSpentMonthListBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(265, 9);
            label2.Name = "label2";
            label2.Size = new Size(141, 15);
            label2.TabIndex = 4;
            label2.Text = "Total Spent (This Month):";
            // 
            // uiTotalSpentMonthLabel
            // 
            uiTotalSpentMonthLabel.AutoSize = true;
            uiTotalSpentMonthLabel.Location = new Point(412, 9);
            uiTotalSpentMonthLabel.Name = "uiTotalSpentMonthLabel";
            uiTotalSpentMonthLabel.Size = new Size(13, 15);
            uiTotalSpentMonthLabel.TabIndex = 5;
            uiTotalSpentMonthLabel.Text = "0";
            // 
            // uiTotalSpentWeekListBox
            // 
            uiTotalSpentWeekListBox.FormattingEnabled = true;
            uiTotalSpentWeekListBox.Location = new Point(520, 27);
            uiTotalSpentWeekListBox.Name = "uiTotalSpentWeekListBox";
            uiTotalSpentWeekListBox.Size = new Size(233, 184);
            uiTotalSpentWeekListBox.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(520, 9);
            label3.Name = "label3";
            label3.Size = new Size(134, 15);
            label3.TabIndex = 7;
            label3.Text = "Total Spent (This Week):";
            // 
            // uiTotalSpentWeekLabel
            // 
            uiTotalSpentWeekLabel.AutoSize = true;
            uiTotalSpentWeekLabel.Location = new Point(660, 9);
            uiTotalSpentWeekLabel.Name = "uiTotalSpentWeekLabel";
            uiTotalSpentWeekLabel.Size = new Size(13, 15);
            uiTotalSpentWeekLabel.TabIndex = 8;
            uiTotalSpentWeekLabel.Text = "0";
            // 
            // SpendingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(776, 550);
            Controls.Add(uiTotalSpentWeekLabel);
            Controls.Add(label3);
            Controls.Add(uiTotalSpentWeekListBox);
            Controls.Add(uiTotalSpentMonthLabel);
            Controls.Add(label2);
            Controls.Add(uiTotalSpentMonthListBox);
            Controls.Add(uiTotalSpentYearListBox);
            Controls.Add(uiTotalSpentYearLabel);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "SpendingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Spendings";
            Shown += SpendingsForm_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label uiTotalSpentYearLabel;
        private ListBox uiTotalSpentYearListBox;
        private ListBox uiTotalSpentMonthListBox;
        private Label label2;
        private Label uiTotalSpentMonthLabel;
        private ListBox uiTotalSpentWeekListBox;
        private Label label3;
        private Label uiTotalSpentWeekLabel;
    }
}