using System.ComponentModel.DataAnnotations.Schema;

namespace Jcf.QuinzePontos.Domain.Entities
{
    public class LotofacilDezenas : EntityBase
    {
        public long? LotofacilConcursoId { get; private set; }

        [ForeignKey(nameof(LotofacilConcursoId))]
        public LotofacilConcurso? LotofacilConcurso { get; private set; } = null!;

        public int N1 { get; private set; }
        public int N2 { get; private set; }
        public int N3 { get; private set; }
        public int N4 { get; private set; }
        public int N5 { get; private set; }
        public int N6 { get; private set; }
        public int N7 { get; private set; }
        public int N8 { get; private set; }
        public int N9 { get; private set; }
        public int N10 { get; private set; }
        public int N11 { get; private set; }
        public int N12 { get; private set; }
        public int N13 { get; private set; }
        public int N14 { get; private set; }
        public int N15 { get; private set; }

        public LotofacilDezenas() { }

        public LotofacilDezenas(int n1, int n2, int n3, int n4, int n5, int n6, int n7, int n8, int n9, int n10, int n11, int n12, int n13, int n14, int n15)
        {
            N1 = n1;
            N2 = n2;
            N3 = n3;
            N4 = n4;
            N5 = n5;
            N6 = n6;
            N7 = n7;
            N8 = n8;
            N9 = n9;
            N10 = n10;
            N11 = n11;
            N12 = n12;
            N13 = n13;
            N14 = n14;
            N15 = n15;
        }
    }
}
