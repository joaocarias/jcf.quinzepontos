using Jcf.QuinzePontos.Application.LotofacilConcurso.Clients;
using Jcf.QuinzePontos.Application.LotofacilConcurso.Interfaces.Services;
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
            var concurso = 1;
            Console.WriteLine($" {DateTime.UtcNow} | Iniciando atualização dos resultados da Lotofácil...");
            Console.WriteLine($" {DateTime.UtcNow} | Obtendo dados do concurso {concurso} da Lotofácil...");
            var response = await _LotofacilConcursoClient.GetAsync(1);

            if (response == null)
            {
                Console.WriteLine($" {DateTime.UtcNow} | Não foi possível obter dados para do concurso da Lotofácil.");
            }

            var concursoResultado = response?.ToLotofacilConcurso();
            concursoResultado = concursoResultado != null ? await _repository.CreateAsync(concursoResultado) : null;

            if (concursoResultado == null)            
                Console.WriteLine($" {DateTime.UtcNow} | Não foi possível salvar os dados do concurso da Lotofácil.");
            else
                Console.WriteLine($" {DateTime.UtcNow} | Atualizando resultados da Lotofácil...");
    
            await Task.CompletedTask;
        }
    }
}
