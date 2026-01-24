using Jcf.QuinzePontos.Application.LotofacilConcurso.Interfaces.Services;
using Jcf.QuinzePontos.Application.LotofacilConcurso.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Jcf.QuinzePontos.Application.DependencyInjection
{
    public static class ApplicationServicesConfiguration
    {
        public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
        {
            services.AddScoped<ILotofacilConcursoService, LotofacilConcursoService>();
            return services;
        }
    }
}
