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


    }    
}