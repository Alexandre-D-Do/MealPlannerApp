using CommunityToolkit.Mvvm.Messaging.Messages;
using MealPlannerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlannerApp.Stores
{
    public class IngredientRemovedMessage : ValueChangedMessage<Ingredient>
    {
        public IngredientRemovedMessage(Ingredient value) : base(value) { }
    }
}
