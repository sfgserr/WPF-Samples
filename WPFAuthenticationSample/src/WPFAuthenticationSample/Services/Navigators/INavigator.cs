using System;
using WPFAuthenticationSample.ViewModels;

namespace WPFAuthenticationSample.Services.Navigators
{
    interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }

        event Action ViewModelChanged;
    }
}
