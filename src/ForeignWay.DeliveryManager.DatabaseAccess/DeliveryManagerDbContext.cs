using ForeignWay.DeliveryManager.DatabaseAccess.Users;
using ForeignWay.DeliveryManager.Types.Users;
using Microsoft.EntityFrameworkCore;

namespace ForeignWay.DeliveryManager.DatabaseAccess
{
    public class DeliveryManagerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }


        public DeliveryManagerDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=.\DeliveryManager; Initial Catalog=DeliveryManager; Integrated Security=true; MultipleActiveResultSets=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().Configure();
        }
    }
}