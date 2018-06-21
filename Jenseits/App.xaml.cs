using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Jenseits.Views;
using Plugin.Multilingual;
using System.Globalization;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Jenseits
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            CrossMultilingual.Current.CurrentCultureInfo = new CultureInfo("en");
            AppResources.Culture = CrossMultilingual.Current.DeviceCultureInfo;

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
