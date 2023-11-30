namespace UI.General
{
	partial class GenericPlayerSettings<TEnum>
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
            TxtName = new TextBox();
            DiaColor = new ColorDialog();
            BtnColor = new Button();
            BtnRemove = new Button();
            SuspendLayout();
            // 
            // TxtName
            // 
            TxtName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TxtName.Location = new Point(38, 4);
            TxtName.Name = "TxtName";
            TxtName.Size = new Size(224, 27);
            TxtName.TabIndex = 2;
            // 
            // BtnColor
            // 
            BtnColor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnColor.Location = new Point(268, 3);
            BtnColor.Name = "BtnColor";
            BtnColor.Size = new Size(29, 29);
            BtnColor.TabIndex = 3;
            BtnColor.UseVisualStyleBackColor = true;
            BtnColor.MouseUp += BtnColor_Click;
            // 
            // BtnRemove
            // 
            BtnRemove.Location = new Point(3, 3);
            BtnRemove.Name = "BtnRemove";
            BtnRemove.Size = new Size(29, 29);
            BtnRemove.TabIndex = 4;
            BtnRemove.Text = "-";
            BtnRemove.UseVisualStyleBackColor = true;
            BtnRemove.MouseUp += BtnRemove_MouseUp;
            // 
            // GenericPlayerSettings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(BtnRemove);
            Controls.Add(BtnColor);
            Controls.Add(TxtName);
            Name = "GenericPlayerSettings";
            Size = new Size(300, 35);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox TxtName;
		private ColorDialog DiaColor;
		private Button BtnColor;
		private Button BtnRemove;
	}
}
