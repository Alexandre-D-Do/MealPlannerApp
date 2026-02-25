using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlannerApp.DTOs
{
    public class IngredientDTO
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsStocked { get; set; }

        // Back-reference to join table. An ingredient can belong to many recipes.
        public List<RecipeIngredientDTO> RecipeIngredients { get; set; } = new List<RecipeIngredientDTO>();
    }
}
