using Connect4;

namespace UI
{
    public partial class Connect4UI : Form
    {
        List<IConnect4Player> players = new();
        public Connect4UI()
        {
            InitializeComponent();
            HumanPlayer player1 = new();
            HumanPlayer player2 = new();
            HumanPlayer player3 = new();
            board1.MoveClick += (object? sender, int column) =>
            {
                player1.SubmitMove(column);
                player2.SubmitMove(column);
                player3.SubmitMove(column);
            };
            board1.ColorMap[1] = Color.Red;
            board1.ColorMap[2] = Color.Blue;
            board1.ColorMap[3] = Color.Green;
            players.Add(player1);
            players.Add(player2);
            //players.Add(player3);
            board1.SetTokenSize(70);
            int rows = 6, columns = 7;
            board1.Reset(rows, columns);
            Game game = new(rows, columns, players);
            game.OnMove += (object? sender, int[,] state) => { board1.Update(state); };
            Task.Run(() =>
            {
                int result = game.Play();
                if (result == -1)
                {
                    MessageBox.Show("Stalemate");
                }
                else
                {
                    MessageBox.Show($"{board1.ColorMap[result + 1].Name} Wins.");
                }
            });
        }
    }
}
