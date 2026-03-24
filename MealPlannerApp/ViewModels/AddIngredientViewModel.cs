using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MealPlannerApp.Models;
using System;

namespace MealPlannerApp.ViewModels
{
    public partial class AddIngredientViewModel : ObservableObject, IDialogViewModel
    {
        public string Title { get; set; } = "Add Ingredient";
        // This event will be raised when the dialog should be closed, either after confirming or cancelling. Its handler is set up in DialogService to close the dialog window.
        public event Action RequestClose;

        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private bool _isStocked;

        public Ingredient Result { get; set; }

        [RelayCommand]
        private void Confirm()
        {
            Result = new Ingredient(Name, IsStocked);
            RequestClose?.Invoke();
        }

        [RelayCommand]
        private void Cancel()
        {
            RequestClose?.Invoke();
        }
    }
}
