using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Jenseits.ViewModels;

namespace Jenseits.Views
{
    public partial class MyTripsPage : ContentPage
    {
        MyTripsViewModel _vm;
        public MyTripsPage()
        {
            InitializeComponent();

            _vm = new MyTripsViewModel();
            BindingContext = _vm;
        }
    }
}
