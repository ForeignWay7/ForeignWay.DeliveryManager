using ForeignWay.DeliveryManager.DatabaseAccess.Contracts.Users;
using ForeignWay.DeliveryManager.Types.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ForeignWay.DeliveryManager.DatabaseAccess.Users
{
    public class UserRepository : IUserRepository
    {
        public async Task<bool> AddAsync(User user)
        {
            await using var ctx = new DeliveryManagerDbContext();
            var entity = await ctx.Users.AddAsync(user);
            entity.State = EntityState.Added;

            return await ctx.SaveChangesAsync() == 1;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            await using var ctx = new DeliveryManagerDbContext();

            var entity = await ctx.Users.FirstOrDefaultAsync(x => x.Id.Equals(id));

            return entity;
        }

        public async Task<User> GetByNameAndPasswordAsync(string userName, string password)
        {
            await using var ctx = new DeliveryManagerDbContext();

            var entity = await ctx.Users.FirstOrDefaultAsync(x => x.UserName.Equals(userName) && x.Password.Equals(password));

            return entity ?? User.GetEmpty();
        }

        public async Task<bool> RemoveByIdAsync(Guid id)
        {
            await using var ctx = new DeliveryManagerDbContext();
            var entity = await GetByIdAsync(id);
            ctx.Users.Remove(entity);

            return await ctx.SaveChangesAsync() == 1;
        }


    }
}