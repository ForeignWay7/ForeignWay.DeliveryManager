using ForeignWay.DeliveryManager.App.ViewModels;
using ForeignWay.DeliveryManager.Types.Users;
using System.Collections.ObjectModel;

namespace ForeignWay.DeliveryManager.App.Services
{
    public interface IMenuItemsProviderService
    {
        ObservableCollection<MenuItemViewModel> GetMenuItemsFor(UserType userType);
    }
}