using MealPlannerApp.DbContexts;
using MealPlannerApp.DTOs;
using MealPlannerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlannerApp.Services.IngredientRemovers
{
    public class DatabaseIngredientRemover : IIngredientRemover
    {
        private string _connectionString;

        public DatabaseIngredientRemover(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task RemoveIngredient(Ingredient ingredient)
        {
            var contextOptions = new DbContextOptionsBuilder<MealPlannerAppDbContext>().UseSqlite(_connectionString).Options;
            using (MealPlannerAppDbContext context = new MealPlannerAppDbContext(contextOptions))
            {
                IngredientDTO ingredientDTO = ToIngredientDTO(ingredient);
                var ingredientToRemove = await context.Ingredients.FirstOrDefaultAsync(i => i.Name == ingredientDTO.Name);
                if (ingredientToRemove != null) {
                    context.Ingredients.Remove(ingredientToRemove);
                    await context.SaveChangesAsync();
                }
            }
        }

        private static IngredientDTO ToIngredientDTO(Ingredient ingredient)
        {
            return new IngredientDTO
            {
                Name = ingredient.Name,
                IsStocked = ingredient.IsStocked
            };
        }
    }
}
