namespace UI.General
{
	public partial class GameBoardBase : UserControl
	{
		public GameBoardBase()
		{
			InitializeComponent();
		}
		public void UpdateUI()
		{
			if (myPictureBox.InvokeRequired)
			{
				myPictureBox.Invoke(myPictureBox.Refresh);
			}
			else
			{
				myPictureBox.Refresh();
			}
		}
		public void ReSizeBoard(int width, int height)
		{
			if (myPictureBox.InvokeRequired)
			{
				myPictureBox.Invoke(() => { myPictureBox.Size = new(width, height); });
			}
			else
			{
				myPictureBox.Size = new(width, height);
			}
			if (myPictureBox.IsHandleCreated)
			{
				UpdateUI();
			}
		}
	}
}
