using Jcf.QuinzePontos.Application.LotofacilConcurso.Interfaces.Services;
using Jcf.QuinzePontos.Domain.Interfaces.Repositories;

namespace Jcf.QuinzePontos.Application.LotofacilConcurso.Services
{
    public class LotofacilConcursoService : ILotofacilConcursoService
    {
        private readonly ILotofacilConcursoRepository _repository;

        public LotofacilConcursoService(
            ILotofacilConcursoRepository repository)
        {
            _repository = repository;
        }

        public async Task UpdateAsync(
            CancellationToken cancellationToken)
        {
            // Aqui depois entra:
            // - chamada HTTP para a Caixa
            // - parse do retorno
            // - salvar no banco

            Console.WriteLine($" {DateTime.UtcNow} | Atualizando resultados da Lotofácil...");

            // Por enquanto só um placeholder
            await Task.CompletedTask;
        }
    }
}
