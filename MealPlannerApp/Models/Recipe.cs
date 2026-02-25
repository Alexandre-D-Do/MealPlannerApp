using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlannerApp.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public string Cuisine { get; set; }
        public ObservableCollection<Ingredient> Ingredients { get; set; }
        public ObservableCollection<string> Steps { get; set; }
        public int Servings { get; set; }
    }
}
