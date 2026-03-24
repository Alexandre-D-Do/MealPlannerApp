using MealPlannerApp.Services.Dialogs;
using MealPlannerApp.Services.IngredientCreators;
using MealPlannerApp.Services.IngredientExistsValidators;
using MealPlannerApp.Services.IngredientProviders;
using MealPlannerApp.Services.IngredientRemovers;
using MealPlannerApp.Services.RecipeCreators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlannerApp.HostBuilders
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((hostContext, services) =>
            {
                var connectionString = hostContext.Configuration.GetConnectionString("MealPlannerDatabase");
                services.AddSingleton<IIngredientCreator, DatabaseIngredientCreator>((s) => new DatabaseIngredientCreator(connectionString));
                services.AddSingleton<IIngredientRemover, DatabaseIngredientRemover>((s) => new DatabaseIngredientRemover(connectionString));
                services.AddSingleton<IIngredientProvider, DatabaseIngredientProvider>((s) => new DatabaseIngredientProvider(connectionString));
                services.AddSingleton<IIngredientExistsValidator, DatabaseIngredientExistsValidator>((s) => new DatabaseIngredientExistsValidator(connectionString));
                services.AddSingleton<IRecipeCreator, DatabaseRecipeCreator>((s) => new DatabaseRecipeCreator(connectionString));
                services.AddSingleton<IDialogService, DialogService>();
            });
            return hostBuilder;
        }
    }
}
