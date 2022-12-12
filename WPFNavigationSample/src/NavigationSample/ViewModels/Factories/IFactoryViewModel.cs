using NavigationSample.Navigators;

namespace NavigationSample.ViewModels.Factories
{
    interface IFactoryViewModel
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
