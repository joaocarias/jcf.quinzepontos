using Jcf.QuinzePontos.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Jcf.QuinzePontos.Infrastructure.DependencyInjection
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
        {
            var consoleLogger = LoggerFactory.Create(builder => builder.AddConsole());

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging();

                if (isDevelopment)
                {
                    options.UseLoggerFactory(consoleLogger).EnableDetailedErrors();
                    options.ConfigureWarnings(warnings => warnings.Log(RelationalEventId.PendingModelChangesWarning));
                }
            });

            services.AddScoped<AppDapperContext>();

            return services;
        }
    }
}
