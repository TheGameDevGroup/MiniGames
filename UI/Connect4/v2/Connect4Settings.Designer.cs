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
            GrpPlayers = new GroupBox();
            BtnCancel = new Button();
            BtnOk = new Button();
            BtnAddPlayer = new Button();
            PanPlayers = new FlowLayoutPanel();
            label3 = new Label();
            NumWinLength = new NumericUpDown();
            boardSizeSettings = new General.BoardSizeSettings();
            GrpPlayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumWinLength).BeginInit();
            SuspendLayout();
            // 
            // GrpPlayers
            // 
            GrpPlayers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GrpPlayers.Controls.Add(BtnCancel);
            GrpPlayers.Controls.Add(BtnOk);
            GrpPlayers.Controls.Add(BtnAddPlayer);
            GrpPlayers.Controls.Add(PanPlayers);
            GrpPlayers.Location = new Point(12, 143);
            GrpPlayers.Name = "GrpPlayers";
            GrpPlayers.Size = new Size(371, 286);
            GrpPlayers.TabIndex = 1;
            GrpPlayers.TabStop = false;
            GrpPlayers.Text = "Players";
            // 
            // BtnCancel
            // 
            BtnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnCancel.Location = new Point(171, 251);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(94, 29);
            BtnCancel.TabIndex = 3;
            BtnCancel.Text = "Cancel";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // BtnOk
            // 
            BtnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnOk.Location = new Point(271, 251);
            BtnOk.Name = "BtnOk";
            BtnOk.Size = new Size(94, 29);
            BtnOk.TabIndex = 2;
            BtnOk.Text = "Ok";
            BtnOk.UseVisualStyleBackColor = true;
            BtnOk.Click += BtnOk_Click;
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
            PanPlayers.Location = new Point(6, 23);
            PanPlayers.Name = "PanPlayers";
            PanPlayers.Size = new Size(359, 222);
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
            NumWinLength.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NumWinLength.Location = new Point(140, 110);
            NumWinLength.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            NumWinLength.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            NumWinLength.Name = "NumWinLength";
            NumWinLength.Size = new Size(237, 27);
            NumWinLength.TabIndex = 3;
            NumWinLength.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // boardSizeSettings
            // 
            boardSizeSettings.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            boardSizeSettings.Columns = 7;
            boardSizeSettings.Location = new Point(12, 12);
            boardSizeSettings.MinimumSize = new Size(0, 92);
            boardSizeSettings.Name = "boardSizeSettings";
            boardSizeSettings.Rows = 6;
            boardSizeSettings.Size = new Size(371, 92);
            boardSizeSettings.TabIndex = 4;
            // 
            // Connect4Settings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(395, 441);
            ControlBox = false;
            Controls.Add(boardSizeSettings);
            Controls.Add(NumWinLength);
            Controls.Add(label3);
            Controls.Add(GrpPlayers);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Connect4Settings";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Connect4 Settings";
            GrpPlayers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NumWinLength).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox GrpPlayers;
        private FlowLayoutPanel PanPlayers;
        private Button BtnAddPlayer;
        private Label label3;
        private NumericUpDown NumWinLength;
        private Button BtnOk;
        private Button BtnCancel;
        private General.BoardSizeSettings boardSizeSettings;
    }
}