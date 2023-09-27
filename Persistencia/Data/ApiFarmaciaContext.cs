using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Data;

public class ApiFarmaciaContext : DbContext
{
    public ApiFarmaciaContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Ciudad> Ciudades { get; set; }
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<Direccion> Direcciones { get; set; }
    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Factura> Facturas { get; set; }
    public DbSet<FormaDePago> FormaPagos { get; set; }
    public DbSet<Inventario> Inventarios { get; set; }
    public DbSet<Marca> Marcas { get; set; }
    public DbSet<Medicamento> Medicamentos { get; set; }
    public DbSet<MovimientoInventario> MovimientosInventarios { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Pais> Paises { get; set; }
    public DbSet<Presentacion> Presentaciones { get; set; }
    public DbSet<Proveedor> Proveedores { get; set; }
    public DbSet<RecetaMedica> Recetas { get; set; }
    public DbSet<TipoMovimientoInventario> TiposMovimientos { get; set; }
    public DbSet<Rol> Rols { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRol> UsersRols { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}