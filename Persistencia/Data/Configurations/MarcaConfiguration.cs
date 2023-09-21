using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;
public class MarcaConfiguration  : IEntityTypeConfiguration<Marca>
{
    public void Configure(EntityTypeBuilder<Marca> builder)
    {
        builder.ToTable("marca");

        builder.Property(i  => i.Nombre)
        .IsRequired()
        .HasMaxLength(50);
    }
}