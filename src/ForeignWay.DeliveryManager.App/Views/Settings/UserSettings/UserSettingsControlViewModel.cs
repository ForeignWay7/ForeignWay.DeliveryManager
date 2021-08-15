using ForeignWay.DeliveryManager.App.Services;
using ForeignWay.DeliveryManager.BusinessLogic.Contracts.Users;
using ForeignWay.DeliveryManager.StringResources;
using ForeignWay.DeliveryManager.Types.Users;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ForeignWay.DeliveryManager.App.Views.Settings.UserSettings
{
    public class UserSettingsControlViewModel : BindableBase
    {
        private readonly IUsersService _usersService;
        private readonly INavigationService _navigationService;
        private readonly IConfirmationOverlay _confirmationOverlay;

        private string _searchTerm;
        private ObservableCollection<User> _users;
        private User _selectedUser;


        public string SearchTerm
        {
            get => _searchTerm;
            set => SetProperty(ref _searchTerm, value);
        }

        public ObservableCollection<User> Users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }

        public User SelectedUser
        {
            get => _selectedUser;
            set => SetProperty(ref _selectedUser, value);
        }

        public DelegateCommand AddUserCommand { get; init; }
        public DelegateCommand<User> RemoveUserCommand { get; init; }


        public UserSettingsControlViewModel(IUsersService usersService, INavigationService navigationService, IConfirmationOverlay confirmationOverlay)
        {
            _usersService = usersService;
            _navigationService = navigationService;
            _confirmationOverlay = confirmationOverlay;

            AddUserCommand = new DelegateCommand(ExecuteAddUser);
            RemoveUserCommand = new DelegateCommand<User>(async (user) => await ExecuteRemoveUser(user));

            LoadUsers();
        }

        private async Task ExecuteRemoveUser(User user)
        {
            var errorType = await _usersService.RemoveByIdAsync(user.Id);

            switch (errorType)
            {
                case IUsersService.ErrorType.CurrentUser:
                    await _confirmationOverlay.ShowConfirmation(UIResources.UserSettingsControl_RemoveCurrentUser_ErrorTitle,
                        UIResources.UserSettingsControl_RemoveCurrentUser_ErrorMessage);
                    break;

                default:
                    return;
            }
        }


        private async void LoadUsers()
        {
            var users = await _usersService.GetAllAsync();

            Users = new ObservableCollection<User>(users);
        }


        private void ExecuteAddUser()
        {
            _navigationService.ShowAddUserOverlay(AddUserFinished);
        }

        private void AddUserFinished(bool isUserAdded)
        {
            if (isUserAdded) LoadUsers();
        }
    }
}