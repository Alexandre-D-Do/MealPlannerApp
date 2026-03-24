using System;

namespace MealPlannerApp.ViewModels
{
    public interface IDialogViewModel
    {
        string Title { get; set; }
        event Action RequestClose;
    }
}
