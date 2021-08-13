using ForeignWay.DeliveryManager.Types.Users;
using System;
using System.Threading.Tasks;

namespace ForeignWay.DeliveryManager.DatabaseAccess.Contracts.Users
{
    public interface IUserRepository
    {
        Task<bool> AddAsync(User user);

        Task<User> GetByIdAsync(Guid id);

        Task<User> GetByNameAndPasswordAsync(string userName, string password);

        Task<bool> RemoveByIdAsync(Guid id);
    }
}