using ForeignWay.DeliveryManager.App.Constants;
using ForeignWay.DeliveryManager.App.Services;
using ForeignWay.DeliveryManager.BusinessLogic.Contracts.Users;
using ForeignWay.DeliveryManager.Types.Users;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows;

namespace ForeignWay.DeliveryManager.App
{
    public class ShellViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        private readonly IRegionManager _regionManager;
        private readonly IAuthenticationService _authenticationService;


        private bool _canGoBack;

        public bool CanGoBack
        {
            get => _canGoBack;
            set => SetProperty(ref _canGoBack, value);
        }

        public DelegateCommand NavigateHomeCommand { get; init; }

        public DelegateCommand BackCommand { get; init; }


        public ShellViewModel(INavigationService navigationService, IRegionManager regionManager, IAuthenticationService authenticationService)
        {
            _navigationService = navigationService;
            _regionManager = regionManager;
            _authenticationService = authenticationService;

            NavigateHomeCommand = new DelegateCommand(ExecuteNavigateHomeCommand, CanNavigateHome);
            BackCommand = new DelegateCommand(ExecuteBackCommand, CanExecuteNavigateBack);
            
            NavigateToSignInView();
        }

        private bool CanNavigateHome()
        {
            var user = _authenticationService.GetCurrentUser();

            return user.Equals(User.GetEmpty()) == false;
        }


        private void ExecuteNavigateHomeCommand()
        {
            var currentUser = _authenticationService.GetCurrentUser();
            _navigationService.NavigateHome(currentUser.UserType);
        }

        private void NavigationService_Navigated(object sender, RegionNavigationEventArgs e)
        {
            NavigateHomeCommand.RaiseCanExecuteChanged();
            BackCommand.RaiseCanExecuteChanged();
        }

        private async void NavigateToSignInView()
        {
            await Application.Current.Dispatcher.InvokeAsync(() => _navigationService.NavigateToSignInView());
            _regionManager.Regions[RegionNames.MainRegion].NavigationService.Navigated += NavigationService_Navigated;
        }

        private void ExecuteBackCommand()
        {
            _navigationService.NavigateBack();
        }

        private bool CanExecuteNavigateBack()
        {
            var canGoBack = _navigationService.CanNavigateBack();
            CanGoBack = canGoBack;

            return canGoBack;
        }
    }
}
