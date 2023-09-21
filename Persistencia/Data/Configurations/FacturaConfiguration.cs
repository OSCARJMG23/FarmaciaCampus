using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;
public class FacturaConfiguration : IEntityTypeConfiguration<Factura>
{
    public void Configure(EntityTypeBuilder<Factura> builder)
    {
        builder.ToTable("factura");

        builder.Property(f  => f.Id)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(f  => f.Fecha)
        .IsRequired();

        builder.Property(f  => f.TotalPagar)
        .IsRequired()
        .HasColumnType("double");

        builder.Property(f  => f.IdMovimientoFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(f  => f.IdFormaPagoFk)
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(c => c.FormaPago)
        .WithMany(c => c.Facturas)
        .HasForeignKey(c => c.IdFormaPagoFk);

        builder.HasOne(c => c.Factura)
        .WithMany(c => c.Movimientos)
        .HasForeignKey(c => c.IdMovimientoFk);
    }
}
