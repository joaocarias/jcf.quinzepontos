using Jcf.QuinzePontos.Application.LotofacilConcurso.Clients;
using Jcf.QuinzePontos.Application.LotofacilConcurso.Interfaces.Services;
using Jcf.QuinzePontos.Application.LotofacilConcurso.Models.DTOs;
using Jcf.QuinzePontos.Domain.Interfaces.Repositories;

namespace Jcf.QuinzePontos.Application.LotofacilConcurso.Services
{
    public class LotofacilConcursoService : ILotofacilConcursoService
    {
        private readonly ILotofacilConcursoRepository _repository;
        private readonly ILotofacilConcursoClient _LotofacilConcursoClient;

        public LotofacilConcursoService(
            ILotofacilConcursoRepository repository, ILotofacilConcursoClient lotofacilConcursoClient)
        {
            _repository = repository;
            _LotofacilConcursoClient = lotofacilConcursoClient;
        }

        public async Task GetConcursoAsync(
            CancellationToken cancellationToken)
        {
            var response = await GetNextAsync();
            if (response == null)
            {
                Console.WriteLine($" {DateTime.UtcNow} | Não foi possível obter dados para do concurso da Lotofácil.");
                return;
            }

            var concursoResultado = response?.ToLotofacilConcurso();
            concursoResultado = concursoResultado != null ? await _repository.CreateAsync(concursoResultado) : null;

            if (concursoResultado == null)            
                Console.WriteLine($" {DateTime.UtcNow} | Não foi possível salvar os dados do concurso da Lotofácil.");
            else
                Console.WriteLine($" {DateTime.UtcNow} | Atualizando resultados da Lotofácil...");
    
            await Task.CompletedTask;
        }

        private async Task<LotofacilConcursoDTO?> GetNextAsync()
        {
            var concurso = await _repository.GetLastAsync();
            var next = concurso == null ? 1 : concurso?.Numero + 1;

            Console.WriteLine($" {DateTime.UtcNow} | Iniciando atualização dos resultados da Lotofácil...");
            Console.WriteLine($" {DateTime.UtcNow} | Obtendo dados do concurso {next} da Lotofácil...");
            return await _LotofacilConcursoClient.GetAsync(next.GetValueOrDefault());            
        }
    }
}
