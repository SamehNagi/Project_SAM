using Xamarin.Forms;
using Jenseits.ViewModels;
using Jenseits.Views.Base;

namespace Jenseits.Views
{
    public partial class LoginPage : BaseContentPage
    {
        readonly LoginPageViewModel _vm;

        public LoginPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();
            _vm = new LoginPageViewModel(Navigation, this);
            BindingContext = _vm;
        }
    }
}
