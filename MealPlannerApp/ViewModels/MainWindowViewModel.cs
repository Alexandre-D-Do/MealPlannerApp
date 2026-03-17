using CommunityToolkit.Mvvm.ComponentModel;
using MealPlannerApp.Models;
using MealPlannerApp.Stores;
using System.Collections.ObjectModel;

namespace MealPlannerApp.ViewModels
{
    
    public partial class MainWindowViewModel : ObservableObject
    {

        private readonly NavigationStore _navigationStore;
        public IPageViewModel CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainWindowViewModel()
        {
            _navigationStore = new NavigationStore();
            _navigationStore.CurrentViewModelChanged += CurrentViewModelChangedHandler;
        }

        private void CurrentViewModelChangedHandler()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }









    }      

     
    
}
