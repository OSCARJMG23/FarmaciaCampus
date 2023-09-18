using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistencia.Data.Configurations;

public class MedicamentoVendidoConfiguration : IEntityTypeConfiguration<MedicamentoVendido>
{
    public void Configure(EntityTypeBuilder<MedicamentoVendido> builder)
    {
        builder.ToTable("medicamentosVendidos");

        builder.Property(m => m.Id)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(m => m.VentaId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(m => m.MedicamentoId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(m => m.CantidadVendida)
        .IsRequired()
        .HasColumnType("long");

        builder.Property(m => m.PrecioVenta)
        .IsRequired()
        .HasColumnType("double");

        builder.HasOne(m => m.Venta)
        .WithMany(m => m.MedicamentoVenta)
        .HasForeignKey(m => m.IdVentaFk);

        builder.HasOne(m => m.Medicamento)
        .WithMany(m => m.MedicamentoVenta)
        .HasForeignKey(m => m.IdMedicamentoFk);
    }    
}