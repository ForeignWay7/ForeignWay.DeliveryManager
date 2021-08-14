using ForeignWay.DeliveryManager.App.Constants;
using ForeignWay.DeliveryManager.Types.Users;
using Prism.Regions;
using System.Collections.Generic;
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

        public void NavigateBack()
        {
            _regionManager.Regions[RegionNames.MainRegion].NavigationService.Journal.GoBack();
        }

        public bool CanNavigateBack()
        {
            try
            {
                return _regionManager.Regions[RegionNames.MainRegion].NavigationService.Journal.CanGoBack;
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }

        public void NavigateHome(UserType userType)
        {
            ClearJournalForRegion(RegionNames.MainRegion);

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

        private void ClearJournalForRegion(string regionName)
        {
            _regionManager.Regions[regionName].NavigationService.Journal.Clear();
        }
    }
}