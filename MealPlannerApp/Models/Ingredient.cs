using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlannerApp.Models
{
    public class Ingredient
    {
        public string Name { get; set; }
        public bool IsStocked { get; set; }
        public Ingredient(string name, bool isStocked)
        {
            Name = name;
            IsStocked = isStocked;
        }
    }
}
