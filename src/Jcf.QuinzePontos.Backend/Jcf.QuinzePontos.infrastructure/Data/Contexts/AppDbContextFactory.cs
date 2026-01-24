using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Jcf.QuinzePontos.Infrastructure.Data.Contexts
{
    public class AppDbContextFactory
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // Lê o appsettings.json da API
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
