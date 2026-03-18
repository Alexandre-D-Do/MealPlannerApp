using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MealPlannerApp.Models;
using MealPlannerApp.Services;
using MealPlannerApp.Services.Dialogs;
using MealPlannerApp.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Navigation;

namespace MealPlannerApp.ViewModels
{
    public partial class HomePageViewModel : ObservableRecipient, IRecipient<IngredientAddedMessage>, IRecipient<IngredientRemovedMessage>, IPageViewModel
    {

        private readonly ApplicationDataStore _applicationDataStore;
        private readonly DialogService _dialogService;
        private readonly NavigationService<AddRecipeViewModel> _addRecipeNavigationService;
       
        private readonly ObservableCollection<IngredientViewModel> _ingredients;
        public IEnumerable<IngredientViewModel> Ingredients => _ingredients;

        public ObservableCollection<Recipe> _recipes;
        public IEnumerable<Recipe> Recipes => _recipes;

        [ObservableProperty]
        private IngredientViewModel selectedItem;

        /// Constructor
        public HomePageViewModel(ApplicationDataStore applicationDataStore, DialogService dialogService, NavigationService<AddRecipeViewModel> addRecipeNavigationService)
        {
            _applicationDataStore = applicationDataStore;
            _dialogService = dialogService;
            _addRecipeNavigationService = addRecipeNavigationService;
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

        [ObservableProperty]
        private bool _isLoading;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasErrorMessage))]
        private string _errorMessage;
        
        
        // Update this method and create new UpdateRecipes method when implementing recipes
        [RelayCommand]
        private async Task LoadData()
        {
            ErrorMessage = string.Empty;
            IsLoading = true;
            try
            {
                await _applicationDataStore.Initialize();
                UpdateIngredients(_applicationDataStore.Ingredients);
            }
            catch (Exception)
            {
                ErrorMessage = "An error occurred while loading data.";

            }
            IsLoading = false;
        }

        public void UpdateIngredients(IEnumerable<Ingredient> ingredients)
        {
            _ingredients.Clear();
            foreach (Ingredient ingredient in ingredients)
            {
                IngredientViewModel ingredientViewModel = new IngredientViewModel(ingredient);
                _ingredients.Add(ingredientViewModel);
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

        public static HomePageViewModel LoadViewModel(ApplicationDataStore applicationDataStore, DialogService dialogService, NavigationService<AddRecipeViewModel> addRecipeNavigationService)
        {
            HomePageViewModel viewModel = new HomePageViewModel(applicationDataStore, dialogService, addRecipeNavigationService);
            viewModel.LoadDataCommand.Execute(null);
            return viewModel;
        }
    }
}
