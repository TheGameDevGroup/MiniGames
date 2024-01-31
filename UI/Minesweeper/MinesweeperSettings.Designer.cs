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
            btnColorReset = new Button();
            splitColors = new SplitContainer();
            groupBox2 = new GroupBox();
            splitContainer2 = new SplitContainer();
            colorPicker1 = new General.ColorPicker();
            colorPicker2 = new General.ColorPicker();
            groupBox3 = new GroupBox();
            splitContainer3 = new SplitContainer();
            colorPicker3 = new General.ColorPicker();
            colorPicker4 = new General.ColorPicker();
            radioBtnColor = new RadioButton();
            radioBtnImage = new RadioButton();
            btnCancel = new Button();
            btnOk = new Button();
            Bombs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumBombs).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitColors).BeginInit();
            splitColors.Panel1.SuspendLayout();
            splitColors.Panel2.SuspendLayout();
            splitColors.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            SuspendLayout();
            // 
            // Bombs
            // 
            Bombs.Controls.Add(NumBombs);
            Bombs.Location = new Point(12, 110);
            Bombs.Name = "Bombs";
            Bombs.Padding = new Padding(2);
            Bombs.Size = new Size(266, 63);
            Bombs.TabIndex = 1;
            Bombs.TabStop = false;
            Bombs.Text = "Bombs";
            // 
            // NumBombs
            // 
            NumBombs.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NumBombs.Location = new Point(4, 24);
            NumBombs.Margin = new Padding(2);
            NumBombs.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            NumBombs.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumBombs.Name = "NumBombs";
            NumBombs.Size = new Size(258, 27);
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
            boardSizeSettings.Size = new Size(266, 92);
            boardSizeSettings.TabIndex = 2;
            boardSizeSettings.BoardSizeChanged += numericUpDown_ValueChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnColorReset);
            groupBox1.Controls.Add(splitColors);
            groupBox1.Controls.Add(radioBtnColor);
            groupBox1.Controls.Add(radioBtnImage);
            groupBox1.Location = new Point(12, 179);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(266, 222);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Style";
            // 
            // btnColorReset
            // 
            btnColorReset.Location = new Point(152, 172);
            btnColorReset.Name = "btnColorReset";
            btnColorReset.Size = new Size(108, 29);
            btnColorReset.TabIndex = 4;
            btnColorReset.Text = "Reset Colors";
            btnColorReset.UseVisualStyleBackColor = true;
            btnColorReset.Click += btnColorReset_Click;
            // 
            // splitColors
            // 
            splitColors.Location = new Point(30, 86);
            splitColors.Name = "splitColors";
            // 
            // splitColors.Panel1
            // 
            splitColors.Panel1.Controls.Add(groupBox2);
            // 
            // splitColors.Panel2
            // 
            splitColors.Panel2.Controls.Add(groupBox3);
            splitColors.Size = new Size(230, 80);
            splitColors.SplitterDistance = 115;
            splitColors.TabIndex = 3;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(splitContainer2);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(115, 80);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Covered";
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(3, 23);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(colorPicker1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(colorPicker2);
            splitContainer2.Size = new Size(109, 54);
            splitContainer2.SplitterDistance = 54;
            splitContainer2.TabIndex = 0;
            // 
            // colorPicker1
            // 
            colorPicker1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            colorPicker1.Location = new Point(3, 3);
            colorPicker1.Name = "colorPicker1";
            colorPicker1.SelectedColor = Color.FromArgb(115, 167, 58);
            colorPicker1.Size = new Size(48, 48);
            colorPicker1.TabIndex = 0;
            // 
            // colorPicker2
            // 
            colorPicker2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            colorPicker2.Location = new Point(3, 3);
            colorPicker2.Name = "colorPicker2";
            colorPicker2.SelectedColor = Color.FromArgb(115, 167, 58);
            colorPicker2.Size = new Size(45, 48);
            colorPicker2.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(splitContainer3);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(0, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(111, 80);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Uncovered";
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(3, 23);
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(colorPicker3);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(colorPicker4);
            splitContainer3.Size = new Size(105, 54);
            splitContainer3.SplitterDistance = 52;
            splitContainer3.TabIndex = 0;
            // 
            // colorPicker3
            // 
            colorPicker3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            colorPicker3.Location = new Point(3, 3);
            colorPicker3.Name = "colorPicker3";
            colorPicker3.SelectedColor = Color.FromArgb(115, 167, 58);
            colorPicker3.Size = new Size(46, 48);
            colorPicker3.TabIndex = 1;
            // 
            // colorPicker4
            // 
            colorPicker4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            colorPicker4.Location = new Point(3, 3);
            colorPicker4.Name = "colorPicker4";
            colorPicker4.SelectedColor = Color.FromArgb(115, 167, 58);
            colorPicker4.Size = new Size(43, 48);
            colorPicker4.TabIndex = 1;
            // 
            // radioBtnColor
            // 
            radioBtnColor.AutoSize = true;
            radioBtnColor.Checked = true;
            radioBtnColor.Location = new Point(6, 56);
            radioBtnColor.Name = "radioBtnColor";
            radioBtnColor.Size = new Size(66, 24);
            radioBtnColor.TabIndex = 1;
            radioBtnColor.TabStop = true;
            radioBtnColor.Text = "Color";
            radioBtnColor.UseVisualStyleBackColor = true;
            radioBtnColor.CheckedChanged += radioBtnColor_CheckedChanged;
            // 
            // radioBtnImage
            // 
            radioBtnImage.AutoSize = true;
            radioBtnImage.Location = new Point(6, 26);
            radioBtnImage.Name = "radioBtnImage";
            radioBtnImage.Size = new Size(72, 24);
            radioBtnImage.TabIndex = 0;
            radioBtnImage.Text = "Image";
            radioBtnImage.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(84, 441);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.Location = new Point(184, 441);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(94, 29);
            btnOk.TabIndex = 5;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // MinesweeperSettings
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(290, 482);
            ControlBox = false;
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Controls.Add(groupBox1);
            Controls.Add(boardSizeSettings);
            Controls.Add(Bombs);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MinesweeperSettings";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Minesweeper Settings";
            Bombs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NumBombs).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            splitColors.Panel1.ResumeLayout(false);
            splitColors.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitColors).EndInit();
            splitColors.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox Bombs;
        private NumericUpDown NumBombs;
        private General.BoardSizeSettings boardSizeSettings;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private General.ColorPicker colorPicker3;
        private General.ColorPicker colorPicker2;
        private General.ColorPicker colorPicker4;
        private General.ColorPicker colorPicker1;
        private RadioButton radioBtnColor;
        private RadioButton radioBtnImage;
        private SplitContainer splitColors;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private Button btnCancel;
        private Button btnOk;
        private Button btnColorReset;
    }
}