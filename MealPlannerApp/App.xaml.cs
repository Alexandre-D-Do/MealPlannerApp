using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Windows;

namespace MealPlannerApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder().ConfigureServices((hostcontext, services) =>
                {
                    string connectionString = hostcontext.Configuration.GetConnectionString("MealPlannerDatabase");
                })
                .Build();
        }

    }

}
