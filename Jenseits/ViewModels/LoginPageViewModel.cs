using System;
using Jenseits.ViewModels.Base;
using Xamarin.Forms;
using System.Threading.Tasks;
using Jenseits.Helpers;
using Jenseits.Views;

namespace Jenseits.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        #region Properties & Commands

        public Command LoginUserCommand { get; set; }

        bool _isBusy;
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                SetValue(ref _isBusy, value);
                Device.BeginInvokeOnMainThread(LoginUserCommand.ChangeCanExecute);
            }
        }

        #endregion

        public LoginPageViewModel(INavigation navigation, Page pageReference) : base(navigation, pageReference)
        {
            LoginUserCommand = new Command(async () => await ExecuteLoginUserCommand(), () => !IsBusy);
        }

        #region Methods

        async Task ExecuteLoginUserCommand()
        {
            try
            {
                if(IsBusy)
                {
                    return;
                }

                IsBusy = true;

                //Mock
                await Task.Delay(2000);

                Application.Current.MainPage = new MainPage();
            }
            catch (Exception ex)
            {
                ExceptionHelper.LogException(this, nameof(ExecuteLoginUserCommand), ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion
    }
}
