using ForeignWay.DeliveryManager.App.Constants;
using ForeignWay.DeliveryManager.App.Services;
using ForeignWay.DeliveryManager.App.ViewModels;
using ForeignWay.DeliveryManager.Types;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;

namespace ForeignWay.DeliveryManager.App.Views.Home
{
    public class HomeViewModel : BindableBase, INavigationAware
    {
        private readonly IMenuItemsProviderService _menuItemsProviderService;
        private readonly INavigationService _navigationService;

        private ObservableCollection<MenuItemViewModel> _menuItems;

        public ObservableCollection<MenuItemViewModel> MenuItems
        {
            get => _menuItems;
            set => SetProperty(ref _menuItems, value);
        }

        public DelegateCommand<string> NavigateCommand { get; init; }



        public HomeViewModel(IMenuItemsProviderService menuItemsProviderService, INavigationService navigationService)
        {
            _menuItemsProviderService = menuItemsProviderService;
            _navigationService = navigationService;

            NavigateCommand = new DelegateCommand<string>(ExecuteNavigateCommand);
        }



        private void ExecuteNavigateCommand(string viewName)
        {
            _navigationService.NavigateTo(viewName);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var parameters = navigationContext.Parameters;

            parameters.TryGetValue<UserType>(NavigationParameterNames.UserType, out var userType);

            MenuItems = _menuItemsProviderService.GetMenuItemsFor(userType);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}