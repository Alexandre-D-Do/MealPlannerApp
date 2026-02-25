using MealPlannerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlannerApp.Services.IngredientProviders
{
    public interface IIngredientProvider
    {
        Task<IEnumerable<Ingredient>> GetAllIngredients();
    }
}
