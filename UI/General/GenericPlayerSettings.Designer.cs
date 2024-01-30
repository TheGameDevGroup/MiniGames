namespace UI.General
{
	partial class GenericPlayerSettings
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
            BtnRemove = new Button();
            colorPicker = new ColorPicker();
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
            // colorPicker
            // 
            colorPicker.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            colorPicker.Location = new Point(268, 3);
            colorPicker.Name = "colorPicker";
            colorPicker.SelectedColor = Color.FromArgb(205, 97, 169);
            colorPicker.Size = new Size(29, 29);
            colorPicker.TabIndex = 5;
            // 
            // GenericPlayerSettings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(colorPicker);
            Controls.Add(BtnRemove);
            Controls.Add(TxtName);
            Name = "GenericPlayerSettings";
            Size = new Size(300, 35);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox TxtName;
		private Button BtnRemove;
        private ColorPicker colorPicker;
    }
}
