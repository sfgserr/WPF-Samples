using NavigationSample.ViewModels;
using System;

namespace NavigationSample.Navigators
{
    public enum ViewType
    {
        First,
        Second,
        Third,
        Fourth
    }

    interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }

        event Action ViewModelChanged;
    }
}
