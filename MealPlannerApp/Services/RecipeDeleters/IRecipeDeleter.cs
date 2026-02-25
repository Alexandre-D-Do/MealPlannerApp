using MealPlannerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlannerApp.Services.RecipeDeleters
{
    public interface IRecipeDeleter
    {
        Task DeleteRecipe(Recipe recipe);
    }
}
