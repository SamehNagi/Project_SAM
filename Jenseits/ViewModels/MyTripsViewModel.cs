using System;
using Jenseits.Models;
using Xamarin.Forms.Extended;
using Jenseits.ViewModels.Base;
using System.Threading.Tasks;
using Xamarin.Forms;
using Jenseits.Helpers;
using Jenseits.Views;

namespace Jenseits.ViewModels
{
    public class MyTripsViewModel : BaseViewModel
    {
        #region Properties & Commands

        public Command ItemSelectedCommand { get; set; }

        bool _isInTransition;
        public bool IsInTransition
        {
            get
            {
                return _isInTransition;
            }
            set
            {
                _isInTransition = value;
                OnPropertyChanged(nameof(IsInTransition));
                Device.BeginInvokeOnMainThread(ItemSelectedCommand.ChangeCanExecute);
            }
        }

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

        InfiniteScrollCollection<Trip> _tripsList;
        public InfiniteScrollCollection<Trip> TripsList
        {
            get
            {
                return _tripsList;
            }
            set
            {
                _tripsList = value;
                OnPropertyChanged(nameof(TripsList));
            }
        }

        bool _isLoadingMore;
        public bool IsLoadingMore
        {
            get
            {
                return _isLoadingMore;
            }
            set
            {
                SetValue(ref _isLoadingMore, value);
            }
        }

        #endregion

        public MyTripsViewModel()
        {
            ItemSelectedCommand = new Command(async (lv) => await ExecuteItemSelectedCommand(lv), (lv) => !IsInTransition);
            TripsList = new InfiniteScrollCollection<Trip>
            {
                OnLoadMore = async () =>
                {
                    IsLoadingMore = true;

                    var items = GetItems(false);
                    await Task.Delay(1200);

                    IsLoadingMore = false;
                    return items;
                }
            };
            TripsList.LoadMoreAsync();
        }

        #region Methods

        InfiniteScrollCollection<Trip> GetItems(bool clearList)
        {
            InfiniteScrollCollection<Trip> items;
            if (clearList || TripsList == null)
            {
                items = new InfiniteScrollCollection<Trip>();
            }
            else
            {
                items = new InfiniteScrollCollection<Trip>(TripsList);
            }

            for (int i = 0; i < 20; i++)
            {
                items.Add(new Trip
                {
                    FromAirport = "Cairo",
                    ToAirport = "Istanbul",
                    PackageSize = PackageSize.Small,
                    ItemWeigth = "2 kg.",
                    PickUpMethod = "Myself",
                    Status = "Matching a traveller...",
                    Verified = false
                });
            }

            return items;
        }

        async Task ExecuteItemSelectedCommand(object obj)
        {
            try
            {
                var listView = (ListView)obj;
                if(listView == null)
                {
                    return;
                }

                if(IsInTransition)
                {
                    return;
                }

                IsInTransition = true;

                var tripSelected = listView.SelectedItem;
                listView.SelectedItem = null;

                await Application.Current.MainPage.Navigation.PushAsync(new ShipmentDetailPage());
            }
            catch (Exception ex)
            {
                ExceptionHelper.LogException(this, nameof(ExecuteItemSelectedCommand), ex);
            }
            finally
            {
                IsInTransition = false;
            }
        }

        #endregion
    }
}
