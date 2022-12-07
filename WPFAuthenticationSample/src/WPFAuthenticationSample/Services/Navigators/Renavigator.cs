using WPFAuthenticationSample.ViewModels;

namespace WPFAuthenticationSample.Services.Navigators
{
    class Renavigator<TViewModel> : IRenavigator where TViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly CreateViewModel<TViewModel> _createViewModel;

        public Renavigator(INavigator navigator, CreateViewModel<TViewModel> createViewModel)
        {
            _createViewModel = createViewModel;
            _navigator = navigator;
        }

        public void Navigate()
        {
            _navigator.CurrentViewModel = _createViewModel();
        }
    }
}
