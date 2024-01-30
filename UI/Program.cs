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
			//Application.Run(new Connect4.v2.Connect4UI());
			//Application.Run(new Minesweeper.MinesweeperUI());
			//Application.Run(new Connect4.v2.Connect4Settings());
			Application.Run(new Minesweeper.MinesweeperSettings());
		}
	}
}