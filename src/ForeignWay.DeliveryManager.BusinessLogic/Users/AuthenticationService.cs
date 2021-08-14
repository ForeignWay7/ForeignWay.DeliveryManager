using ForeignWay.DeliveryManager.BusinessLogic.Contracts.Users;
using ForeignWay.DeliveryManager.DatabaseAccess.Contracts.Users;
using ForeignWay.DeliveryManager.Types.Users;
using System.Threading.Tasks;

namespace ForeignWay.DeliveryManager.BusinessLogic.Users
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private User _currentUser = User.GetEmpty();


        public AuthenticationService(IUserRepository userRepository, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
        }


        public async Task<UserType> SignInForAsync(string userName, string password)
        {
            var hashedPassword = await _passwordService.CreateHashAsync(password);
            var user = await _userRepository.GetByNameAndPasswordAsync(userName, hashedPassword);

            _currentUser = user;

            return user.UserType;
        }


        public User GetCurrentUser()
        {
            return _currentUser;
        }
    }
}