using MealPlannerApp.Services;
using MealPlannerApp.Services.Dialogs;
using MealPlannerApp.Stores;
using MealPlannerApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlannerApp.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
            services.AddTransient<HomePageViewModel>((s) => CreateHomePageViewModel(s));
            services.AddSingleton<Func<HomePageViewModel>>((s) => () => s.GetRequiredService<HomePageViewModel>());
            services.AddSingleton<NavigationService<HomePageViewModel>>();

            services.AddTransient<AddRecipeViewModel>();
            services.AddSingleton<Func<AddRecipeViewModel>>((s) => () => s.GetRequiredService<AddRecipeViewModel>());
            services.AddSingleton<NavigationService<AddRecipeViewModel>>();

            services.AddSingleton<MainWindowViewModel>();
            });
            return hostBuilder;
        }

        // LoadViewModel is used in order to call the LoadData method, which uses the Initialize method of the ApplicationDataStore to load the data from the database using Update methods.
        private static HomePageViewModel CreateHomePageViewModel(IServiceProvider services)
        {
            return HomePageViewModel.LoadViewModel(
                services.GetRequiredService<ApplicationDataStore>(),
                services.GetRequiredService<IDialogService>(),
                services.GetRequiredService<NavigationService<AddRecipeViewModel>>());
        }
    }
}
