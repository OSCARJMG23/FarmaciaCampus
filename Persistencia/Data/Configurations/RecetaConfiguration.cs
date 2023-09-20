using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class RecetaConfiguration : IEntityTypeConfiguration<Receta>
{
    public void Configure(EntityTypeBuilder<Receta> builder)
    {
        builder.ToTable("receta");

        builder.Property(r => r.Id)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(r => r.Descripcion)
        .IsRequired()
        .HasMaxLength(50);
    }
}
