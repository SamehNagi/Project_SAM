using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Jenseits.Controls
{
    public partial class BaseListView : ListView
    {
        public static BindableProperty ItemSelectedCommandProperty = BindableProperty.Create(
            nameof(ItemSelectedCommand),
            typeof(Command),
            typeof(BaseListView),
            null, propertyChanged: (bindable, oldVal, newVal) =>
            {
                var view = (BaseListView)bindable;
                view.ItemSelected += (object sender, SelectedItemChangedEventArgs e) =>
                {
                    view.ItemSelectedCommand.Execute(view);
                };
            });

        public Command ItemSelectedCommand
        {
            get
            {
                return (Command)GetValue(ItemSelectedCommandProperty);
            }
            set
            {
                SetValue(ItemSelectedCommandProperty, value);
            }
        }

        public BaseListView(ListViewCachingStrategy cachingStrategy) : base(cachingStrategy)
        {
            
        }

        public BaseListView()
        {

        }
    }
}
