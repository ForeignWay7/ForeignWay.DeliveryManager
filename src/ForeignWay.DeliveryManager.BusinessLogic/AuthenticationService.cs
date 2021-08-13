using ForeignWay.DeliveryManager.BusinessLogic.Contracts.Users;
using ForeignWay.DeliveryManager.DatabaseAccess.Contracts.Users;
using ForeignWay.DeliveryManager.Types.Users;
using System.Threading.Tasks;

namespace ForeignWay.DeliveryManager.BusinessLogic
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private User _currentUser = User.GetEmpty();

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserType> SignInForAsync(string userName, string password)
        {
            var user = await _userRepository.GetByNameAndPasswordAsync(userName, password);

            _currentUser = user;

            return user.UserType;
        }

        public User GetCurrentUser()
        {
            return _currentUser;
        }
    }
}