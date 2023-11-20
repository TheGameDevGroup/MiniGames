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
            board1.Location = new Point(12, 11);
            board1.Margin = new Padding(3, 2, 3, 2);
            board1.Name = "board1";
            board1.Size = new Size(751, 617);
            board1.TabIndex = 0;
            // 
            // Connect4UI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(786, 639);
            Controls.Add(board1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Connect4UI";
            Text = "Connect4UI";
            ResumeLayout(false);
        }

        #endregion

        private Board board1;
    }
}