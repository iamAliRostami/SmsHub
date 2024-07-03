using SmsHub.Core.Application;
using SmsHub.Infrastructure.Persistence;
using SmsHub.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SmsHub.Core.Application.Contracts.Infrastructure;
using SmsHub.Infrastructure.Infrastructure.FileExport;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.OpenApi.Models;
using SmsHub.Api.Utility;

namespace SmsHub.Api
{
    public static class StartupExtentions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder) {
            AddSwagger(builder.Services);

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
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c=>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json","Sms Hub");
                    }
                
                );
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseCors("Open");

            app.MapControllers();

            return app;
        }

        private static void AddSwagger(IServiceCollection services) {
            services.AddSwaggerGen(c =>
                { c.SwaggerDoc("v1", new OpenApiInfo {
                    Version = "v1",
                    Title = "Sms Hub"
                });
                    c.OperationFilter<FileResultContentTypeOperationFilter>();
                });
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
