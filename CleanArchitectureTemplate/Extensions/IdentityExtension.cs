using BackendWashMe.IdentityTokenProviders;

namespace BackendWashMe.Extensions
{
    using DataAccess.BaseImplementation;
    using Entities;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public static class IdentityExtension
    {
        public static void AddIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddSignInManager<SignInManager<User>>()
                .AddCrutchTokenProviders();

            //TODO When sms gateway will be ready change to default token providers
            //.AddDefaultTokenProviders();
        }
    }
}
