using Jcf.QuinzePontos.Domain.Entities;

namespace Jcf.QuinzePontos.infrastructure.Extensions
{
    public static class ColletionsExtensions
    {
        public static ICollection<LotofacilDezena> ListIntToDeLotofacilDezena(this ICollection<int> list)
        {
            var dezenas = new HashSet<LotofacilDezena>();
            foreach (var item in list)
            {
                var dezana = new LotofacilDezena(item);
                dezenas.Add(dezana);
            }

            return dezenas;
        }
    }
}
