﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFAuthenticationSample.ViewModels
{
    delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : ViewModelBase;

    class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool Set<T>(ref T field, T value, [CallerMemberName]string propertyName = "")
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
