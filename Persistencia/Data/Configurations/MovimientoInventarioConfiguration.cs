using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class MovimientoInventarioConfiguration : IEntityTypeConfiguration<MovimientoInventario>
{
    public void Configure(EntityTypeBuilder<MovimientoInventario> builder)
    {
        builder.ToTable("movimientoInventario");

        builder.Property(m => m.Id)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(m => m.Cantidad)
        .IsRequired()
        .HasMaxLenght(50);

        builder.Property(m => m.Precio)
        .IsRequired()
        .HasMaxLenght(50);

        builder.Property(m => m.FechaMovimiento)
        .IsRequired();
    }
}
