using ForeignWay.DeliveryManager.App.Helpers;
using ForeignWay.DeliveryManager.App.Services;
using ForeignWay.DeliveryManager.BusinessLogic.Contracts.Users;
using ForeignWay.DeliveryManager.Types.Users;
using Prism.Commands;
using Prism.Mvvm;
using System.Threading.Tasks;
using Prism.Regions;

namespace ForeignWay.DeliveryManager.App.Views.SignIn
{
    public class SignInViewModel : BindableBase, INavigationAware
    {
        private readonly IPasswordBoxHelper _passwordBoxHelper;
        private readonly INavigationService _navigationService;
        private readonly IAuthenticationService _authenticationService;

        private string _userName;
        private DelegateCommand<object> _signInCommand;


        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        private bool _isSignInFailed;

        public bool IsSignInFailed
        {
            get => _isSignInFailed;
            set => SetProperty(ref _isSignInFailed, value);
        }

        public DelegateCommand<object> SignInCommand
        {
            get => _signInCommand;
            set => SetProperty(ref _signInCommand, value);
        }


        public SignInViewModel(IPasswordBoxHelper passwordBoxHelper, INavigationService navigationService, IAuthenticationService authenticationService)
        {
            _passwordBoxHelper = passwordBoxHelper;
            _navigationService = navigationService;
            _authenticationService = authenticationService;

            SignInCommand = new DelegateCommand<object>(async (passwordBoxObject) => await ExecuteSignInAsync(UserName, passwordBoxObject));
        }


        private async Task ExecuteSignInAsync(string userName, object passwordBoxObject)
        {
            var password = _passwordBoxHelper.GetPasswordFrom(passwordBoxObject);

            var userType = await _authenticationService.SignInForAsync(userName, password);

            if (userType == UserType.None)
            {
                IsSignInFailed = true;
            }
            else
            {
                _navigationService.NavigateHome(userType);
            }

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            
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