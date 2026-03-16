using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MealPlannerApp.Models
{
    public class Ingredient
    {
        public string Name { get; set; }
        public bool IsStocked { get; set; }
        public List<string> Recipes { get; set; } = new List<string>();
        public Ingredient(string name, bool isStocked)
        {
            Name = name;
            IsStocked = isStocked;
        } 
    }
}
