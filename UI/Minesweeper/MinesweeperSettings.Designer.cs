namespace UI.Minesweeper
{
    partial class MinesweeperSettings
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
            Bombs = new GroupBox();
            NumBombs = new NumericUpDown();
            boardSizeSettings = new General.BoardSizeSettings();
            groupBox1 = new GroupBox();
            Bombs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumBombs).BeginInit();
            SuspendLayout();
            // 
            // Bombs
            // 
            Bombs.Controls.Add(NumBombs);
            Bombs.Location = new Point(12, 110);
            Bombs.Name = "Bombs";
            Bombs.Padding = new Padding(2);
            Bombs.Size = new Size(240, 63);
            Bombs.TabIndex = 1;
            Bombs.TabStop = false;
            Bombs.Text = "Bombs";
            // 
            // NumBombs
            // 
            NumBombs.Location = new Point(5, 24);
            NumBombs.Margin = new Padding(2);
            NumBombs.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            NumBombs.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumBombs.Name = "NumBombs";
            NumBombs.Size = new Size(144, 27);
            NumBombs.TabIndex = 0;
            NumBombs.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // boardSizeSettings
            // 
            boardSizeSettings.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            boardSizeSettings.Columns = 2;
            boardSizeSettings.Location = new Point(12, 12);
            boardSizeSettings.MinimumSize = new Size(0, 92);
            boardSizeSettings.Name = "boardSizeSettings";
            boardSizeSettings.Rows = 2;
            boardSizeSettings.Size = new Size(495, 92);
            boardSizeSettings.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Location = new Point(17, 212);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(490, 258);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Style";
            // 
            // MinesweeperSettings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(519, 482);
            ControlBox = false;
            Controls.Add(groupBox1);
            Controls.Add(boardSizeSettings);
            Controls.Add(Bombs);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MinesweeperSettings";
            Text = "Minesweeper Settings";
            Bombs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NumBombs).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox Bombs;
        private NumericUpDown NumBombs;
        private General.BoardSizeSettings boardSizeSettings;
        private GroupBox groupBox1;
    }
}