using CommunityToolkit.Mvvm.ComponentModel;
using MealPlannerApp.Models;
using System.Collections.ObjectModel;

namespace MealPlannerApp.ViewModels
{
    
    public partial class MainWindowViewModel : ObservableObject
    {

        private readonly ObservableCollection<IngredientViewModel> _ingredients;
        public IEnumerable<IngredientViewModel> Ingredients => _ingredients;


        public ObservableCollection<Recipe> _recipes;
        public IEnumerable<Recipe> Recipes => _recipes;

        /// Constructor
        public MainWindowViewModel() 
        {
            _ingredients = new ObservableCollection<IngredientViewModel>();
            _recipes = new ObservableCollection<Recipe>();
        }


        

        [ObservableProperty]
        private int selectedItem;

       
        

        

        

    }      

     
    
}
