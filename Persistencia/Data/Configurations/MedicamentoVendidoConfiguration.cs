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

        builder.Property(m => m.IdVentaFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(m => m.IdMedicamentoFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(m => m.CantidadVendida)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(m => m.Precio)
        .IsRequired()
        .HasColumnType("double");

        builder.HasOne(m => m.Venta)
        .WithMany(m => m.MedicamentoVendidos)
        .HasForeignKey(m => m.IdVentaFk);

        builder.HasOne(m => m.Medicamento)
        .WithMany(m => m.MedicamentosVendidos)
        .HasForeignKey(m => m.IdMedicamentoFk);
    }    
}