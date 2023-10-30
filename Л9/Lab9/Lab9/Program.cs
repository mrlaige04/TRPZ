using System.Configuration;
using System.Data.SqlClient;

namespace Lab9;

internal static class Program
{
    [STAThread] static void Main()
    {
        var connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        using var connection = new SqlConnection(connectionString);
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1(connection));
    }
}