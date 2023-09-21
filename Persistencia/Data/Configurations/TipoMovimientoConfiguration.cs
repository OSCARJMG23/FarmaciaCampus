using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class TipoMovimientoConfiguration : IEntityTypeConfiguration<TipoMovimientoInventario>
{
    public void Configure(EntityTypeBuilder<TipoMovimientoInventario> builder)
    {
        builder.ToTable("tipoMovimiento");

        builder.Property(t => t.Id)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(t => t.Nombre)
        .IsRequired()
        .HasMaxLength(50);
    }
}
