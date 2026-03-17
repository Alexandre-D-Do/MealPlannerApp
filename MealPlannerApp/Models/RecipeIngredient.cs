using System;

namespace MealPlannerApp.Models
{
    public class RecipeIngredient : Ingredient
    {
        public decimal? Quantity { get; set; }
        public string Unit { get; set; }

        public RecipeIngredient(string name, bool isStocked, decimal? quantity, string unit) : base(name, isStocked) 
        {
            Quantity = quantity;
            Unit = unit;
        }
    }
}
