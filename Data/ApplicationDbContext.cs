using Microsoft.EntityFrameworkCore;
using NutrIA.Models;

namespace NutrIA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Nutricionista> Nutricionista { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nutricionista>()
                .HasMany(n => n.Pacientes)
                .WithOne(p => p.Nutricionista)
                .HasForeignKey(p => p.NutricionistaId);
            modelBuilder.Entity<Paciente>()
                .Property(n => n.DataNascimento)
                .HasColumnType("date");
            modelBuilder.Entity<Nutricionista>()
                .Property(n => n.DataNascimento)
                .HasColumnType("date"); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
