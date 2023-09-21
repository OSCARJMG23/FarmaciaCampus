using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;
public class MarcaConfiguration  : IEntityTypeConfiguration<Presentacion>
{
    public void Configure(EntityTypeBuilder<Presentacion> builder)
    {
        builder.ToTable("marca");

        builder.Property(i  => i.Id)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(i  => i.Nombre)
        .IsRequired()
        .HasMaxLength(50);
    }
}