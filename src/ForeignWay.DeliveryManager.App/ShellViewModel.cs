using ForeignWay.DeliveryManager.App.Constants;
using ForeignWay.DeliveryManager.App.Services;
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


        private bool _canGoBack;

        public bool CanGoBack
        {
            get => _canGoBack;
            set => SetProperty(ref _canGoBack, value);
        }

        public DelegateCommand BackCommand { get; init; }


        public ShellViewModel(INavigationService navigationService, IRegionManager regionManager)
        {
            _navigationService = navigationService;
            _regionManager = regionManager;

            BackCommand = new DelegateCommand(ExecuteBackCommand, CanExecuteNavigateBack);


            NavigateToSignInView();
        }

        private void NavigationService_Navigated(object sender, RegionNavigationEventArgs e)
        {
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
