namespace Lab8;
using System.Data.SqlClient;
public partial class LoginForm : Form
{
    public LoginForm()
    {
        InitializeComponent();
    }

    private void LoginForm_Load(object sender, EventArgs e)
    {
        MaximizeBox = false;
        MinimizeBox = false;
        passwordInput.PasswordChar = '*';
    }

    private void passwordInput_TextChanged(object sender, EventArgs e)
    {

    }

    private async void Connect(object sender, EventArgs e)
    {
        try
        {
            var login = loginInput.Text.Trim();
            var password = passwordInput.Text.Trim();
            var connectionString = $"Data Source=LAIGE\\SQLEXPRESS;Initial Catalog=Restaurant_2;User Id={login};Password={password};";

            var conn = new SqlConnection(connectionString);
            await conn.OpenAsync();

            var mainForm = new MainForm(conn);
            mainForm.Show();

            FormClosedEventHandler handler = async (_, _) =>
            {
                Show();
                await conn.CloseAsync();
            };
            mainForm.FormClosed += handler;

            Hide();
        }
        catch (SqlException ex)
        {
            MessageBox.Show(ex.Message, "Error while connecting");
        }
        finally
        {
            loginInput.Clear();
            passwordInput.Clear();
        }
    }
}
