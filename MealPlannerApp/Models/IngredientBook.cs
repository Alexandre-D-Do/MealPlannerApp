using MealPlannerApp.Exceptions;
using MealPlannerApp.Services.IngredientCreators;
using MealPlannerApp.Services.IngredientDeleters;
using MealPlannerApp.Services.IngredientExistsValidators;
using MealPlannerApp.Services.IngredientProviders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlannerApp.Models
{
    public class IngredientBook
    {
        private readonly IIngredientCreator _ingredientCreator;
        private readonly IIngredientRemover _ingredientRemover;
        private readonly IIngredientProvider _ingredientProvider;
        private readonly IIngredientExistsValidator _ingredientExistsValidator;

        public IngredientBook(IIngredientCreator ingredientCreator, IIngredientRemover ingredientRemover, IIngredientProvider ingredientProvider, IIngredientExistsValidator ingredientExistsValidator)
        {
            _ingredientCreator = ingredientCreator;
            _ingredientRemover = ingredientRemover;
            _ingredientProvider = ingredientProvider;
            _ingredientExistsValidator = ingredientExistsValidator;
        }

        public async Task<IEnumerable<Ingredient>> GetAllIngredients()
        {
            return await _ingredientProvider.GetAllIngredients();
        }

        public async Task AddIngredient(Ingredient ingredient)
        {
            Ingredient conflictingIngredient = await _ingredientExistsValidator.GetConflictingIngredient(ingredient);

            if (conflictingIngredient != null)
            {
                throw new IngredientExistsException(conflictingIngredient, ingredient);
            }

            await _ingredientCreator.CreateIngredient(ingredient);
        }

        public async Task RemoveIngredient(Ingredient ingredient)
        {
            await _ingredientRemover.RemoveIngredient(ingredient);
        }
    }
}
