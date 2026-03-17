using MealPlannerApp.Services.RecipeCreators;
using MealPlannerApp.Services.RecipeRemovers;
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
        private readonly IRecipeRemover _recipeRemover;
        private readonly IRecipeProvider _recipeProvider;
        private readonly IRecipeExistsValidator _recipeExistsValidator;

        public RecipeBook(IRecipeCreator recipeCreator, IRecipeRemover recipeRemover, IRecipeProvider recipeProvider, IRecipeExistsValidator recipeExistsValidator)
        {
            _recipeCreator = recipeCreator;
            _recipeRemover = recipeRemover;
            _recipeProvider = recipeProvider;
            _recipeExistsValidator = recipeExistsValidator;
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipes()
        {
            return await _recipeProvider.GetAllRecipes();
        }

    }
}
