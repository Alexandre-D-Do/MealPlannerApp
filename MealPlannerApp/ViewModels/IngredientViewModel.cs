using CommunityToolkit.Mvvm.ComponentModel;
using MealPlannerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlannerApp.ViewModels
{
    public class IngredientViewModel : ObservableObject
    {
        private readonly Ingredient _ingredient;
        public string Name => _ingredient.Name;
        public bool IsStocked => _ingredient.IsStocked;

        public IngredientViewModel(Ingredient ingredient)
        {
            _ingredient = ingredient;
        }
    }
}
