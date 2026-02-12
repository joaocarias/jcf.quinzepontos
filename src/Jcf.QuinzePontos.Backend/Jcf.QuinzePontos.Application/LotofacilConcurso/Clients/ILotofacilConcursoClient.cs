using Jcf.QuinzePontos.Application.LotofacilConcurso.Models.DTOs;

namespace Jcf.QuinzePontos.Application.LotofacilConcurso.Clients
{
    public interface ILotofacilConcursoClient
    {
        Task<LotofacilConcursoDTO?> GetAsync(int numero);
    }
}
