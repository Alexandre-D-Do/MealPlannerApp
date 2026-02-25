using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlannerApp.DTOs
{
    // Join entity for many-to-many between Recipe and Ingredient.
    public class RecipeIngredientDTO
    {
        public Guid RecipeId { get; set; }

        public Guid IngredientId { get; set; }

        // Optional per-recipe metadata
        public decimal? Quantity { get; set; }

        public string Unit { get; set; }

        [ForeignKey(nameof(RecipeId))]
        public RecipeDTO Recipe { get; set; }

        [ForeignKey(nameof(IngredientId))]
        public IngredientDTO Ingredient { get; set; }
    }
}
