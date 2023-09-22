using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.configurations;

public class RolConfiguration : IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {
        builder.ToTable("rol");

        builder.Property(p => p.Nombre)
        .HasMaxLength(50)
        .IsRequired();

        builder.HasMany(p => p.Empleados)
        .WithOne(p => p.Rol)
        .HasForeignKey(p => p.IdRolFk);
    }
}