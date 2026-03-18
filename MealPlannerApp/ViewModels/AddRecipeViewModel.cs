using CommunityToolkit.Mvvm.ComponentModel;
using MealPlannerApp.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlannerApp.ViewModels
{

    // The IsActive member of IPageViewModel is used to determine whether the view model is currently active and should receive messages.
    // This member comes from the ObservableRecipient base class, which implements the IRecipient interface and provides the IsActive property.
    [ObservableRecipient]
    public partial class AddRecipeViewModel : ObservableValidator, IPageViewModel
    {
        ApplicationDataStore _applicationDataStore;

    }
}
