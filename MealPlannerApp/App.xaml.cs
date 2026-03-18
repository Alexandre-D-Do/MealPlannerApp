using MealPlannerApp.DbContexts;
using MealPlannerApp.Stores;
using MealPlannerApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Navigation;

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

                    services.AddDbContext<MealPlannerAppDbContext>(options => options.UseSqlite(connectionString));

                    services.AddTransient<HomePageViewModel>((s) => CreateHomePageViewModel(s));
                    services.AddSingleton<MainWindowViewModel>();

                    services.AddSingleton(s => new MainWindow()
                    {
                        DataContext = s.GetRequiredService<MainWindowViewModel>()
                    });
                })
                .Build();
        }

        private static HomePageViewModel CreateHomePageViewModel(IServiceProvider services)
        {
            return HomePageViewModel.LoadViewModel(
                services.GetRequiredService<ApplicationDataStore>(),
                services.GetRequiredService<NavigationService<AddIngredientViewModel>>());
        }



    }

}
