using WPFAuthenticationSample.Services.AccountService;
using WPFAuthenticationSample.Services.Authenticators;
using WPFAuthenticationSample.Services.Navigators;

namespace WPFAuthenticationSample.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;

        public MainViewModel(INavigator navigator, CreateViewModel<LoginViewModel> createLoginViewModel)
        {
            _createLoginViewModel = createLoginViewModel;
            _navigator = navigator;
            _navigator.ViewModelChanged += OnViewModelChanged;

            _navigator.CurrentViewModel = _createLoginViewModel();
        }

        public ViewModelBase CurrentView => _navigator.CurrentViewModel;

        private void OnViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentView));
        }
    }
}
