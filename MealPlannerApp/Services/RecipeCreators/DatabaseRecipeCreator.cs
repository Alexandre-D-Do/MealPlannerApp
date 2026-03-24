using MealPlannerApp.DbContexts;
using MealPlannerApp.DTOs;
using MealPlannerApp.Mappers;
using MealPlannerApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlannerApp.Services.RecipeCreators
{
    public class DatabaseRecipeCreator : IRecipeCreator
    {
        private readonly string _connectionString;

        public DatabaseRecipeCreator(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task CreateRecipe(Recipe recipe)
        {
            var contextOptions = new DbContextOptionsBuilder<MealPlannerAppDbContext>().UseSqlite(_connectionString).Options;

            using (MealPlannerAppDbContext context = new MealPlannerAppDbContext(contextOptions))
            {
                // Collect the ingredient names used by this recipe
                var ingredientNames = recipe.Ingredients?
                    .Select(i => i.Name)
                    .Where(n => !string.IsNullOrEmpty(n))
                    .Distinct()
                    .ToList() ?? new List<string>();

                // Look up any that already exist in the database
                var existingIngredients = await context.Ingredients
                    .Where(i => ingredientNames.Contains(i.Name))
                    .ToDictionaryAsync(i => i.Name);

                // Map to DTO, reusing existing ingredient rows
                var recipeDTO = recipe.ToDTO(existingIngredients);

                // Only attach truly new IngredientDTOs — existing ones are already tracked
                foreach (var ri in recipeDTO.RecipeIngredients)
                {
                    if (!existingIngredients.ContainsKey(ri.Ingredient.Name))
                    {
                        context.Ingredients.Add(ri.Ingredient);
                    }
                    else
                    {
                        context.Entry(ri.Ingredient).State = EntityState.Unchanged;
                    }
                }

                context.Recipes.Add(recipeDTO);
                await context.SaveChangesAsync();
            }
        }
    }
}
