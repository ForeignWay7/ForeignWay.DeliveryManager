using ForeignWay.DeliveryManager.App.Constants;
using ForeignWay.DeliveryManager.App.Helpers;
using ForeignWay.DeliveryManager.BusinessLogic.Contracts.Users;
using ForeignWay.DeliveryManager.StringResources;
using ForeignWay.DeliveryManager.Types.Users;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ForeignWay.DeliveryManager.App.Views.Settings.UserSettings.AddUser
{
    public class AddUserControlViewModel : BindableBase, INavigationAware
    {
        private readonly IPasswordBoxHelper _passwordBoxHelper;
        private readonly IUsersService _usersService;

        private Action<bool> _callback;
        private bool _isDialogOpen;
        private string _userName;
        private UserType _selectedUserType;
        private bool _errorOccurred;
        private string _errorText;


        public bool IsDialogOpen
        {
            get => _isDialogOpen;
            set => SetProperty(ref _isDialogOpen, value);
        }

        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        public UserType SelectedUserType
        {
            get => _selectedUserType;
            set => SetProperty(ref _selectedUserType, value);
        }

        public ObservableCollection<UserType> UserTypes => new()
        {
            UserType.Admin,
            UserType.Employee
        };


        public bool ErrorOccurred
        {
            get => _errorOccurred;
            set => SetProperty(ref _errorOccurred, value);
        }

        public string ErrorText
        {
            get => _errorText;
            set => SetProperty(ref _errorText, value);
        }


        public DelegateCommand<object> AddUserCommand { get; set; }

        public DelegateCommand CancelCommand { get; set; }



        public AddUserControlViewModel(IPasswordBoxHelper passwordBoxHelper, IUsersService usersService)
        {
            _passwordBoxHelper = passwordBoxHelper;
            _usersService = usersService;
            AddUserCommand = new DelegateCommand<object>(async passwordBox => await ExecuteAddUser(passwordBox, UserName, SelectedUserType));
            CancelCommand = new DelegateCommand(ExecuteCancel);
        }


        private async Task ExecuteAddUser(object passwordBox, string userName, UserType userType)
        {
            var password = _passwordBoxHelper.GetPasswordFrom(passwordBox);

            var user = new User(Guid.NewGuid(), userName, password, userType);
            var errorType = await _usersService.AddAsync(user);
            var isUserAdded = errorType == IUsersService.ErrorType.None;

            if (isUserAdded == false)
            {
                ErrorOccurred = true;

                ErrorText = errorType switch
                {
                    IUsersService.ErrorType.UserExists => UIResources.AddUserControl_AddError_UserExists,
                    IUsersService.ErrorType.Unknown => UIResources.AddUserControl_AddError_UnknownError,
                    _ => ErrorText
                };

                return;
            }

            _callback(isUserAdded);
            IsDialogOpen = false;
        }

        private void ExecuteCancel()
        {
            _callback(false);
            IsDialogOpen = false;
        }


        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            IsDialogOpen = true;

            var parameters = navigationContext.Parameters;

            if (parameters.ContainsKey(NavigationParameterNames.AddUserCallback))
            {
                parameters.TryGetValue(NavigationParameterNames.AddUserCallback, out _callback);
            }

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