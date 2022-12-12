using NavigationSample.Commands;
using NavigationSample.Navigators;
using NavigationSample.ViewModels.Factories;
using System.Windows.Input;

namespace NavigationSample.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;

        public MainViewModel(INavigator navigator, IFactoryViewModel factoryViewModel)
        {
            _navigator = navigator;
            _navigator.ViewModelChanged += OnViewModelChanged;

            UpdateCurrentViewCommand = new UpdateCurrentViewCommand(navigator, factoryViewModel);
        }

        public ICommand UpdateCurrentViewCommand { get; } 
        public ViewModelBase CurrentView => _navigator.CurrentViewModel;

        private void OnViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentView));
        }
    }
}
