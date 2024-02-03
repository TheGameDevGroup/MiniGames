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
            btnColorReset = new Button();
            btnCancel = new Button();
            btnOk = new Button();
            splitContainer1 = new SplitContainer();
            groupBox6 = new GroupBox();
            NumDensity = new NumericUpDown();
            groupBox4 = new GroupBox();
            NumTileSize = new NumericUpDown();
            groupBox5 = new GroupBox();
            colorPicker5 = new General.ColorPicker();
            BtnEasy = new Button();
            BtnHard = new Button();
            BtnNormal = new Button();
            groupBox7 = new GroupBox();
            colorPicker6 = new General.ColorPicker();
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
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumDensity).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumTileSize).BeginInit();
            groupBox5.SuspendLayout();
            groupBox7.SuspendLayout();
            SuspendLayout();
            // 
            // Bombs
            // 
            Bombs.Controls.Add(NumBombs);
            Bombs.Dock = DockStyle.Fill;
            Bombs.Location = new Point(0, 0);
            Bombs.Name = "Bombs";
            Bombs.Size = new Size(133, 59);
            Bombs.TabIndex = 1;
            Bombs.TabStop = false;
            Bombs.Text = "Bomb Count";
            // 
            // NumBombs
            // 
            NumBombs.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NumBombs.Location = new Point(5, 25);
            NumBombs.Margin = new Padding(2);
            NumBombs.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            NumBombs.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumBombs.Name = "NumBombs";
            NumBombs.Size = new Size(123, 27);
            NumBombs.TabIndex = 0;
            NumBombs.Value = new decimal(new int[] { 1, 0, 0, 0 });
            NumBombs.ValueChanged += NumBombs_ValueChanged;
            // 
            // boardSizeSettings
            // 
            boardSizeSettings.Columns = 2;
            boardSizeSettings.ColumnsMaximum = new decimal(new int[] { 1000, 0, 0, 0 });
            boardSizeSettings.ColumnsMinimum = new decimal(new int[] { 2, 0, 0, 0 });
            boardSizeSettings.Location = new Point(12, 12);
            boardSizeSettings.MinimumSize = new Size(0, 92);
            boardSizeSettings.Name = "boardSizeSettings";
            boardSizeSettings.Rows = 2;
            boardSizeSettings.RowsMaximum = new decimal(new int[] { 1000, 0, 0, 0 });
            boardSizeSettings.RowsMinimum = new decimal(new int[] { 2, 0, 0, 0 });
            boardSizeSettings.Size = new Size(266, 92);
            boardSizeSettings.TabIndex = 2;
            boardSizeSettings.BoardSizeChanged += BoardSize_ValueChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(splitColors);
            groupBox1.Controls.Add(radioBtnColor);
            groupBox1.Controls.Add(radioBtnImage);
            groupBox1.Location = new Point(12, 179);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(266, 172);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Board Style";
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
            // btnColorReset
            // 
            btnColorReset.Location = new Point(284, 351);
            btnColorReset.Name = "btnColorReset";
            btnColorReset.Size = new Size(108, 29);
            btnColorReset.TabIndex = 4;
            btnColorReset.Text = "Reset Colors";
            btnColorReset.UseVisualStyleBackColor = true;
            btnColorReset.Click += btnColorReset_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(198, 459);
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
            btnOk.Location = new Point(298, 459);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(94, 29);
            btnOk.TabIndex = 5;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(12, 110);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(Bombs);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox6);
            splitContainer1.Size = new Size(266, 59);
            splitContainer1.SplitterDistance = 133;
            splitContainer1.TabIndex = 6;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(NumDensity);
            groupBox6.Dock = DockStyle.Fill;
            groupBox6.Location = new Point(0, 0);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(129, 59);
            groupBox6.TabIndex = 0;
            groupBox6.TabStop = false;
            groupBox6.Text = "Bomb Density";
            // 
            // NumDensity
            // 
            NumDensity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NumDensity.DecimalPlaces = 3;
            NumDensity.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            NumDensity.Location = new Point(6, 26);
            NumDensity.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            NumDensity.Name = "NumDensity";
            NumDensity.Size = new Size(117, 27);
            NumDensity.TabIndex = 0;
            NumDensity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            NumDensity.ValueChanged += NumDensity_ValueChanged;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(NumTileSize);
            groupBox4.Location = new Point(12, 357);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(266, 59);
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            groupBox4.Text = "Tile Size (px)";
            // 
            // NumTileSize
            // 
            NumTileSize.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NumTileSize.Location = new Point(6, 26);
            NumTileSize.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            NumTileSize.Name = "NumTileSize";
            NumTileSize.Size = new Size(254, 27);
            NumTileSize.TabIndex = 0;
            NumTileSize.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(colorPicker5);
            groupBox5.Location = new Point(284, 179);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(108, 80);
            groupBox5.TabIndex = 7;
            groupBox5.TabStop = false;
            groupBox5.Text = "Flag Color";
            // 
            // colorPicker5
            // 
            colorPicker5.Location = new Point(6, 26);
            colorPicker5.Name = "colorPicker5";
            colorPicker5.SelectedColor = Color.FromArgb(115, 167, 58);
            colorPicker5.Size = new Size(43, 48);
            colorPicker5.TabIndex = 2;
            // 
            // BtnEasy
            // 
            BtnEasy.Location = new Point(284, 12);
            BtnEasy.Name = "BtnEasy";
            BtnEasy.Size = new Size(108, 29);
            BtnEasy.TabIndex = 8;
            BtnEasy.Text = "Easy";
            BtnEasy.UseVisualStyleBackColor = true;
            BtnEasy.Click += BtnEasy_Click;
            // 
            // BtnHard
            // 
            BtnHard.Location = new Point(284, 82);
            BtnHard.Name = "BtnHard";
            BtnHard.Size = new Size(108, 29);
            BtnHard.TabIndex = 10;
            BtnHard.Text = "Hard";
            BtnHard.UseVisualStyleBackColor = true;
            BtnHard.Click += BtnHard_Click;
            // 
            // BtnNormal
            // 
            BtnNormal.Location = new Point(284, 47);
            BtnNormal.Name = "BtnNormal";
            BtnNormal.Size = new Size(108, 29);
            BtnNormal.TabIndex = 11;
            BtnNormal.Text = "Normal";
            BtnNormal.UseVisualStyleBackColor = true;
            BtnNormal.Click += BtnNormal_Click;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(colorPicker6);
            groupBox7.Location = new Point(284, 265);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(108, 80);
            groupBox7.TabIndex = 12;
            groupBox7.TabStop = false;
            groupBox7.Text = "Bomb Color";
            // 
            // colorPicker6
            // 
            colorPicker6.Location = new Point(6, 26);
            colorPicker6.Name = "colorPicker6";
            colorPicker6.SelectedColor = Color.FromArgb(115, 167, 58);
            colorPicker6.Size = new Size(43, 48);
            colorPicker6.TabIndex = 2;
            // 
            // MinesweeperSettings
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(404, 500);
            ControlBox = false;
            Controls.Add(groupBox7);
            Controls.Add(groupBox4);
            Controls.Add(BtnNormal);
            Controls.Add(BtnHard);
            Controls.Add(BtnEasy);
            Controls.Add(btnColorReset);
            Controls.Add(groupBox5);
            Controls.Add(splitContainer1);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Controls.Add(groupBox1);
            Controls.Add(boardSizeSettings);
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
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NumDensity).EndInit();
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NumTileSize).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
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
        private SplitContainer splitContainer1;
        private GroupBox groupBox4;
        private NumericUpDown NumTileSize;
        private GroupBox groupBox5;
        private General.ColorPicker colorPicker5;
        private Button BtnEasy;
        private Button BtnHard;
        private Button BtnNormal;
        private GroupBox groupBox6;
        private NumericUpDown NumDensity;
        private GroupBox groupBox7;
        private General.ColorPicker colorPicker6;
    }
}