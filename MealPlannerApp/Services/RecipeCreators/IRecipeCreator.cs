using MealPlannerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlannerApp.Services.RecipeCreators
{
    public interface IRecipeCreator
    {
        Task CreateRecipe(Recipe recipe);
    }
}
