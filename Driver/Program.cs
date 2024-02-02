using MinesweeperBackend;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

CheckProbablities(1000000);

void CheckProbablities(int iterations)
{
	int rows = 16, columns = 30, bombs = 99;
	int[,] results = new int[rows, columns];
	for (int i = 0; i < iterations; i++)
	{
		Game game = new(rows, columns, bombs, new HumanPlayer());
		var bombArray = game.GetBombs();
		for (int row = 0; row < rows; row++)
		{
			for (int column = 0; column < columns; column++)
			{
				results[row, column] += bombArray[row, column] ? 1 : 0;
			}
		}
	}
	// flatten the array
	int[] flatResults = new int[rows * columns];
	int Sum = 0;
	int Min = int.MaxValue, Max = 0;
	(int, int) MinIndex = (-1, -1);
	(int, int) MaxIndex = (-1, -1);
    for (int row = 0; row < rows; row++)
	{
		for (int column = 0; column < columns; column++)
		{
			var value = results[row, column];
			flatResults[row * columns + column] = value;
			Sum += value;
			if (value < Min)
			{
                Min = value;
				MinIndex = (row, column);
            }
			if (value > Max)
			{
				Max = value;
				MaxIndex = (row, column);
			}
		}
	}
	int Average = Sum / (rows * columns);
	int Variance = 0;
	foreach (int result in flatResults)
	{
		Variance += (result - Average) * (result - Average);
	}
	Variance /= (rows * columns);
	Console.WriteLine($"Average: {Average}, Variance: {Variance}, Standard Deviation: {Math.Sqrt(Variance)}");
	Console.WriteLine($"Expected Bomb Count For Each: {(iterations * bombs) / (rows * columns)}");
	Console.WriteLine($"Min: {Min} at {MinIndex.Item1}, {MinIndex.Item2}, Max: {Max} at {MaxIndex.Item1}, {MaxIndex.Item2}");
}
