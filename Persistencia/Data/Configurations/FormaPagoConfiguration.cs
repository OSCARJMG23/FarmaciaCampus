using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;
public class FormaPagoConfiguration : IEntityTypeConfiguration<FormaDePago>
{
    public void Configure(EntityTypeBuilder<FormaDePago> builder)
    {
        builder.ToTable("formaPago");

        builder.Property(f  => f.Id)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(f  => f.Nombre)
        .IsRequired()
        .HasMaxLength(50);

    }
}