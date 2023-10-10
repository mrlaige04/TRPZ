namespace Lab9;

public partial class Form1 : Form
{
    private readonly string _connectionString;

    public Form1(string connectionString)
    {
        InitializeComponent();
        _connectionString = connectionString;
    }
}
