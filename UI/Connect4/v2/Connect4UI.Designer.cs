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
            board1 = new Connect4Board();
            menuStrip1 = new MenuStrip();
            MenuSettings = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // board1
            // 
            board1.Location = new Point(12, 27);
            board1.Name = "board1";
            board1.Size = new Size(800, 803);
            board1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { MenuSettings });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(898, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // MenuSettings
            // 
            MenuSettings.Name = "MenuSettings";
            MenuSettings.Size = new Size(76, 24);
            MenuSettings.Text = "Settings";
            MenuSettings.Click += MenuSettings_Click;
            // 
            // Connect4UI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(898, 852);
            Controls.Add(board1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Connect4UI";
            Text = "Connect4UI";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Connect4Board board1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem MenuSettings;
    }
}