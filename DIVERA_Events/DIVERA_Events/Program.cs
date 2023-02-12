using Microsoft.Extensions.Configuration;

namespace DIVERA_Events
{
    internal static class Program
    {
        public static IConfiguration Configuration;

        [STAThread]
        static void Main()
        {
            var builder = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}