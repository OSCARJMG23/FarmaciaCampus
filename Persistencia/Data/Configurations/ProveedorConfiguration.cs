using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
{
    public void Configure(EntityTypeBuilder<Proveedor> builder)
    {
        builder.ToTable("proveedor");

        builder.Property(p => p.Id)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Contacto)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Direccion)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.IdMedicamentoFk)
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(p => p.Proveedor)
        .WithMany(p => p.Medicamentos)
        .HasForeignKey(p => p.IdMedicamentoFk);
    }
}
