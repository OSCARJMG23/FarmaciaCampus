using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistencia.Data.Configurations;

public class MedicamentoCompradoConfiguration : IEntityTypeConfiguration<MedicamentoComprado>
{
    public void Configure(EntityTypeBuilder<MedicamentoComprado> builder)
    {
        builder.ToTable("medicamentosComprados");

        builder.Property(m => m.Id)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(m => m.CompraId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(m => m.MedicamentoId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(m => m.CantidadComprada)
        .IsRequired()
        .HasColumnType("long");

        builder.Property(m => m.PrecioCompra)
        .IsRequired()
        .HasColumnType("double");

        builder.HasOne(m => m.Compra)
        .WithMany(m => m.MedicamentoComprado)
        .HasForeignKey(m => m.IdCompraFk);

        builder.HasOne(m => m.Medicamento)
        .WithMany(m => m.MedicamentoComprado)
        .HasForeignKey(m => m.IdMedicamentoFk);
    }    
}
