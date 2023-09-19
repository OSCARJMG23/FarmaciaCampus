using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class CompraConfiguration : IEntityTypeConfiguration<Compra>
{
    public void Configure(EntityTypeBuilder<Compra> builder)
    {
        builder.ToTable("compra");

        builder.Property(c => c.Id)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.IdProveedorFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.FechaCompra)
        .IsRequired();

        builder.HasOne(p => p.Proveedor)
        .WithMany(p => p.Compras)
        .HasForeignKey(p => p.IdProveedorFk);
    }
}
