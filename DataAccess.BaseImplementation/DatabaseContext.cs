namespace DataAccess.BaseImplementation
{
    using Entities;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public abstract class DatabaseContext : IdentityDbContext<User>
    {
        protected DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CarWash> CarWashes { set; get; }

        public DbSet<WashService> WashServices { set; get; }
    }
}
