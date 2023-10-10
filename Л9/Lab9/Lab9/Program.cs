using System.Configuration;

namespace Lab9;

internal static class Program
{
    [STAThread] static void Main()
    {
        var connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1(connectionString));
    }
}