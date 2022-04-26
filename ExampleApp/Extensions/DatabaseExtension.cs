namespace BackendWashMe.Extensions
{
    using DataAccess.Interfaces;
    using DataAccess.BaseImplementation;
    using DataAccess.BaseImplementation.Repositories;
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using DataAccess.SqlLite;
    using DataAccess.MySql;

    public static class DatabaseExtension
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            string mysqlConnection = configuration.GetConnectionString("MySqlConnection");

            if (!bool.TryParse (configuration.GetSection("IsDevelopment").Value, out bool isDevelopment))
                isDevelopment = true;

            if (isDevelopment)
                services.AddDbContext<DatabaseContext, SqlLiteDbContext>(opt => opt.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
            else
                services.AddDbContext<DatabaseContext, MySqlDbContext>(opt => opt.UseMySql(mysqlConnection, ServerVersion.AutoDetect(mysqlConnection)));

            services.AddScoped<IRepository<CarWash>, CarWashesRepository>();
            services.AddScoped<IRepository<WashService>, WashServicesRepository>();
        }
    }
}
