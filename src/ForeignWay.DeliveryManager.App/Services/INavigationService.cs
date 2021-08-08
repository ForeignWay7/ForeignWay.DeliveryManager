using ForeignWay.DeliveryManager.Types;

namespace ForeignWay.DeliveryManager.App.Services
{
    public interface INavigationService
    {
        void NavigateBack();

        bool CanNavigateBack();

        void NavigateHome(UserType userType);

        void NavigateToSignInView();

        void NavigateTo(string viewName);
    }
}