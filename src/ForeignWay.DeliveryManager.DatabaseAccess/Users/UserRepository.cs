using ForeignWay.DeliveryManager.BusinessLogic.Contracts.Users;
using ForeignWay.DeliveryManager.DatabaseAccess.Contracts.Users;
using ForeignWay.DeliveryManager.Types.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignWay.DeliveryManager.DatabaseAccess.Users
{
    public class UserRepository : IUserRepository
    {
        public async Task<IUsersService.ErrorType> AddAsync(User user)
        {
            await using var ctx = new DeliveryManagerDbContext();

            var userExists = await GetByUserNameAsync(user.UserName) != null;
            if (userExists)
                return IUsersService.ErrorType.UserExists;

            var entity = await ctx.Users.AddAsync(user);
            entity.State = EntityState.Added;

            var success = await ctx.SaveChangesAsync() == 1;
            return success ? IUsersService.ErrorType.None : IUsersService.ErrorType.Unknown;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            await using var ctx = new DeliveryManagerDbContext();

            var entities = await ctx.Users.ToListAsync();

            return entities;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            await using var ctx = new DeliveryManagerDbContext();

            var entity = await ctx.Users.FirstOrDefaultAsync(x => x.Id.Equals(id));

            return entity;
        }

        private async Task<User> GetByUserNameAsync(string name)
        {
            await using var ctx = new DeliveryManagerDbContext();

            var entity = await ctx.Users.FirstOrDefaultAsync(x => x.UserName.Contains(name));

            return entity;
        }

        public async Task<IEnumerable<User>> SearchByUserNameAsync(string name)
        {
            await using var ctx = new DeliveryManagerDbContext();

            var entities = await ctx.Users.Where(x => x.UserName.Contains(name)).ToListAsync();

            return entities;
        }

        public async Task<User> GetByNameAndPasswordAsync(string userName, string password)
        {
            await using var ctx = new DeliveryManagerDbContext();

            var entity = await ctx.Users.FirstOrDefaultAsync(x => x.UserName.Equals(userName) && x.Password.Equals(password));

            return entity ?? User.GetEmpty();
        }

        public async Task<IUsersService.ErrorType> RemoveByIdAsync(Guid id)
        {
            await using var ctx = new DeliveryManagerDbContext();

            var user = await GetByIdAsync(id);

            var entity = ctx.Users.Remove(user);
            entity.State = EntityState.Deleted;

            var success = await ctx.SaveChangesAsync() == 1;
            return success ? IUsersService.ErrorType.None : IUsersService.ErrorType.Unknown;
        }
    }
}