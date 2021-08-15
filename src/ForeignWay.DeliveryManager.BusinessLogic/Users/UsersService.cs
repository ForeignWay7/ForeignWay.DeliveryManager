using ForeignWay.DeliveryManager.BusinessLogic.Contracts.Users;
using ForeignWay.DeliveryManager.DatabaseAccess.Contracts.Users;
using ForeignWay.DeliveryManager.Types.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForeignWay.DeliveryManager.BusinessLogic.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authenticationService;
        private readonly IPasswordService _passwordService;


        public UsersService(IUserRepository userRepository, IAuthenticationService authenticationService, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _authenticationService = authenticationService;
            _passwordService = passwordService;
        }


        public async Task<IUsersService.ErrorType> AddAsync(User user)
        {
            var hashedPassword = await _passwordService.CreateHashAsync(user.Password);

            var newUser = new User(user.Id, user.UserName, hashedPassword, user.UserType);

            return await _userRepository.AddAsync(newUser);
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            return _userRepository.GetAllAsync();
        }

        public Task<User> GetByIdAsync(Guid id)
        {
            return _userRepository.GetByIdAsync(id);
        }

        public Task<IEnumerable<User>> GetByUserNameAsync(string name)
        {
            return _userRepository.SearchByUserNameAsync(name);
        }

        public async Task<IUsersService.ErrorType> RemoveByIdAsync(Guid id)
        {
            var currentUser = _authenticationService.GetCurrentUser();

            if (id.Equals(currentUser.Id))
                return await Task.FromResult(IUsersService.ErrorType.CurrentUser);

            return await _userRepository.RemoveByIdAsync(id);
        }
    }
}