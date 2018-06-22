using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Jenseits.ViewModels;

namespace Jenseits.Views
{
    public partial class MenuPage : ContentPage
    {
        readonly MenuPageViewModel _vm;
        
        public MenuPage()
        {
            InitializeComponent();
            _vm = new MenuPageViewModel();
            BindingContext = _vm;
        }
    }
}
