using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlannerApp.DTOs
{
    // Relational DTO for storing Recipe in SQLite.
    // Ingredients and Steps are modeled as separate tables (collections) instead of ObservableCollection.
    public class RecipeDTO
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Cuisine { get; set; }

        public int Servings { get; set; }

        // Navigation properties — use lists for persistence layers (EF Core / SQLite)
        // Use an explicit join entity so Ingredients can be shared across Recipes.
        public List<RecipeIngredientDTO> RecipeIngredients { get; set; } = new List<RecipeIngredientDTO>();

        public List<StepDTO> Steps { get; set; } = new List<StepDTO>();
    }
}
