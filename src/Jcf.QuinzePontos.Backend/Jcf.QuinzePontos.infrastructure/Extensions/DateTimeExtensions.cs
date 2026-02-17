namespace Jcf.QuinzePontos.infrastructure.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime ToUtcKind(this DateTime date)
        {
            return date.Kind switch
            {
                DateTimeKind.Utc => date,
                DateTimeKind.Local => date.ToUniversalTime(),
                DateTimeKind.Unspecified => DateTime.SpecifyKind(date, DateTimeKind.Utc),
                _ => date
            };
        }
    }
}
