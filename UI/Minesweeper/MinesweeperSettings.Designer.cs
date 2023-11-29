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
            BoardSize = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            Columns = new NumericUpDown();
            Rows = new NumericUpDown();
            Bombs = new GroupBox();
            NumBombs = new NumericUpDown();
            BoardSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Columns).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Rows).BeginInit();
            Bombs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumBombs).BeginInit();
            SuspendLayout();
            // 
            // BoardSize
            // 
            BoardSize.Controls.Add(label2);
            BoardSize.Controls.Add(label1);
            BoardSize.Controls.Add(Columns);
            BoardSize.Controls.Add(Rows);
            BoardSize.Location = new Point(12, 12);
            BoardSize.Name = "BoardSize";
            BoardSize.Size = new Size(300, 118);
            BoardSize.TabIndex = 0;
            BoardSize.TabStop = false;
            BoardSize.Text = "Board Size";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(192, 67);
            label2.Name = "label2";
            label2.Size = new Size(79, 25);
            label2.TabIndex = 3;
            label2.Text = "columns";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(192, 32);
            label1.Name = "label1";
            label1.Size = new Size(50, 25);
            label1.TabIndex = 2;
            label1.Text = "rows";
            // 
            // Columns
            // 
            Columns.Location = new Point(6, 67);
            Columns.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            Columns.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            Columns.Name = "Columns";
            Columns.Size = new Size(180, 31);
            Columns.TabIndex = 1;
            Columns.Value = new decimal(new int[] { 2, 0, 0, 0 });
            Columns.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // Rows
            // 
            Rows.Location = new Point(6, 30);
            Rows.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            Rows.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            Rows.Name = "Rows";
            Rows.Size = new Size(180, 31);
            Rows.TabIndex = 0;
            Rows.Value = new decimal(new int[] { 2, 0, 0, 0 });
            Rows.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // Bombs
            // 
            Bombs.Controls.Add(NumBombs);
            Bombs.Location = new Point(12, 136);
            Bombs.Name = "Bombs";
            Bombs.Size = new Size(300, 79);
            Bombs.TabIndex = 1;
            Bombs.TabStop = false;
            Bombs.Text = "Bombs";
            // 
            // NumBombs
            // 
            NumBombs.Location = new Point(6, 30);
            NumBombs.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            NumBombs.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumBombs.Name = "NumBombs";
            NumBombs.Size = new Size(180, 31);
            NumBombs.TabIndex = 0;
            NumBombs.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // MinesweeperSettings
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(326, 231);
            Controls.Add(Bombs);
            Controls.Add(BoardSize);
            Name = "MinesweeperSettings";
            Text = "MinesweeperSettings";
            BoardSize.ResumeLayout(false);
            BoardSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Columns).EndInit();
            ((System.ComponentModel.ISupportInitialize)Rows).EndInit();
            Bombs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NumBombs).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox BoardSize;
        private Label label2;
        private Label label1;
        private NumericUpDown Columns;
        private NumericUpDown Rows;
        private GroupBox Bombs;
        private NumericUpDown NumBombs;
    }
}