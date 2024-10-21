using Microsoft.EntityFrameworkCore;
using NutrIA.Models;

public class PacienteMap : IEntityTypeConfiguration<PacienteModel>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PacienteModel> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();

        builder.Property(p => p.Altura).IsRequired();
        builder.Property(p => p.Peso).IsRequired();
        builder.Property(p => p.Email).IsRequired().HasMaxLength(100);

        // Definindo o tipo da coluna como timestamp with time zone
        builder.Property(p => p.DataNascimento)
               .IsRequired()
               .HasColumnType("date");

        builder.Property(p => p.Sexo).IsRequired();
        builder.Property(p => p.Telefone).IsRequired();
        builder.Property(p => p.RestricoesAlimentares).IsRequired(false);
        builder.Property(p => p.Notas).IsRequired(false);
        builder.HasOne(p => p.Nutricionista)
              .WithMany(n => n.Pacientes)  // Correção: "Pacientes" no plural
              .HasForeignKey(p => p.NutricionistaId)
              .OnDelete(DeleteBehavior.Cascade);
    }
}



