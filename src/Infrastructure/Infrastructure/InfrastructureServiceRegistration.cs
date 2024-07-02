using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SmsHub.Core.Application.Contracts.Infrastructure;
using SmsHub.Infrastructure.Infrastructure.FileExport;

namespace SmsHub.Infrastructure.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this
            IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICsvExporter, CsvExporter>();
            return services;
        }
    }
}
