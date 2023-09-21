using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class DireccionConfiguration : IEntityTypeConfiguration<Direccion>
{
    public void Configure(EntityTypeBuilder<Direccion> builder)
    {
        builder.ToTable("direccion");


        builder.Property(p => p.TipoViaPrincipal)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.NumeroViaPrincipal)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.NumeroViaSecundaria)
        .HasMaxLength(50);

        builder.Property(p => p.Barrio)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Complemento)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.IdCiudadFk)
        .IsRequired()
        .HasColumnType("int");


        builder.HasOne(c => c.Ciudad)
        .WithMany(c => c.Direcciones)
        .HasForeignKey(c => c.IdCiudadFk);

    }
}