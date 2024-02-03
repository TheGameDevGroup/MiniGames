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
        public decimal RowsMinimum
        {
            get { return NumRows.Minimum; }
            set { NumRows.Minimum = value; }
        }
        public decimal RowsMaximum
        {
            get { return NumRows.Maximum; }
            set { NumRows.Maximum = value; }
        }
        public decimal ColumnsMinimum
        {
            get { return NumColumns.Minimum; }
            set { NumColumns.Minimum = value; }
        }
        public decimal ColumnsMaximum
        {
            get { return NumColumns.Maximum; }
            set { NumColumns.Maximum = value; }
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
