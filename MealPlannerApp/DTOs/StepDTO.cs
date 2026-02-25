using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlannerApp.DTOs
{
    public class StepDTO
    {
        [Key]
        public Guid Id { get; set; }

        public Guid RecipeId { get; set; }

        // Order of the step within the recipe
        public int Order { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(RecipeId))]
        public RecipeDTO Recipe { get; set; }
    }
}
