namespace UI.General
{
    partial class BoardSizeSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            GrpBoardSize = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            NumColumns = new NumericUpDown();
            NumRows = new NumericUpDown();
            GrpBoardSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumColumns).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumRows).BeginInit();
            SuspendLayout();
            // 
            // GrpBoardSize
            // 
            GrpBoardSize.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GrpBoardSize.Controls.Add(label2);
            GrpBoardSize.Controls.Add(label1);
            GrpBoardSize.Controls.Add(NumColumns);
            GrpBoardSize.Controls.Add(NumRows);
            GrpBoardSize.Location = new Point(0, 0);
            GrpBoardSize.Name = "GrpBoardSize";
            GrpBoardSize.Size = new Size(290, 92);
            GrpBoardSize.TabIndex = 1;
            GrpBoardSize.TabStop = false;
            GrpBoardSize.Text = "Board Size";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 61);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 3;
            label2.Text = "Columns:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 28);
            label1.Name = "label1";
            label1.Size = new Size(47, 20);
            label1.TabIndex = 2;
            label1.Text = "Rows:";
            // 
            // NumColumns
            // 
            NumColumns.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NumColumns.Location = new Point(81, 59);
            NumColumns.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            NumColumns.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
            NumColumns.Name = "NumColumns";
            NumColumns.Size = new Size(203, 27);
            NumColumns.TabIndex = 1;
            NumColumns.Value = new decimal(new int[] { 7, 0, 0, 0 });
            // 
            // NumRows
            // 
            NumRows.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NumRows.Location = new Point(81, 26);
            NumRows.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            NumRows.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
            NumRows.Name = "NumRows";
            NumRows.Size = new Size(203, 27);
            NumRows.TabIndex = 0;
            NumRows.Value = new decimal(new int[] { 6, 0, 0, 0 });
            // 
            // BoardSizeSettings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(GrpBoardSize);
            Name = "BoardSizeSettings";
            Size = new Size(290, 92);
            GrpBoardSize.ResumeLayout(false);
            GrpBoardSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumColumns).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumRows).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox GrpBoardSize;
        private Label label2;
        private Label label1;
        private NumericUpDown NumColumns;
        private NumericUpDown NumRows;
    }
}
