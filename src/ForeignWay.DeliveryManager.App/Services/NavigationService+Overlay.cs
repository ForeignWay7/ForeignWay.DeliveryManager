using ForeignWay.DeliveryManager.App.Constants;
using Prism.Regions;
using System;

namespace ForeignWay.DeliveryManager.App.Services
{
    internal partial class NavigationService : INavigationService
    {
        public void ShowAddUserOverlay(Action<bool> callback)
        {
            var parameters = new NavigationParameters
            {
                { NavigationParameterNames.AddUserCallback, callback }
            };

            _regionManager.RequestNavigate(RegionNames.PopupRegion, ViewNames.AddUserControl, parameters);
        }
    }
}