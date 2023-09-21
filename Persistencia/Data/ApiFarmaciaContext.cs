using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Data;

public class ApiFarmaciaContext : DbContext
{
    public ApiFarmaciaContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Proveedor> Proveedores { get; set; }
    public DbSet<Medicamento> Medicamentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}