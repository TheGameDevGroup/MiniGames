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
            panel1 = new Panel();
            LblTimePassed = new Label();
            LblBombCount = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // minesweeperBoard1
            // 
            minesweeperBoard1.AutoScroll = true;
            minesweeperBoard1.Dock = DockStyle.Bottom;
            minesweeperBoard1.Location = new Point(0, 93);
            minesweeperBoard1.Margin = new Padding(3, 5, 3, 5);
            minesweeperBoard1.Name = "minesweeperBoard1";
            minesweeperBoard1.Size = new Size(1067, 608);
            minesweeperBoard1.TabIndex = 0;
            minesweeperBoard1.TileSize = 20;
            // 
            // panel1
            // 
            panel1.Controls.Add(LblTimePassed);
            panel1.Controls.Add(LblBombCount);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(1067, 65);
            panel1.TabIndex = 1;
            // 
            // LblTimePassed
            // 
            LblTimePassed.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LblTimePassed.AutoSize = true;
            LblTimePassed.BorderStyle = BorderStyle.FixedSingle;
            LblTimePassed.Font = new Font("Segoe UI", 26F);
            LblTimePassed.Location = new Point(1001, 0);
            LblTimePassed.Name = "LblTimePassed";
            LblTimePassed.Size = new Size(63, 62);
            LblTimePassed.TabIndex = 1;
            LblTimePassed.Text = "--";
            LblTimePassed.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LblBombCount
            // 
            LblBombCount.AutoSize = true;
            LblBombCount.BorderStyle = BorderStyle.FixedSingle;
            LblBombCount.Font = new Font("Segoe UI", 26F);
            LblBombCount.Location = new Point(3, 0);
            LblBombCount.Name = "LblBombCount";
            LblBombCount.Size = new Size(63, 62);
            LblBombCount.TabIndex = 0;
            LblBombCount.Text = "--";
            LblBombCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MinesweeperUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 701);
            Controls.Add(panel1);
            Controls.Add(minesweeperBoard1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MinesweeperUI";
            Text = "MinesweeperUI";
            Controls.SetChildIndex(minesweeperBoard1, 0);
            Controls.SetChildIndex(panel1, 0);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MinesweeperBoard minesweeperBoard1;
        private Panel panel1;
        private Label LblTimePassed;
        private Label LblBombCount;
    }
}