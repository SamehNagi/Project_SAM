using System;
using Jenseits.ViewModels.Base;
using System.Collections.ObjectModel;
using Jenseits.Models;
using Xamarin.Forms;
using System.Threading.Tasks;
using Jenseits.Helpers;
using Jenseits.Views;

namespace Jenseits.ViewModels
{
    public class MenuPageViewModel : BaseViewModel
    {
        #region Properties & Commands

        public Command ItemSelectedCommand { get; set; }

        public ObservableCollection<MenuObject> MenuList { get; set; }

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
                Device.BeginInvokeOnMainThread(ItemSelectedCommand.ChangeCanExecute);
            }
        }

        #endregion

        public MenuPageViewModel()
        {
            ItemSelectedCommand = new Command(ExecuteItemSelectedCommand, (lv) => !IsBusy);
            Initialize();
        }

        #region Methods

        void Initialize()
        {
            MenuList = new ObservableCollection<MenuObject>
            {
                new MenuObject
                {
                    Title = AppResources.MyTrips
                },
                new MenuObject
                {
                    Title = AppResources.MyShipments
                },
                new MenuObject
                {
                    Title = AppResources.MyProfile
                },
                new MenuObject
                {
                    Title = AppResources.Settings
                },
                new MenuObject
                {
                    Title = AppResources.About
                }
            };
            OnPropertyChanged(nameof(MenuList));
        }

        void ExecuteItemSelectedCommand(object obj)
        {
            try
            {
                if(IsBusy)
                {
                    return;
                }

                IsBusy = true;

                var listView = (ListView)obj;

                if(listView == null)
                {
                    return;
                }

                var itemSelected = (MenuObject)listView.SelectedItem;
                listView.SelectedItem = null;

                if(itemSelected == null)
                {
                    return;
                }

                if(itemSelected.Title == AppResources.MyTrips)
                {
                    if(MainPage.Instance.Detail.GetType() == typeof(MyTripsPage))
                    {
                        return;
                    }
                    MainPage.Instance.Detail = new NavigationPage(new MyTripsPage());
                    return;
                }
                if(itemSelected.Title == AppResources.MyShipments)
                {
                    if (MainPage.Instance.Detail.GetType() == typeof(MyShipmentsPage))
                    {
                        return;
                    }
                    MainPage.Instance.Detail = new NavigationPage(new MyShipmentsPage());
                    return;
                }
                if (itemSelected.Title == AppResources.MyProfile)
                {
                    if (MainPage.Instance.Detail.GetType() == typeof(MyProfilePage))
                    {
                        return;
                    }
                    MainPage.Instance.Detail = new NavigationPage(new MyProfilePage());
                    return;
                }
                if (itemSelected.Title == AppResources.Settings)
                {
                    if (MainPage.Instance.Detail.GetType() == typeof(SettingsPage))
                    {
                        return;
                    }
                    MainPage.Instance.Detail = new NavigationPage(new SettingsPage());
                    return;
                }
                if (itemSelected.Title == AppResources.About)
                {
                    if (MainPage.Instance.Detail.GetType() == typeof(AboutPage))
                    {
                        return;
                    }
                    MainPage.Instance.Detail = new NavigationPage(new AboutPage());
                    return;
                }

            }
            catch (Exception ex)
            {
                ExceptionHelper.LogException(this, nameof(ExecuteItemSelectedCommand), ex);
            }
            finally
            {
                DismissMasterPage();
                IsBusy = false;
            }
        }

        void DismissMasterPage()
        {
            MainPage.Instance.IsPresented = false;
        }

        #endregion
    }
}
