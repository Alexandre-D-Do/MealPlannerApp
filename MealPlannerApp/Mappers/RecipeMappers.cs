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
        // Map Model -> DTO.
        // Pass existingIngredients (name -> IngredientDTO) to reuse existing rows and avoid
        // violating the unique index on IngredientDTO.Name. Any ingredient not found in the
        // lookup will have a new IngredientDTO created for it.
        public static RecipeDTO ToDTO(this Recipe model, IReadOnlyDictionary<string, IngredientDTO> existingIngredients = null)
        {
            if (model == null) return null;

            var recipeId = Guid.NewGuid();

            var dto = new RecipeDTO
            {
                RecipeId = recipeId,
                Name = model.Name,
                Cuisine = model.Cuisine,
                Servings = model.Servings,
            };

            foreach (var ingredient in model.Ingredients ?? new ObservableCollection<RecipeIngredient>())
            {
                IngredientDTO ingredientDto;
                if (existingIngredients != null && existingIngredients.TryGetValue(ingredient.Name, out var existing))
                {
                    ingredientDto = existing;
                }
                else
                {
                    ingredientDto = new IngredientDTO
                    {
                        IngredientId = Guid.NewGuid(),
                        Name = ingredient.Name,
                        IsStocked = ingredient.IsStocked
                    };
                }

                var ri = new RecipeIngredientDTO
                {
                    RecipeId = recipeId,
                    IngredientId = ingredientDto.IngredientId,
                    Ingredient = ingredientDto,
                    Quantity = ingredient.Quantity,
                    Unit = ingredient.Unit
                };

                dto.RecipeIngredients.Add(ri);
            }

            // Steps
            int idx = 0;
            foreach (var step in model.Steps ?? new ObservableCollection<string>())
            {
                dto.Steps.Add(new StepDTO
                {
                    StepId = Guid.NewGuid(),
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
                Ingredients = new ObservableCollection<RecipeIngredient>(),
                Steps = new ObservableCollection<string>()
            };

            // Build ingredients from RecipeIngredients join
            foreach (var ri in dto.RecipeIngredients ?? new List<RecipeIngredientDTO>())
            {
                if (ri.Ingredient == null) continue;
                var riModel = new RecipeIngredient(ri.Ingredient.Name, ri.Ingredient.IsStocked, ri.Quantity, ri.Unit);

                model.Ingredients.Add(riModel);
            }

            foreach (var step in (dto.Steps ?? new List<StepDTO>()).OrderBy(s => s.Order))
            {
                model.Steps.Add(step.Description);
            }

            return model;
        }
    }
}
