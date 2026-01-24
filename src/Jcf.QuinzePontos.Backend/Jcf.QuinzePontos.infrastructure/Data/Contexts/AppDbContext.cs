using Jcf.QuinzePontos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jcf.QuinzePontos.Infrastructure.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<LotofacilConcurso> Concursos => Set<LotofacilConcurso>();
        public DbSet<LotofacilDezena> Dezenas => Set<LotofacilDezena>();
        public DbSet<LotofacilRateio> Rateios => Set<LotofacilRateio>();
        public DbSet<LotofacilGanhadorUF> GanhadoresUF => Set<LotofacilGanhadorUF>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("loto_facil");

            modelBuilder.Entity<LotofacilConcurso>()
                .HasIndex(x => x.Numero)
                .IsUnique();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
