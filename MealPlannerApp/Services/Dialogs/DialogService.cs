using MealPlannerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;


namespace MealPlannerApp.Services.Dialogs
{
    public class DialogService : IDialogService
    {
        public void ShowDialog<TViewModel>(TViewModel viewModel) where TViewModel : IDialogViewModel
        {
            Window dialogWindow = new Window();
            dialogWindow.DataContext = viewModel;
            dialogWindow.Title = viewModel.Title;
            dialogWindow.ShowDialog();

        }
    }
}
