using ForeignWay.DeliveryManager.Types.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForeignWay.DeliveryManager.BusinessLogic.Contracts.Users
{
    public interface IUsersService
    {
        Task<ErrorType> AddAsync(User user);

        Task<IEnumerable<User>> GetAllAsync();

        Task<User> GetByIdAsync(Guid id);

        Task<IEnumerable<User>> GetByUserNameAsync(string name);

        Task<ErrorType> RemoveByIdAsync(Guid id);


        public enum ErrorType { None, UserExists, CurrentUser, Unknown }
    }
}