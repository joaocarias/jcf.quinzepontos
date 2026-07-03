namespace Jcf.QuinzePontos.Domain.Constants
{
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string Basic = "Basic";

        public static readonly IReadOnlyCollection<string> All = [Admin, Basic];
    }
}
