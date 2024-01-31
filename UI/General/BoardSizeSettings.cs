namespace UI.General
{
    public partial class BoardSizeSettings : UserControl
    {
        public event EventHandler? BoardSizeChanged;
        public int Rows
        {
            get { return (int)NumRows.Value; }
            set
            {
                NumRows.Value = value;
                BoardSizeChanged?.Invoke(this, new());
            }
        }
        public int Columns
        {
            get { return (int)NumColumns.Value; }
            set
            {
                NumColumns.Value = value;
                BoardSizeChanged?.Invoke(this, new());
            }
        }
        public BoardSizeSettings()
        {
            InitializeComponent();
        }

        private void Num_ValueChanged(object sender, EventArgs e)
        {
            BoardSizeChanged?.Invoke(this, new());
        }
    }
}
