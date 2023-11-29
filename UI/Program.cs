namespace UI
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			//Application.Run(new Connect4.v2.Connect4UI(6, 7));
			Application.Run(new Minesweeper.MinesweeperUI(15, 30, 20, new MinesweeperBackend.HumanPlayer(), true));
		}
	}
}