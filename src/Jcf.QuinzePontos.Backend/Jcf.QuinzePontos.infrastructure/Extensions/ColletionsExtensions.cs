using Jcf.QuinzePontos.Domain.Entities;

namespace Jcf.QuinzePontos.infrastructure.Extensions
{
    public static class ColletionsExtensions
    {
        public static LotofacilDezenas? ListIntToDeLotofacilDezenas(this ICollection<int> list)
        {
            if (list.Count < 15)
                return null;

            var dezenas = new LotofacilDezenas(
                    list.ElementAtOrDefault(0),
                    list.ElementAtOrDefault(1),
                    list.ElementAtOrDefault(2),
                    list.ElementAtOrDefault(3), 
                    list.ElementAtOrDefault(4), 
                    list.ElementAtOrDefault(5),
                    list.ElementAtOrDefault(6),
                    list.ElementAtOrDefault(7),
                    list.ElementAtOrDefault(8),
                    list.ElementAtOrDefault(9),
                    list.ElementAtOrDefault(10),
                    list.ElementAtOrDefault(11),
                    list.ElementAtOrDefault(12),
                    list.ElementAtOrDefault(13),
                    list.ElementAtOrDefault(14)
                ) ;

            return dezenas;
        }
    }
}
