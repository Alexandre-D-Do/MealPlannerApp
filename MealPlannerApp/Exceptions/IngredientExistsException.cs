using MealPlannerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlannerApp.Exceptions
{
    internal class IngredientExistsException : Exception
    {
        public Ingredient ExistingIngredient { get; }

        public Ingredient IncomingIngredient { get; }

        public IngredientExistsException(Ingredient existingIngredient, Ingredient incomingIngredient)
        {
            ExistingIngredient = existingIngredient;
            IncomingIngredient = incomingIngredient;
        }

        public IngredientExistsException(string? message, Ingredient existingIngredient, Ingredient incomingIngredient) : base(message)
        {
            ExistingIngredient = existingIngredient;
            IncomingIngredient = incomingIngredient;
        }

        public IngredientExistsException(string? message, Exception? innerException, Ingredient existingIngredient, Ingredient incomingIngredient) : base(message, innerException)
        {
            ExistingIngredient = existingIngredient;
            IncomingIngredient = incomingIngredient;
        }
    }

}
