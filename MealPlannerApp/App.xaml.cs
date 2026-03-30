using MealPlannerApp.DbContexts;
using MealPlannerApp.HostBuilders;
using MealPlannerApp.Models;
using MealPlannerApp.Services;
using MealPlannerApp.Services.Dialogs;
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
            _host = Host.CreateDefaultBuilder().AddServices().AddViewModels().ConfigureServices((hostcontext, services) =>
                {
                    string connectionString = hostcontext.Configuration.GetConnectionString("MealPlannerDatabase");

                    services.AddDbContext<MealPlannerAppDbContext>(options => options.UseSqlite(connectionString));

                    services.AddSingleton<IngredientBook>();
                    services.AddSingleton<ApplicationDataStore>();
                    services.AddSingleton<NavigationStore>();
                    

                    services.AddSingleton(s => new MainWindow()
                    {
                        DataContext = s.GetRequiredService<MainWindowViewModel>()
                    });
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            using (MealPlannerAppDbContext mealPlannerAppDbContext = _host.Services.GetRequiredService<MealPlannerAppDbContext>())
            {
                mealPlannerAppDbContext.Database.Migrate();
            }

            //Initial Navigation
            NavigationService<HomePageViewModel> navigationService = _host.Services.GetRequiredService<NavigationService<HomePageViewModel>>();
            navigationService.Navigate();
            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host?.Dispose();
            base.OnExit(e);
        }


    }

}
