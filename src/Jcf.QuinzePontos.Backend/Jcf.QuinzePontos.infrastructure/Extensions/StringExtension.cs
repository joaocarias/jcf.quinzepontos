using System.Globalization;
using System.Text.RegularExpressions;

namespace Jcf.QuinzePontos.Infrastructure.Extensions
{
    public static class StringExtension
    {
        public static string OnlyNumbers(this string? str)
        {
            if (str == null) return string.Empty;
            return Regex.Replace(str, "[^0-9]", "");
        }

        public static string FirstPart(this string str)
        {
            if (str == null) return string.Empty;
            string[] parts = str.Split(' ');
            return parts[0];
        }

        public static DateTime? DatePtBrToDateTime(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return null;

            var culture = new CultureInfo("pt-BR");

            if (DateTime.TryParseExact(
                    str,
                    "dd/MM/yyyy",
                    culture,
                    DateTimeStyles.None,
                    out var result))
            {
                return result;
            }

            return null;
        }
    }
}
