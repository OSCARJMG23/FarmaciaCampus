using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;
public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
{
    public void Configure(EntityTypeBuilder<Paciente> builder)
    {
        builder.ToTable("paciente");

        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Telefono)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(c => c.Direccion)
        .WithMany(c => c.Pacientes)
        .HasForeignKey(c => c.IdDireccionFk);
    }
}