using ForeignWay.DeliveryManager.App.Constants;
using ForeignWay.DeliveryManager.App.ViewModels;
using ForeignWay.DeliveryManager.StringResources;
using ForeignWay.DeliveryManager.Types.Users;
using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;

namespace ForeignWay.DeliveryManager.App.Services
{
    public class MenuItemProviderService : IMenuItemsProviderService
    {
        public ObservableCollection<MenuItemViewModel> GetMenuItemsFor(UserType userType)
        {
            return new ObservableCollection<MenuItemViewModel>
            {
                new (PackIconKind.BorderColor, UIResources.NewOrderView_Title, ViewNames.NewOrderView),
                new (PackIconKind.BorderColor, UIResources.OrdersView_Title, ViewNames.OrdersView),
            };
        }
    }
}