using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;
public class InventarioConfiguration : IEntityTypeConfiguration<Inventario>
{
    public void Configure(EntityTypeBuilder<Inventario> builder)
    {
        builder.ToTable("inventario");

        builder.Property(i  => i.Id)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(i  => i.Stock)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(i  => i.IdMedicamentoFk)
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(c => c.Inventario)
        .WithMany(c => c.Medicamentos)
        .HasForeignKey(c => c.IdMedicamentoFk);
    }
}