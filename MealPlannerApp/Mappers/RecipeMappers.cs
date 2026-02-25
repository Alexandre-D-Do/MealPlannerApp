using System;
using System.Collections.ObjectModel;
using System.Linq;
using MealPlannerApp.DTOs;
using MealPlannerApp.Models;
using System.Collections.Generic;

namespace MealPlannerApp.Mappers
{
    public static class RecipeMappers
    {
        // Map Model -> DTO. Note: this creates new IngredientDTO entries for every ingredient name.
        // To reuse existing Ingredient rows (shared ingredients) you should resolve Ingredients by name/Id
        // using your repository before creating RecipeIngredientDTO entries.
        public static RecipeDTO ToDTO(this Recipe model)
        {
            if (model == null) return null;

            var recipeId = Guid.NewGuid();

            var dto = new RecipeDTO
            {
                Id = recipeId,
                Name = model.Name,
                Cuisine = model.Cuisine,
                Servings = model.Servings,
            };

            // Ingredients -> RecipeIngredients (creates new IngredientDTOs)
            foreach (var ingredient in model.Ingredients ?? new ObservableCollection<Ingredient>())
            {
                var ingredientDto = new IngredientDTO
                {
                    Id = Guid.NewGuid(),
                    Name = ingredient.Name,
                    IsStocked = ingredient.IsStocked
                };

                var ri = new RecipeIngredientDTO
                {
                    RecipeId = recipeId,
                    IngredientId = ingredientDto.Id,
                    Ingredient = ingredientDto
                };

                dto.RecipeIngredients.Add(ri);
            }

            // Steps
            int idx = 0;
            foreach (var step in model.Steps ?? new ObservableCollection<string>())
            {
                dto.Steps.Add(new StepDTO
                {
                    Id = Guid.NewGuid(),
                    RecipeId = recipeId,
                    Order = idx++,
                    Description = step
                });
            }

            return dto;
        }

        

        // Map DTO -> Model
        public static Recipe ToModel(this RecipeDTO dto)
        {
            if (dto == null) return null;

            var model = new Recipe
            {
                Name = dto.Name,
                Cuisine = dto.Cuisine,
                Servings = dto.Servings,
                Ingredients = new ObservableCollection<Ingredient>(),
                Steps = new ObservableCollection<string>()
            };

            // Build ingredients from RecipeIngredients join
            foreach (var ri in dto.RecipeIngredients ?? new List<RecipeIngredientDTO>())
            {
                if (ri.Ingredient == null) continue;
                model.Ingredients.Add(new Ingredient
                {
                    Name = ri.Ingredient.Name,
                    IsStocked = ri.Ingredient.IsStocked
                });
            }

            foreach (var step in (dto.Steps ?? new List<StepDTO>()).OrderBy(s => s.Order))
            {
                model.Steps.Add(step.Description);
            }

            return model;
        }
    }
}
