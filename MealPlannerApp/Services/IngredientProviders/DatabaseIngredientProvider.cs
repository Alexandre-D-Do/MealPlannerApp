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
                var ingredientDTOs = await context.Ingredients
                    .Include(i => i.RecipeIngredients)
                    .ThenInclude(ri => ri.Recipe)
                    .ToListAsync();

                return ingredientDTOs.Select(ingredient => ToIngredient(ingredient));
            }
        }

        private static Ingredient ToIngredient(IngredientDTO ingredientDTO)
        {
            var ingredient = new Ingredient(ingredientDTO.Name, ingredientDTO.IsStocked);

            // Surface recipe names that reference this ingredient
            if (ingredientDTO.RecipeIngredients != null)
            {
                var names = ingredientDTO.RecipeIngredients
                    .Where(ri => ri.Recipe != null && !string.IsNullOrEmpty(ri.Recipe.Name))
                    .Select(ri => ri.Recipe.Name)
                    .Distinct()
                    .ToList();

                ingredient.Recipes = names;
            }

            return ingredient;
        }
    }
}
