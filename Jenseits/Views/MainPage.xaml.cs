﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Jenseits.Views
{
    public partial class MainPage : MasterDetailPage
    {
        public static MainPage Instance { get; set; }

        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            Instance = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            IsBusy = false;
        }
    }
}
