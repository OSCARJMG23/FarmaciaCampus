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

        builder.Property(m => m.IdCompraFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(m => m.IdMedicamentoFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(m => m.CantidadComprada)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(m => m.PrecioCompra)
        .IsRequired()
        .HasColumnType("double");


    }    
}
