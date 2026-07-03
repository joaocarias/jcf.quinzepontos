using System.ComponentModel.DataAnnotations.Schema;

namespace Jcf.QuinzePontos.Domain.Entities
{
    public class LotofacilNumeroEstatistica : EntityBase
    {
        public LotofacilNumeroEstatistica(int numeroId, int currentStreak, int currentAbsenceStreak, int freqLast5, int freqLast10, int freqLast15, int freqLast20, int freqLast100, int totalAppearances)
        {
            NumeroId = numeroId;
            CurrentStreak = currentStreak;
            CurrentAbsenceStreak = currentAbsenceStreak;
            FreqLast5 = freqLast5;
            FreqLast10 = freqLast10;
            FreqLast15 = freqLast15;
            FreqLast20 = freqLast20;
            FreqLast100 = freqLast100;
            TotalAppearances = totalAppearances;
        }

        public LotofacilNumeroEstatistica() { }

        public long? LotofacilConcursoId { get; private set; }

        [ForeignKey(nameof(LotofacilConcursoId))]
        public LotofacilConcurso? LotofacilConcurso { get; private set; }

        public int NumeroId { get; private set; }
        public int CurrentStreak { get; private set; }
        public int CurrentAbsenceStreak { get; private set; }
        public int FreqLast5 { get; private set; }
        public int FreqLast10 { get; private set; }
        public int FreqLast15 { get; private set; }
        public int FreqLast20 { get; private set; }
        public int FreqLast100 { get; private set; }
        public int TotalAppearances { get; private set; }
    }
}
