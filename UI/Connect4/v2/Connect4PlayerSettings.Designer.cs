namespace UI.Connect4.v2
{
    partial class Connect4PlayerSettings
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
            ComboType = new ComboBox();
            SuspendLayout();
            // 
            // ComboType
            // 
            ComboType.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboType.FormattingEnabled = true;
            ComboType.Location = new Point(38, 37);
            ComboType.Name = "ComboType";
            ComboType.Size = new Size(230, 28);
            ComboType.TabIndex = 5;
            ComboType.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
            // 
            // Connect4PlayerSettings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ComboType);
            Name = "Connect4PlayerSettings";
            Size = new Size(271, 68);
            Controls.SetChildIndex(ComboType, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox ComboType;
    }
}
