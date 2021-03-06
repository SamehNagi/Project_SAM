﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Jenseits.ViewModels;

namespace Jenseits.Views
{
    public partial class LoginPage : ContentPage
    {
        readonly LoginPageViewModel _vm;

        public LoginPage()
        {
            InitializeComponent();
            _vm = new LoginPageViewModel(Navigation, this);
            BindingContext = _vm;
        }
    }
}
