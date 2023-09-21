using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class PresentacionConfiguration : IEntityTypeConfiguration<Presentacion>
{
    public void Configure(EntityTypeBuilder<Presentacion> builder)
    {
        builder.ToTable("presentacion");

        builder.Property(i  => i.Id)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(i  => i.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(i  => i.IdMedicamentoFk)
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(p => p.Presentacion)
        .WithMany(p => p.Medicamentos)
        .HasForeignKey(p => p.IdMedicamentoFk);
    }
}
