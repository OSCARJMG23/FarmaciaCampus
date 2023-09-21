using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class MedicamentoConfiguration : IEntityTypeConfiguration<Medicamento>
{
    public void Configure (EntityTypeBuilder<Medicamento> builder)
    {
        builder.ToTable ("medicamento");

        builder.Property(m => m.Id)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(m => m.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(m => m.Precio)
        .IsRequired()
        .HasColumnType("double");

        builder.Property(m => m.FechaExpiracion)
        .IsRequired();

        builder.Property(m => m.IdProveedorFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(m => m.IdPresentacionFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(m => m.IdMarcaFk)
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(m => m.Proveedor)
        .WithMany(m => m.Medicamentos)
        .HasForeignKey(p => p.IdProveedorFk);

        builder.HasOne(m => m.Marca)
        .WithMany(m => m.Medicamentos)
        .HasForeignKey(m => m.IdMarcaFk);

        builder.HasOne(m => m.Presentacion)
        .WithMany(m => m.Medicamentos)
        .HasForeignKey(m => m.IdPresentacionFk);
    }
}
