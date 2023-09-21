using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;
public class FacturaConfiguration : IEntityTypeConfiguration<Factura>
{
    public void Configure(EntityTypeBuilder<Factura> builder)
    {
        builder.ToTable("factura");

        builder.Property(f  => f.Fecha)
        .IsRequired();

        builder.Property(f  => f.TotalPagar)
        .IsRequired()
        .HasColumnType("double");

        builder.Property(f  => f.IdFormaDePagoFk)
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(c => c.FormaDePago)
        .WithMany(c => c.Facturas)
        .HasForeignKey(c => c.IdFormaDePagoFk);

    }
}
