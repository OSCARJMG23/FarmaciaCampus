using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
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
    public DbSet<Compra> Compras { get; set; }
    public DbSet<Medicamento> Medicamentos { get; set; }
    public DbSet<MedicamentoComprado> MedicamentosComprados { get; set; }
    public DbSet<MedicamentoVendido> MedicamentosVendidos { get; set; }
    public DbSet<Venta> Ventas { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}