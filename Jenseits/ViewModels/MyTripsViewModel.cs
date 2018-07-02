using System;
using Jenseits.Models;
using Xamarin.Forms.Extended;
using Jenseits.ViewModels.Base;
using System.Threading.Tasks;

namespace Jenseits.ViewModels
{
    public class MyTripsViewModel : BaseViewModel
    {
        #region Properties & Commands

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
                    Status = "Matching a traveller..."
                });
            }

            return items;
        }

        #endregion
    }
}
