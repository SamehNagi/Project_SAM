using System;
using System.Collections.Generic;
using Jenseits.ViewModels;
using Xamarin.Forms;

namespace Jenseits.Views
{
    public partial class MyShipmentsPage : ContentPage
    {
        MyShipmentsPageViewModel _vm;
        
        public MyShipmentsPage()
        {
            InitializeComponent();

            _vm = new MyShipmentsPageViewModel();
            BindingContext = _vm;
        }
    }
}
