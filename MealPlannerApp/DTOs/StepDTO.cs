using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlannerApp.DTOs
{
    public class StepDTO
    {
        [Key]
        public Guid StepId { get; set; }

        public Guid RecipeId { get; set; }

        public int Order { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(RecipeId))]
        public RecipeDTO Recipe { get; set; }
    }
}
