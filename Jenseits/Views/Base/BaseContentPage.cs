using System;

using Xamarin.Forms;

namespace Jenseits.Views.Base
{
    public class BaseContentPage : ContentPage
    {
        public BaseContentPage()
        {
            NavigationPage.SetBackButtonTitle(this, string.Empty);
        }
    }
}

