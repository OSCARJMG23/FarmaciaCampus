using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class VentaConfiguration : IEntityTypeConfiguration<Venta>
{
    public void Configure(EntityTypeBuilder<Venta> builder)
    {
        builder.ToTable("venta");

        builder.Property(c => c.Id)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.IdPacienteFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.IdEmpleadoFk)
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(e => e.Empleado)
        .WithMany(e => e.Ventas)
        .HasForeignKey(e => e.IdEmpleadoFk);

        builder.HasOne(p => p.Paciente)
        .WithMany(p => p.Ventas)
        .HasForeignKey(p => p.IdPacienteFk);
    }
}
