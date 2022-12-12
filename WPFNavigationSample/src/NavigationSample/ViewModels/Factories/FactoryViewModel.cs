using NavigationSample.Navigators;
using System;

namespace NavigationSample.ViewModels.Factories
{
    class FactoryViewModel : IFactoryViewModel
    {
        private readonly CreateViewModel<FirstViewModel> _firstViewModel;
        private readonly CreateViewModel<SecondViewModel> _secondViewModel;
        private readonly CreateViewModel<ThirdViewModel> _thirdViewModel;
        private readonly CreateViewModel<FourthViewModel> _fourthViewModel;

        public FactoryViewModel(CreateViewModel<FirstViewModel> firstViewModel,
                                CreateViewModel<SecondViewModel> secondViewModel,
                                CreateViewModel<ThirdViewModel> thirdViewModel,
                                CreateViewModel<FourthViewModel> fourthViewModel)
        {
            _firstViewModel = firstViewModel;
            _secondViewModel = secondViewModel;
            _thirdViewModel = thirdViewModel;
            _fourthViewModel = fourthViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            return viewType switch
            {
                ViewType.First => _firstViewModel(),
                ViewType.Second => _secondViewModel(),
                ViewType.Third => _thirdViewModel(),
                ViewType.Fourth => _fourthViewModel(),
                _ => throw new Exception()
            };
        }
    }
}
