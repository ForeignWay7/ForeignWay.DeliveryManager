using ForeignWay.DeliveryManager.App.Constants;
using ForeignWay.DeliveryManager.Types;
using Prism.Regions;
using System.Windows;

namespace ForeignWay.DeliveryManager.App.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IRegionManager _regionManager;


        public NavigationService(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void NavigateHome(UserType userType)
        {
            var parameters = new NavigationParameters
            {
                { NavigationParameterNames.UserType, userType }
            };

            Application.Current.Dispatcher.Invoke(() => _regionManager.RequestNavigate(RegionNames.MainRegion, ViewNames.HomeView, parameters));
        }

        public void NavigateToSignInView()
        {
            Application.Current.Dispatcher.Invoke(() => _regionManager.RequestNavigate(RegionNames.MainRegion, ViewNames.SignInView));
        }

        public void NavigateTo(string viewName)
        {
            Application.Current.Dispatcher.Invoke(() => _regionManager.RequestNavigate(RegionNames.MainRegion, viewName));
        }
    }
}