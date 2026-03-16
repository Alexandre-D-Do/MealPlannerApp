using MealPlannerApp.DbContexts;
using MealPlannerApp.DTOs;
using MealPlannerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlannerApp.Services.IngredientCreators
{
    public class DatabaseIngredientCreator : IIngredientCreator
    {
        private string _connectionString;

        public DatabaseIngredientCreator(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task CreateIngredient(Ingredient ingredient)
        {
            var contextOptions = new DbContextOptionsBuilder<MealPlannerAppDbContext>().UseSqlite(_connectionString).Options;

            using (MealPlannerAppDbContext context = new MealPlannerAppDbContext(contextOptions))
            {
                IngredientDTO ingredientDTO = ToIngredientDTO(ingredient);
                context.Ingredients.Add(ingredientDTO);
                await context.SaveChangesAsync();
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
