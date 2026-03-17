using CommunityToolkit.Mvvm.Messaging;
using MealPlannerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlannerApp.Stores
{
    public class ApplicationDataStore
    {
        private readonly IngredientBook _ingredientBook;
        private readonly List<Ingredient> _ingredients;
        public IEnumerable<Ingredient> Ingredients => _ingredients;

        public ApplicationDataStore(IngredientBook ingredientBook)
        {
            _ingredientBook = ingredientBook;
            _ingredients = new List<Ingredient>();
        }

        public async Task Initialize()
        {
            IEnumerable<Ingredient> ingredients = await _ingredientBook.GetAllIngredients();
            _ingredients.Clear();
            _ingredients.AddRange(ingredients);
        }

        public async Task AddIngredient(Ingredient ingredient)
        {
            await _ingredientBook.AddIngredient(ingredient);
            _ingredients.Add(ingredient);
            OnIngredientAdded(ingredient);
        }

        public async Task RemoveIngredient(Ingredient ingredient)
        {
            await _ingredientBook.RemoveIngredient(ingredient);
            _ingredients.Remove(ingredient);
            OnIngredientRemoved(ingredient);
        }   

        public void OnIngredientAdded(Ingredient ingredient)
        {
            StrongReferenceMessenger.Default.Send(new IngredientAddedMessage(ingredient));
        }

        public void OnIngredientRemoved(Ingredient ingredient)
        {
            StrongReferenceMessenger.Default.Send(new IngredientRemovedMessage(ingredient));
        }
    }
}
