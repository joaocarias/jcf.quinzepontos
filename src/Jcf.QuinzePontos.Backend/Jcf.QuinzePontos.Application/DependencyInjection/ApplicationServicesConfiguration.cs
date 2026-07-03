using Jcf.QuinzePontos.Application.Auth.Interfaces.Services;
using Jcf.QuinzePontos.Application.Auth.Services;
using Jcf.QuinzePontos.Application.LotofacilConcurso.Clients;
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

        public static IServiceCollection AddAuthApplicationServices(
        this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }

        public static IServiceCollection AddApplicationHttpsClients(
        this IServiceCollection services)
        {
            services.AddHttpClient<ILotofacilConcursoClient, LotofacilConcursoClient>();
            return services;
        }
    }
}
