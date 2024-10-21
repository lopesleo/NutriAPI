using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutrIA.Models;

namespace NutrIA.Data.Map
{
    public class NutricionistaMap : IEntityTypeConfiguration<NutricionistaModel>
    {
        public void Configure(EntityTypeBuilder<NutricionistaModel> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Telefone).IsRequired();
            builder.HasMany(n => n.Pacientes)
                   .WithOne(p => p.Nutricionista)
                   .HasForeignKey(p => p.NutricionistaId)
                   .OnDelete(DeleteBehavior.Cascade); 
            builder.Property(p => p.CRN).IsRequired();
            builder.Property(p => p.CPF).IsRequired();
            builder.Property(p => p.DataNascimento).IsRequired();
        }
    }
}
