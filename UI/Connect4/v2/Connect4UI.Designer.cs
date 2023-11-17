namespace UI.Connect4.v2
{
    partial class Connect4UI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Connect4UI));
            board1 = new Board();
            SuspendLayout();
            // 
            // board1
            // 
            board1.ColorMap = (List<Color>)resources.GetObject("board1.ColorMap");
            board1.Location = new Point(12, 12);
            board1.Name = "board1";
            board1.Size = new Size(744, 616);
            board1.TabIndex = 0;
            // 
            // Connect4UI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(768, 640);
            Controls.Add(board1);
            Name = "Connect4UI";
            Text = "Connect4UI";
            ResumeLayout(false);
        }

        #endregion

        private Board board1;
    }
}