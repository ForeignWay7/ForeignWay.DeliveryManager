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
            var menuItems = new ObservableCollection<MenuItemViewModel>
            {
                new (PackIconKind.BorderColor, UIResources.NewOrderView_Title, ViewNames.NewOrderView),
                new (PackIconKind.BorderColor, UIResources.OrdersView_Title, ViewNames.OrdersView),
            };

            if (userType == UserType.Admin)
            {
                menuItems.AddRange(new ObservableCollection<MenuItemViewModel>
                {
                    new(PackIconKind.Settings, UIResources.SettingsView_User_Header, ViewNames.SettingsView)
                });
            }

            return menuItems;
        }
    }
}