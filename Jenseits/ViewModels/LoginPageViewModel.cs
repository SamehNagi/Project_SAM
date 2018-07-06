using System;
using Jenseits.ViewModels.Base;
using Xamarin.Forms;
using System.Threading.Tasks;
using Jenseits.Helpers;
using Jenseits.Views;
using Jenseits.Views.Base;

namespace Jenseits.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        #region Properties & Commands

        public Command LoginUserCommand { get; set; }

        public Command ForgotPasswordCommand { get; set; }

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
            }
        }

        bool _isLoggingIn;
        public bool IsLoggingIn
        {
            get
            {
                return _isLoggingIn;
            }
            set
            {
                SetValue(ref _isLoggingIn, value);
                Device.BeginInvokeOnMainThread(LoginUserCommand.ChangeCanExecute);
            }
        }

        #endregion

        public LoginPageViewModel(INavigation navigation, Page pageReference) : base(navigation, pageReference)
        {
            LoginUserCommand = new Command(async () => await ExecuteLoginUserCommand(), () => !IsLoggingIn);
            ForgotPasswordCommand = new Command(async () => await ExecuteForgotPasswordCommand(), () => !IsBusy);
        }

        #region Methods

        async Task ExecuteLoginUserCommand()
        {
            try
            {
                if(IsLoggingIn)
                {
                    return;
                }

                IsLoggingIn = true;

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
                IsLoggingIn = false;
            }
        }

        async Task ExecuteForgotPasswordCommand()
        {
            try
            {
                if (IsBusy)
                {
                    return;
                }

                IsBusy = true;
                await Application.Current.MainPage.Navigation.PushAsync(new ForgotPasswordPage());
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
