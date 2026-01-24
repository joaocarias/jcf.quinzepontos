using Jcf.QuinzePontos.Application.LotofacilConcurso.Interfaces.Services;

namespace Jcf.QuinzePontos.GetResultsWorker
{
    public class LotoFacilWorker: BackgroundService
    {
        private readonly ILogger<LotoFacilWorker> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public LotoFacilWorker(
            ILogger<LotoFacilWorker> logger,
            IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(
            CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker Lotofácil iniciado.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _scopeFactory.CreateScope();
                    var service = scope.ServiceProvider
                        .GetRequiredService<ILotofacilConcursoService>();

                    await service.UpdateAsync(stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao atualizar resultados da Lotofácil");
                }
                                
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
