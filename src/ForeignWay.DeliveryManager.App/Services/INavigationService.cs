using ForeignWay.DeliveryManager.Types;

namespace ForeignWay.DeliveryManager.App.Services
{
    public interface INavigationService
    {
        void NavigateHome(UserType userType);

        void NavigateToSignInView();

        void NavigateTo(string viewName);
    }
}