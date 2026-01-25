namespace Jcf.QuinzePontos.Application.LotofacilConcurso.Interfaces.Services
{
    public interface ILotofacilConcursoService
    {
        Task GetConcursoAsync(CancellationToken cancellationToken);
    }
}
