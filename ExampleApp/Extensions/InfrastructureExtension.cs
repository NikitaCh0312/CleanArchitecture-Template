namespace BackendWashMe.Extensions
{
    using Infrastructure.Interfaces;
    using Infrastructure.SmsGateway;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class InfrastructureExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SmsGatewayConfiuration>(configuration.GetSection("SmsGateway"));
            services.AddScoped<ISmsGateway, SmsGateway>();
        }
    }
}
