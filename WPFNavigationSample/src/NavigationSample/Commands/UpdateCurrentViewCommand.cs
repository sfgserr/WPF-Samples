using NavigationSample.Navigators;
using NavigationSample.ViewModels.Factories;
using System;
using System.Windows.Input;

namespace NavigationSample.Commands
{
    class UpdateCurrentViewCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly INavigator _navigator;
        private readonly IFactoryViewModel _factoryViewModel;

        public UpdateCurrentViewCommand(INavigator navigator, IFactoryViewModel factoryViewModel)
        {
            _navigator = navigator;
            _factoryViewModel = factoryViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
           if(parameter is ViewType viewType)
              _navigator.CurrentViewModel = _factoryViewModel.CreateViewModel(viewType);
        }
    }
}
