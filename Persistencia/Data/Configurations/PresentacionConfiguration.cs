using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class PresentacionConfiguration : IEntityTypeConfiguration<Presentacion>
{
    public void Configure(EntityTypeBuilder<Presentacion> builder)
    {
        builder.ToTable("presentacion");

        builder.Property(i  => i.Nombre)
        .IsRequired()
        .HasMaxLength(50);

    }
}
