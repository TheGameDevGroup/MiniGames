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
            numericUpDown2 = new NumericUpDown();
            numericUpDown1 = new NumericUpDown();
            GrpPlayers = new GroupBox();
            BtnAddPlayer = new Button();
            PanPlayers = new FlowLayoutPanel();
            GrpBoardSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            GrpPlayers.SuspendLayout();
            SuspendLayout();
            // 
            // GrpBoardSize
            // 
            GrpBoardSize.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            GrpBoardSize.Controls.Add(label2);
            GrpBoardSize.Controls.Add(label1);
            GrpBoardSize.Controls.Add(numericUpDown2);
            GrpBoardSize.Controls.Add(numericUpDown1);
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
            // numericUpDown2
            // 
            numericUpDown2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDown2.Location = new Point(81, 59);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(303, 27);
            numericUpDown2.TabIndex = 1;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDown1.Location = new Point(81, 26);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(303, 27);
            numericUpDown1.TabIndex = 0;
            // 
            // GrpPlayers
            // 
            GrpPlayers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GrpPlayers.Controls.Add(BtnAddPlayer);
            GrpPlayers.Controls.Add(PanPlayers);
            GrpPlayers.Location = new Point(12, 110);
            GrpPlayers.Name = "GrpPlayers";
            GrpPlayers.Size = new Size(390, 319);
            GrpPlayers.TabIndex = 1;
            GrpPlayers.TabStop = false;
            GrpPlayers.Text = "Players";
            // 
            // BtnAddPlayer
            // 
            BtnAddPlayer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnAddPlayer.Location = new Point(6, 284);
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
            PanPlayers.Size = new Size(384, 255);
            PanPlayers.TabIndex = 0;
            PanPlayers.WrapContents = false;
            // 
            // Connect4Settings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 441);
            Controls.Add(GrpPlayers);
            Controls.Add(GrpBoardSize);
            Name = "Connect4Settings";
            Text = "Connect4Settings";
            GrpBoardSize.ResumeLayout(false);
            GrpBoardSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            GrpPlayers.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox GrpBoardSize;
        private Label label2;
        private Label label1;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown1;
        private GroupBox GrpPlayers;
        private FlowLayoutPanel PanPlayers;
        private Button BtnAddPlayer;
    }
}