using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class MedicamentoConfiguration : IEntityTypeConfiguration<Medicamento>
{
    public void Configure (EntityTypeBuilder<Medicamento> builder)
    {
        builder.ToTable ("medicamento");

        builder.Property(c => c.Id)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(c => c.Precio)
        .IsRequired()
        .HasColumnType("double");

        builder.Property(c => c.Stock)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.FechaExpiracion)
        .IsRequired();

        builder.Property(c => c.IdProveedorFk)
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(p => p.Proveedor)
        .WithMany(p => p.Medicamentos)
        .HasForeignKey(p => p.IdProveedorFk);

        builder.HasMany(m => m.MedicamentosComprados)
        .WithOne(m => m.Medicamento)
        .HasForeignKey(m => m.IdMedicamentoFk);

        builder.HasMany(m => m.MedicamentosVendidos)
        .WithOne(m => m.Medicamento)
        .HasForeignKey(m => m.IdMedicamentoFk);
    }
}
