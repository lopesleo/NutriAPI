using Microsoft.EntityFrameworkCore;
using NutrIA.Models;

namespace NutrIA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<PacienteModel> Paciente { get; set; }
        public DbSet<NutricionistaModel> Nutricionista { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NutricionistaModel>()
                .HasMany(n => n.Pacientes)
                .WithOne(p => p.Nutricionista)
                .HasForeignKey(p => p.NutricionistaId);
            modelBuilder.Entity<PacienteModel>()
                .Property(n => n.DataNascimento)
                .HasColumnType("date");
            modelBuilder.Entity<NutricionistaModel>()
                .Property(n => n.DataNascimento)
                .HasColumnType("date"); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
