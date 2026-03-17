using MealPlannerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlannerApp.Services.Dialogs
{
    public interface IDialogService
    {
        public void ShowDialog<TViewModel>(TViewModel viewModel) where TViewModel : IDialogViewModel;
    }
}
