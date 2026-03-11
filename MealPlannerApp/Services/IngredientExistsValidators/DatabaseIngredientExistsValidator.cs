using MealPlannerApp.DbContexts;
using MealPlannerApp.DTOs;
using MealPlannerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlannerApp.Services.IngredientExistsValidators
{
    public class DatabaseIngredientExistsValidator : IIngredientExistsValidator
    {
        string _connectionstring;

        public async Task<Ingredient> GetConflictingIngredient(Ingredient ingredient)
        {
            var contextoptions = new DbContextOptionsBuilder<MealPlannerAppDbContext>()
                .UseSqlite(_connectionstring).Options;

            using (MealPlannerAppDbContext context = new MealPlannerAppDbContext(contextoptions))
            {
                var ingredientDTO = await context.Ingredients.Where(i => i.Name.ToLower().Trim()
                == ingredient.Name.ToLower().Trim()).FirstOrDefaultAsync();
                if (ingredientDTO == null)
                {
                    return null;
                }
                else
                {
                    return ToIngredient(ingredientDTO);
                }
            }
        }

        private static Ingredient ToIngredient(IngredientDTO ingredientDTO)
        {
            return new Ingredient(ingredientDTO.Name, ingredientDTO.IsStocked);
        }
    }
}
