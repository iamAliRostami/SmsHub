using SmsHub.Core.Application;
using SmsHub.Infrastructure.Persistence;
using SmsHub.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace SmsHub.Api
{
    public static class StartupExtentions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder) {
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddPersistenceServices(builder.Configuration);

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddControllers();

            builder.Services.AddCors(options => {
                options.AddPolicy("open", builder => builder.AllowAnyOrigin()
                .AllowAnyHeader().AllowAnyMethod());
            });
            return builder.Build();

        }
        public static WebApplication ConfigurePipeline(this WebApplication app) { 
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseCors("Open");

            app.MapControllers();

            return app;
        }

        public static async Task ResetDatabaseAsync(this WebApplication app) {
            using var scop = app.Services.CreateScope();
            try {
            var context = scop.ServiceProvider.GetService<SmsHubDbContext>();
                if (context != null) { 
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
            } catch (Exception ex) { 
            }
        }
    }
}
