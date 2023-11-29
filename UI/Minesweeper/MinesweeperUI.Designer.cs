namespace UI.Minesweeper
{
    partial class MinesweeperUI
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
            minesweeperBoard1 = new MinesweeperBoard();
            SuspendLayout();
            // 
            // minesweeperBoard1
            // 
            minesweeperBoard1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            minesweeperBoard1.Location = new Point(14, 16);
            minesweeperBoard1.Margin = new Padding(3, 5, 3, 5);
            minesweeperBoard1.Name = "minesweeperBoard1";
            minesweeperBoard1.Size = new Size(706, 728);
            minesweeperBoard1.TabIndex = 0;
            // 
            // MinesweeperUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(733, 758);
            Controls.Add(minesweeperBoard1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MinesweeperUI";
            Text = "MinesweeperUI";
            ResumeLayout(false);
        }

        #endregion

        private MinesweeperBoard minesweeperBoard1;
    }
}