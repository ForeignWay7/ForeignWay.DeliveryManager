using ForeignWay.DeliveryManager.App.Services;
using Prism.Mvvm;
using System.Windows;

namespace ForeignWay.DeliveryManager.App
{
    public class ShellViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;


        public ShellViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigateToSignInView();
        }

        private async void NavigateToSignInView()
        {
            await Application.Current.Dispatcher.InvokeAsync(() => _navigationService.NavigateToSignInView());
        }
    }
}
