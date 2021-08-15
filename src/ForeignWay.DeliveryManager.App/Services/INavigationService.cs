using ForeignWay.DeliveryManager.Types.Users;
using System;

namespace ForeignWay.DeliveryManager.App.Services
{
    public interface INavigationService
    {
        void NavigateBack();

        bool CanNavigateBack();

        void NavigateHome(UserType userType);

        void NavigateToSignInView();

        void NavigateTo(string viewName);

        void ShowAddUserOverlay(Action<bool> callback);
    }
}