using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;
public class FormaPagoConfiguration : IEntityTypeConfiguration<FormaPago>
{
    public void Configure(EntityTypeBuilder<FormaPago> builder)
    {
        builder.ToTable("formaPago");

        builder.Property(f  => f.Id)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(f  => f.Descripcion)
        .IsRequired()
        .HasMaxLength(50);
    }
}