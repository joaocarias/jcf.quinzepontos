using Jcf.QuinzePontos.Application.LotofacilConcurso.Models.DTOs;
using Jcf.QuinzePontos.Application.LotofacilConcurso.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Jcf.QuinzePontos.Application.LotofacilConcurso.Clients
{
    public class LotofacilConcursoClient : ILotofacilConcursoClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<LotofacilConcursoClient> _logger;
        private readonly LotofacilApiOptions _options;
        
        public LotofacilConcursoClient(IOptions<LotofacilApiOptions> options, HttpClient httpClient, ILogger<LotofacilConcursoClient> logger)
        {
            _options = options.Value;
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<LotofacilConcursoDto?> GetAsync(int numeroConcurso)
        {
            try
            {
                if(numeroConcurso <= 0)
                {
                    _logger.LogError($"{nameof(LotofacilConcursoClient)} | {nameof(GetAsync)} | nConcurso: {numeroConcurso} | Error: Número do concurso inválido");
                    return null;
                }

                var url = $"{_options.BaseUrl}{_options.EndPoint}/{numeroConcurso}";
                _logger.LogInformation($"{DateTime.Now} | Get: {url}");

                var response = await _httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"{nameof(LotofacilConcursoClient)} | {nameof(GetAsync)} | nConcurso: {numeroConcurso} | Error: Code: {response.StatusCode.ToString()} Messege: Não foi possível consultar.");
                    return null;
                }                    

                return await response.Content.ReadFromJsonAsync<LotofacilConcursoDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(LotofacilConcursoClient)} | {nameof(GetAsync)} | nConcurso: {numeroConcurso} | Error: {ex.Message}");
                return null;
            }
        }
    }
}
