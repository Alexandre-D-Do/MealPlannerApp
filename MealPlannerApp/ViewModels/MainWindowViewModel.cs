using MealPlannerApp.Models;
using System.Collections.ObjectModel;

namespace MealPlannerApp.ViewModels
{
    internal class MainWindowViewModel
    {
        public MainWindowViewModel() { }

        public ObservableCollection<Recipe> Recipes { get; set; }

        private int selectedItem;

        

        public int SelectedItem
        {
            get { return selectedItem; }
            set 
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }

        

        

    }      

     
    
}
