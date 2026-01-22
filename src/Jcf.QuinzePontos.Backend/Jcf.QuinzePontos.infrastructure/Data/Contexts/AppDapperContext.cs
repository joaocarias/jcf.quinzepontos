using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Jcf.QuinzePontos.Infrastructure.Data.Contexts
{
    public class AppDapperContext : IDisposable
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }
        public IConfiguration Configuration { get; }

        public AppDapperContext(IConfiguration configuration)
        {
            Configuration = configuration;

            //Connection = new MySqlConnector.MySqlConnection(Configuration.GetConnectionString("DefaultConnection"));
            Connection = new NpgsqlConnection(Configuration.GetConnectionString("DefaultConnection"));
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }    
}
