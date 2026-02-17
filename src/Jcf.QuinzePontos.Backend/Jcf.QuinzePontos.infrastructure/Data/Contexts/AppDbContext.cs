using Jcf.QuinzePontos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jcf.QuinzePontos.Infrastructure.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<LotofacilConcurso> Concursos => Set<LotofacilConcurso>();
        public DbSet<LotofacilDezenas> Dezenas => Set<LotofacilDezenas>();
        public DbSet<LotofacilRateio> Rateios => Set<LotofacilRateio>();
        public DbSet<LotofacilGanhadorUF> GanhadoresUF => Set<LotofacilGanhadorUF>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("loto_facil");

            modelBuilder.Entity<LotofacilConcurso>()
                .HasIndex(x => x.Numero)
                .IsUnique();

            modelBuilder
               .Entity<LotofacilConcurso>()
               .Property(x => x.DataApuracao)
               .HasColumnType("timestamp with time zone");

            modelBuilder
               .Entity<LotofacilConcurso>()
               .Property(x => x.DataProximoConcurso)
               .HasColumnType("timestamp with time zone");

            base.OnModelCreating(modelBuilder);
        }
    }
}
