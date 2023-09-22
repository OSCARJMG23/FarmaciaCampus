using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class RecetaConfiguration : IEntityTypeConfiguration<RecetaMedica>
{
    public void Configure(EntityTypeBuilder<RecetaMedica> builder)
    {
        builder.ToTable("receta");

        builder.Property(r => r.Descripcion)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(r => r.IdPacienteFk)
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(p => p.Paciente)
        .WithMany(p => p.Recetas)
        .HasForeignKey(p => p.IdPacienteFk);
        
    }
}
