using System;
using Xamarin.Forms;
using Jenseits.Helpers;
namespace Jenseits.Views.Base
{
    public class BaseNavigationPage : NavigationPage
    {
        public BaseNavigationPage(Page root) : base(root)
        {
            BarTextColor = Color.White;
            BarBackgroundColor = Colors.LightBlueColor;
        }
    }
}
