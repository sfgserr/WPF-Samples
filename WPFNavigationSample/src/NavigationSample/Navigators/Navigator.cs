using NavigationSample.ViewModels;
using System;


namespace NavigationSample.Navigators
{
    class Navigator : INavigator
    {
        public event Action ViewModelChanged;

		private ViewModelBase _currentViewModel;

		public ViewModelBase CurrentViewModel
		{
			get => _currentViewModel;
            set => Set(ref _currentViewModel, value);
		}

        private bool Set(ref ViewModelBase currentView, ViewModelBase nextView)
        {
            if (Equals(currentView, nextView)) return false;
            currentView = nextView;
            ViewModelChanged?.Invoke();
            return true;
        }

    }
}
