using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Jenseits.Helpers;
using Xamarin.Forms;

namespace Jenseits.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Properties & Commands

        public INavigation Navigation { get; set; }
        public Page PageReference { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public BaseViewModel(){}

        public BaseViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

        public BaseViewModel(INavigation navigation, Page pageReference)
        {
            Navigation = navigation;
            PageReference = pageReference;
        }

        #region Methods

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            try
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            catch (Exception ex)
            {
                ExceptionHelper.LogException(this, nameof(OnPropertyChanged), ex);
            }
        }

        protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return;

            backingField = value;
            OnPropertyChanged(propertyName);
        }

        #endregion
    }
}
