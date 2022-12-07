using System;
using System.Windows.Input;
using WPFAuthenticationSample.Services.Navigators;


namespace WPFAuthenticationSample.Commands
{
    class NavigateCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly IRenavigator _renavigator;

        public NavigateCommand(IRenavigator renavigator)
        {
            _renavigator = renavigator;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _renavigator.Navigate();
        }
    }
}
