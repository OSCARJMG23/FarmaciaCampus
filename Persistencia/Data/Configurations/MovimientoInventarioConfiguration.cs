using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class MovimientoInventarioConfiguration : IEntityTypeConfiguration<MovimientoInventario>
{
    public void Configure(EntityTypeBuilder<MovimientoInventario> builder)
    {
        builder.ToTable("movimientoInventario");

        builder.Property(m => m.Cantidad)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(m => m.Cantidad)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(m => m.Precio)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(m => m.FechaMovimiento)
        .IsRequired();

        builder.Property(m => m.IdEmpleadoFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(m => m.IdPacienteFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(m => m.IdTipoMovimientoFk)
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(m => m.Empleado)
        .WithMany(m => m.MovimientosInventarios)
        .HasForeignKey(p => p.IdEmpleadoFk);

        builder.HasOne(m => m.Paciente)
        .WithMany(m => m.MovimientosInventario)
        .HasForeignKey(p => p.IdPacienteFk);

        builder.HasOne(m => m.TipoMovimientoInventario)
        .WithMany(m => m.MovimientosInventario)
        .HasForeignKey(p => p.IdTipoMovimientoFk);

        builder.HasOne(c => c.Factura)
        .WithMany(c => c.MovimientosInventario)
        .HasForeignKey(c => c.IdFacturaFk);

        builder.HasOne(d=> d.Inventario)
        .WithMany(d=> d.MovimientosInventario)
        .HasForeignKey(d=>d.IdInventarioFk);
    }
}
