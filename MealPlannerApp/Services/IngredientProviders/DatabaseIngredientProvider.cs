using MealPlannerApp.DbContexts;
using MealPlannerApp.DTOs;
using MealPlannerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlannerApp.Services.IngredientProviders
{
    public class DatabaseIngredientProvider : IIngredientProvider
    {
        private string _connectionString;

        public DatabaseIngredientProvider(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<IEnumerable<Ingredient>> GetAllIngredients()
        {
            var contextoptions = new DbContextOptionsBuilder<MealPlannerAppDbContext>().UseSqlite(_connectionString).Options;
            using (MealPlannerAppDbContext context = new MealPlannerAppDbContext(contextoptions))
            {
                IEnumerable<IngredientDTO> ingredientDTOs = await context.Ingredients.ToListAsync();
                return ingredientDTOs.Select(ingredient => ToIngredient(ingredient));
            }
        }

        private static Ingredient ToIngredient(IngredientDTO ingredientDTO)
        {
            return new Ingredient(ingredientDTO.Name, ingredientDTO.IsStocked);
        }
    }
}
