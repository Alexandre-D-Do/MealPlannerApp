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
            Window dialogWindow = new Window
            {
                Content = viewModel,
                Title = viewModel.Title,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Style = (Style)Application.Current.Resources["ApplicationWindow"]
            };
            // Set the owner of the dialog to the main window to ensure it appears centered and modal
            dialogWindow.Owner = Application.Current.MainWindow;

            // Subscribe to the RequestClose event to close the dialog when requested by the ViewModel
            viewModel.RequestClose += dialogWindow.Close;
            dialogWindow.ShowDialog();
            // Unsubscribe from the event to prevent memory leaks
            viewModel.RequestClose -= dialogWindow.Close;
        }

    }
}
