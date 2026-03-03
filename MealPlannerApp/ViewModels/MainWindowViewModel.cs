using CommunityToolkit.Mvvm.ComponentModel;
using MealPlannerApp.Models;
using System.Collections.ObjectModel;

namespace MealPlannerApp.ViewModels
{
    
    public partial class MainWindowViewModel : ObservableObject
    {
        public MainWindowViewModel() { }

        public ObservableCollection<Recipe> Recipes { get; set; }

        [ObservableProperty]
        private int selectedItem;

        

        

    }      

     
    
}
