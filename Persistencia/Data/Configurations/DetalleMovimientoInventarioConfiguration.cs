using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;
public class DetalleMovimientoInventarioConfiguration : IEntityTypeConfiguration<DetalleMovimientoInventario>
{
    public void Configure(EntityTypeBuilder<DetalleMovimientoInventario> builder)
    {
        builder.ToTable("detalleMovimientoInventario");

        builder
            .HasMany(d => d.Inventarios)
            .WithMany(d => d.MovimientosInventarios)
            .UsingEntity<DetalleMovimientoInventario>(

                d => d
                .HasOne(pt => pt.Inventario)
                .WithMany(t => t.MovimientosInventarios)
                .HasForeignKey(ut => ut.IdInventarioFk),


                d => d
                .HasOne(et => et.MovimientoInventario)
                .WithMany(et => et.MovimientosInventarios)
                .HasForeignKey(el => el.IdMovimientoInventarioFk),

                d =>
                {
                    d.HasKey(t => new { t.IdInventarioFk, t.IdMovimientoInventarioFk });

                });
    }
}