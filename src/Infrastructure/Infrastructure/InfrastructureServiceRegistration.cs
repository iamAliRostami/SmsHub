using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace SmsHub.Infrastructure.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this
            IServiceCollection services, IConfiguration configuration)
        {
            /*services.Configure<IConfiguration>(configuration);*/
            return services;
        }
    }
}
