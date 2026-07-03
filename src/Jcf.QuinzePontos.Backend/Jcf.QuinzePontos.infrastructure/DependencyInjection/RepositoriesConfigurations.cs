using Jcf.QuinzePontos.Domain.Interfaces.Repositories;
using Jcf.QuinzePontos.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Jcf.QuinzePontos.Infrastructure.DependencyInjection
{
    public static class RepositoriesConfigurations
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ILotofacilConcursoRepository, LotofacilConcursoRepository>();
            services.AddScoped<ILotofacilNumeroEstatisticaRepository, LotofacilNumeroEstatisticaRepository>();

            return services;
        }
    }
}
