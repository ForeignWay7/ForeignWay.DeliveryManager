using ForeignWay.DeliveryManager.Types.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForeignWay.DeliveryManager.DatabaseAccess.Users
{
    public static class UserDbConfigurationExtensions
    {
        public static void Configure(this EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.UserName);
            entity.Property(e => e.Password);
            entity.Property(e => e.UserType);

            entity.ToTable("Users");
        }
    }
}