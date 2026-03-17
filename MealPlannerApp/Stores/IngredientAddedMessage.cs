using CommunityToolkit.Mvvm.Messaging.Messages;
using MealPlannerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlannerApp.Stores
{
    public class IngredientAddedMessage : ValueChangedMessage<Ingredient>
    {
        public IngredientAddedMessage(Ingredient value) : base(value) { }
    }
}
