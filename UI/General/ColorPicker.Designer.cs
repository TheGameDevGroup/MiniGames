namespace UI.General
{
    partial class ColorPicker
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
            BtnColor = new Button();
            DiaColor = new ColorDialog();
            SuspendLayout();
            // 
            // BtnColor
            // 
            BtnColor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BtnColor.Location = new Point(0, 0);
            BtnColor.Name = "BtnColor";
            BtnColor.Size = new Size(29, 29);
            BtnColor.TabIndex = 4;
            BtnColor.UseVisualStyleBackColor = true;
            BtnColor.Click += BtnColor_Click;
            // 
            // DiaColor
            // 
            DiaColor.Color = Color.Blue;
            // 
            // ColorPicker
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(BtnColor);
            Name = "ColorPicker";
            Size = new Size(29, 29);
            ResumeLayout(false);
        }

        #endregion

        private Button BtnColor;
        private ColorDialog DiaColor;
    }
}
