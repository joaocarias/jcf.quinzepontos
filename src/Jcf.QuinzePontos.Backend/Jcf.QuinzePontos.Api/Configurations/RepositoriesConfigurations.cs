using Jcf.QuinzePontos.Domain.Interfaces.Repositories;
using Jcf.QuinzePontos.Infrastructure.Data.Repositories;

namespace Jcf.QuinzePontos.Api.Configurations
{
    public static class RepositoriesConfigurations
    {
        public static IServiceCollection AddCustomRepositories(this IServiceCollection services)
        {
            services.AddScoped<ILotofacilConcursoRepository, LotofacilConcursoRepository>();
            
            return services;
        }
    }
}
