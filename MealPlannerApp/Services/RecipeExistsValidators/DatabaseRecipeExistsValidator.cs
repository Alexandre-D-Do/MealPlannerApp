using MealPlannerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlannerApp.Services.RecipeExistsValidators
{
    public class DatabaseRecipeExistsValidator : IRecipeExistsValidator
    {
        public Task<Recipe> GetConflictingRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
