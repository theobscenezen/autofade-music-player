using Microsoft.Extensions.DependencyInjection;

namespace MusicPlayer;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        using (var provider = services.BuildServiceProvider())
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var form1 = provider.GetRequiredService<MainForm>();
            Application.Run(form1);   
        }
    }

    private static void ConfigureServices(ServiceCollection services)
    {
        services.AddTransient<MainForm>();
    }
}