using MealPlannerApp.Services.RecipeCreators;
using MealPlannerApp.Services.RecipeDeleters;
using MealPlannerApp.Services.RecipeExistsValidators;
using MealPlannerApp.Services.RecipeProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlannerApp.Models
{
    public class RecipeBook
    {
        private readonly IRecipeCreator _recipeCreator;
        private readonly IRecipeDeleter _recipeDeleter;
        private readonly IRecipeProvider _recipeProvider;
        private readonly IRecipeExistsValidator _recipeExistsValidator;

        public RecipeBook(IRecipeCreator recipeCreator, IRecipeDeleter recipeDeleter, IRecipeProvider recipeProvider, IRecipeExistsValidator recipeExistsValidator)
        {
            _recipeCreator = recipeCreator;
            _recipeDeleter = recipeDeleter;
            _recipeProvider = recipeProvider;
            _recipeExistsValidator = recipeExistsValidator;
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipes()
        {
            return _recipeProvider.GetAllRecipes();
        }

    }
}
