using MealPlannerApp.Model;
using MealPlannerApp.MVVM;
using System.Collections.ObjectModel;

namespace MealPlannerApp.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase 
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
