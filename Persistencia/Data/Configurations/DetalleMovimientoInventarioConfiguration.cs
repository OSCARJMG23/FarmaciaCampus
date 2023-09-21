using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;
public class DetalleMovimientoInventarioConfiguration : IEntityTypeConfiguration<DetalleMovimientoInventario>
{
    public void Configure(EntityTypeBuilder<DetalleMovimientoInventario> builder)
    {
        builder.ToTable("detalleMovimientoInventario");

        builder.Property(c => c.IdInventarioFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.IdMovimientoInventarioFk)
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(c => c.Inventario)
        .WithMany(c => c.DetallesMovimientosInventarios)
        .HasForeignKey(c => c.IdInventarioFk);

        builder.HasOne(c => c.MovimientoInventario)
        .WithMany(c => c.DetallesMovimientosInventarios)
        .HasForeignKey(c => c.IdMovimientoInventarioFk);
    }
}