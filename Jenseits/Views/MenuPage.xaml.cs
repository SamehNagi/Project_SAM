using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Jenseits.ViewModels;
using Jenseits.Views.Base;

namespace Jenseits.Views
{
    public partial class MenuPage : BaseContentPage
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
