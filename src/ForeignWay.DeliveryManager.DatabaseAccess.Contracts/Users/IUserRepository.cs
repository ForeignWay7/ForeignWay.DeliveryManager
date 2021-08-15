using ForeignWay.DeliveryManager.BusinessLogic.Contracts.Users;
using ForeignWay.DeliveryManager.Types.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForeignWay.DeliveryManager.DatabaseAccess.Contracts.Users
{
    public interface IUserRepository
    {
        Task<IUsersService.ErrorType> AddAsync(User user);

        Task<IEnumerable<User>> GetAllAsync();

        Task<User> GetByIdAsync(Guid id);

        Task<IEnumerable<User>> SearchByUserNameAsync(string name);

        Task<User> GetByNameAndPasswordAsync(string userName, string password);

        Task<IUsersService.ErrorType> RemoveByIdAsync(Guid id);
    }
}