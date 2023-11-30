namespace UI.Connect4.v2
{
    partial class Connect4Settings
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
            GrpBoardSize = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            NumColumns = new NumericUpDown();
            NumRows = new NumericUpDown();
            GrpPlayers = new GroupBox();
            BtnAddPlayer = new Button();
            PanPlayers = new FlowLayoutPanel();
            label3 = new Label();
            NumWinLength = new NumericUpDown();
            BtnOk = new Button();
            GrpBoardSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumColumns).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumRows).BeginInit();
            GrpPlayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumWinLength).BeginInit();
            SuspendLayout();
            // 
            // GrpBoardSize
            // 
            GrpBoardSize.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            GrpBoardSize.Controls.Add(label2);
            GrpBoardSize.Controls.Add(label1);
            GrpBoardSize.Controls.Add(NumColumns);
            GrpBoardSize.Controls.Add(NumRows);
            GrpBoardSize.Location = new Point(12, 12);
            GrpBoardSize.Name = "GrpBoardSize";
            GrpBoardSize.Size = new Size(390, 92);
            GrpBoardSize.TabIndex = 0;
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
            NumColumns.Size = new Size(303, 27);
            NumColumns.TabIndex = 1;
            NumColumns.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // NumRows
            // 
            NumRows.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NumRows.Location = new Point(81, 26);
            NumRows.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            NumRows.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
            NumRows.Name = "NumRows";
            NumRows.Size = new Size(303, 27);
            NumRows.TabIndex = 0;
            NumRows.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // GrpPlayers
            // 
            GrpPlayers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GrpPlayers.Controls.Add(BtnOk);
            GrpPlayers.Controls.Add(BtnAddPlayer);
            GrpPlayers.Controls.Add(PanPlayers);
            GrpPlayers.Location = new Point(12, 143);
            GrpPlayers.Name = "GrpPlayers";
            GrpPlayers.Size = new Size(390, 286);
            GrpPlayers.TabIndex = 1;
            GrpPlayers.TabStop = false;
            GrpPlayers.Text = "Players";
            // 
            // BtnAddPlayer
            // 
            BtnAddPlayer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnAddPlayer.Location = new Point(6, 251);
            BtnAddPlayer.Name = "BtnAddPlayer";
            BtnAddPlayer.Size = new Size(29, 29);
            BtnAddPlayer.TabIndex = 1;
            BtnAddPlayer.Text = "+";
            BtnAddPlayer.UseVisualStyleBackColor = true;
            BtnAddPlayer.Click += BtnAddPlayer_Click;
            // 
            // PanPlayers
            // 
            PanPlayers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PanPlayers.AutoScroll = true;
            PanPlayers.FlowDirection = FlowDirection.TopDown;
            PanPlayers.Location = new Point(3, 23);
            PanPlayers.Name = "PanPlayers";
            PanPlayers.Size = new Size(384, 222);
            PanPlayers.TabIndex = 0;
            PanPlayers.WrapContents = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 112);
            label3.Name = "label3";
            label3.Size = new Size(116, 20);
            label3.TabIndex = 2;
            label3.Text = "Winning Length:";
            // 
            // NumWinLength
            // 
            NumWinLength.Location = new Point(140, 110);
            NumWinLength.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            NumWinLength.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            NumWinLength.Name = "NumWinLength";
            NumWinLength.Size = new Size(256, 27);
            NumWinLength.TabIndex = 3;
            NumWinLength.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // BtnOk
            // 
            BtnOk.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnOk.Location = new Point(290, 251);
            BtnOk.Name = "BtnOk";
            BtnOk.Size = new Size(94, 29);
            BtnOk.TabIndex = 2;
            BtnOk.Text = "Ok";
            BtnOk.UseVisualStyleBackColor = true;
            BtnOk.Click += BtnOk_Click;
            // 
            // Connect4Settings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 441);
            ControlBox = false;
            Controls.Add(NumWinLength);
            Controls.Add(label3);
            Controls.Add(GrpPlayers);
            Controls.Add(GrpBoardSize);
            Name = "Connect4Settings";
            Text = "Connect4 Settings";
            GrpBoardSize.ResumeLayout(false);
            GrpBoardSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumColumns).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumRows).EndInit();
            GrpPlayers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NumWinLength).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox GrpBoardSize;
        private Label label2;
        private Label label1;
        private NumericUpDown NumColumns;
        private NumericUpDown NumRows;
        private GroupBox GrpPlayers;
        private FlowLayoutPanel PanPlayers;
        private Button BtnAddPlayer;
        private Label label3;
        private NumericUpDown NumWinLength;
        private Button BtnOk;
    }
}