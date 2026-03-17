using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MealPlannerApp.Models;
using MealPlannerApp.Services.Dialogs;
using MealPlannerApp.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Navigation;

namespace MealPlannerApp.ViewModels
{
    // Add IRecipient
    public partial class HomePageViewModel : ObservableRecipient, IRecipient<IngredientAddedMessage>, IRecipient<IngredientRemovedMessage>, IPageViewModel
    {
        
        private readonly IDialogService _dialogService;
        private readonly ObservableCollection<IngredientViewModel> _ingredients;
        public IEnumerable<IngredientViewModel> Ingredients => _ingredients;

        public ObservableCollection<Recipe> _recipes;
        public IEnumerable<Recipe> Recipes => _recipes;

        [ObservableProperty]
        private IngredientViewModel selectedItem;

        /// Constructor
        public HomePageViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            _ingredients = new ObservableCollection<IngredientViewModel>();
            _recipes = new ObservableCollection<Recipe>();
        }

        protected override void OnActivated()
        {
            StrongReferenceMessenger.Default.RegisterAll(this);
            base.OnActivated();
        }

        protected override void OnDeactivated()
        {
            StrongReferenceMessenger.Default.UnregisterAll(this);
            base.OnDeactivated();
        }

        public void Receive(IngredientAddedMessage message)
        {
            IngredientViewModel ingredientViewModel = new IngredientViewModel(message.Value);
            _ingredients.Add(ingredientViewModel);
        }

        public void Receive(IngredientRemovedMessage message)
        {
            _ingredients.Remove(SelectedItem);
        }

        public static HomePageViewModel LoadViewModel(ApplicationDataStore applicationDataStore, NavigationService<AddIngredientViewModel>)
    }
}
