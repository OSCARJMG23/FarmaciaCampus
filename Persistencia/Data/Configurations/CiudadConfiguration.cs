using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
{
    public void Configure(EntityTypeBuilder<Ciudad> builder)
    {
        builder.ToTable("ciudad");

        builder.Property(c => c.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(c => c.IdDepartamentoFk)
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(c => c.Departamento)
        .WithMany(c => c.Ciudades)
        .HasForeignKey(c => c.IdDepartamentoFk);
    }
}