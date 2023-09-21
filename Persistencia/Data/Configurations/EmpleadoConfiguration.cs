using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;
public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.ToTable("empleado");

        builder.Property(e => e.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(e => e.Cargo)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(e => e.FechaContratacion)
        .IsRequired();
    }
}