using Jcf.QuinzePontos.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jcf.QuinzePontos.Infrastructure.Data.Contexts
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<LotofacilConcurso> Concursos => Set<LotofacilConcurso>();
        public DbSet<LotofacilDezenas> Dezenas => Set<LotofacilDezenas>();
        public DbSet<LotofacilRateio> Rateios => Set<LotofacilRateio>();
        public DbSet<LotofacilGanhadorUF> GanhadoresUF => Set<LotofacilGanhadorUF>();
        public DbSet<LotofacilNumeroEstatistica> NumeroEstatisticas => Set<LotofacilNumeroEstatistica>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

            modelBuilder.Entity<ApplicationUser>(builder =>
            {
                builder.Property(x => x.FullName).IsRequired().HasMaxLength(200);

                builder.HasOne<ApplicationUser>()
                    .WithMany()
                    .HasForeignKey(x => x.UserCreatedId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne<ApplicationUser>()
                    .WithMany()
                    .HasForeignKey(x => x.UserUpdateId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
