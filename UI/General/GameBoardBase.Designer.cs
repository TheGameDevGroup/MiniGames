namespace UI.General
{
    partial class GameBoardBase
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
            myPictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)myPictureBox).BeginInit();
            SuspendLayout();
            // 
            // myPictureBox
            // 
            myPictureBox.Location = new Point(0, 0);
            myPictureBox.Name = "myPictureBox";
            myPictureBox.Size = new Size(258, 223);
            myPictureBox.TabIndex = 0;
            myPictureBox.TabStop = false;
            // 
            // GameBoardBase
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(myPictureBox);
            Name = "GameBoardBase";
            Size = new Size(359, 363);
            ((System.ComponentModel.ISupportInitialize)myPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        protected PictureBox myPictureBox;
    }
}
