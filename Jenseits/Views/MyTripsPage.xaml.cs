using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Jenseits.ViewModels;
using Jenseits.Views.Base;

namespace Jenseits.Views
{
    public partial class MyTripsPage : BaseContentPage
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
