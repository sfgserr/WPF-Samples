using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NavigationSample.ViewModels
{
    delegate ViewModelBase CreateViewModel<T>() where T : ViewModelBase;

    class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private protected void OnPropertyChanged(string properyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(properyName));
        }

        protected bool Set<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            if(Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        } 
    }
}
