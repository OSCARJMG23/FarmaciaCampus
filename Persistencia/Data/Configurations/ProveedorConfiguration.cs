using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
{
    public void Configure(EntityTypeBuilder<Proveedor> builder)
    {
        builder.ToTable("proveedor");

        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Contacto)
        .IsRequired()
        .HasMaxLength(50);

        
        builder.HasOne(c => c.Direccion)
        .WithMany(c => c.Proveedores)
        .HasForeignKey(c => c.IdDireccionFk);
    }
}
