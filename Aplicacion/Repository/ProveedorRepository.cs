using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class ProveedorRepository : GenericRepository<Proveedor>, IProveedorRepository
{
    private readonly ApiFarmaciaContext _context;
    public ProveedorRepository(ApiFarmaciaContext context) : base(context)
    {
        _context = context;
    }

     public async Task<IEnumerable<Proveedor>> GetMedicamentosPorProveedor()
     {
        var medicamentosPorProvee = await _context.Proveedores
            .Include(p => p.Medicamentos)
            .ToListAsync();

        return medicamentosPorProvee;
    }

    public async Task<Proveedor> ProveedorMasSuministros2023()
    {
        /* var Proveedor = await _context.Proveedores
            .OrderByDescending(p=>p.Medicamentos
                .SelectMany(h=>h.Inventario.MovimientosInventario)
                .Where(ti=>ti.IdTipoMovimientoFk == 1 && ti.FechaMovimiento.Year ==2023)
                .Sum(ti=>ti.Cantidad))
                .FirstOrDefaultAsync();
        return Proveedor; */

/*         var proveedor = await _context.Proveedores
            .OrderByDescending(e => e.MovimientosInventario
            .Where(t=>t.IdTipoMovimientoFk ==1 && t.FechaMovimiento.Year ==2023)
            .Sum(t=>t.Cantidad))
            .FirstOrDefaultAsync(); */

/*             var proveedor = await _context.Proveedores
            .OrderByDescending(e => e.MovimientosInventario.Count())
            .FirstOrDefaultAsync(); */
            var proveedor = await _context.Proveedores
            .OrderByDescending(e => e.MovimientosInventario.Sum(t=>t.Cantidad))
            .FirstOrDefaultAsync();

        return proveedor;
    }

    public async Task<int>TotalProveedoresSuministro2023()
    {
        var TotalProveedores = await _context.Medicamentos
        .Where(e=>e.Inventario.MovimientosInventario
            .Any(t=>t.IdTipoMovimientoFk ==1 && t.FechaMovimiento.Year == 2023))
        .Select(e => e.IdProveedorFk)
        .Distinct()
        .CountAsync();
        
        return TotalProveedores;
    }
    public async Task<IEnumerable<Proveedor>> ProvedorMedicamentosMenos50Stock()
    {
        var medicamentosMenos50Stock = await _context.Medicamentos
        .Where(e=> e.Inventario.Stock < 50)
        .ToListAsync();
        
        var idProveedores = medicamentosMenos50Stock
        .Select(m=>m.IdProveedorFk)
        .Distinct()
        .ToList();

        var proveedores = await _context.Proveedores
        .Where(t=> idProveedores.Contains(t.Id))
        .ToListAsync();

        return proveedores;
    }
    public async Task<IEnumerable<Proveedor>> ProvedorSuministro5MedicamentosDiferentes2023()
    {
        var proveedoresConMedicamentos2023 = await _context.Medicamentos
        .Where(m => m.Inventario.MovimientosInventario
            .Any(mi => mi.IdTipoMovimientoFk == 1 && mi.FechaMovimiento.Year == 2023))
        .Select(m => new
        {
            ProveedorId = m.IdProveedorFk,
            MedicamentoId = m.Id
        })
        .Distinct()
        .GroupBy(m => m.ProveedorId)
        .Where(group => group.Count() >= 5)
        .Select(group => group.Key)
        .ToListAsync();

        var proveedores = await _context.Proveedores
            .Where(p => proveedoresConMedicamentos2023.Contains(p.Id))
            .ToListAsync();

        return proveedores;
    }
    public async Task<ActionResult<IEnumerable<dynamic>>> GetGananciaXProvee()
    {
        DateTime fechaInicio = new DateTime(2023, 1, 1);
        DateTime fechaFin = new DateTime(2023, 12, 31);

        var gananciaXProvee = await _context.Proveedores
            .Select(p => new
            {
                Proveedor = p.Nombre,
                Ganancia = _context.MovimientosInventarios
                    .Where(m => m.FechaMovimiento >= fechaInicio && m.FechaMovimiento <= fechaFin
                                && m.IdTipoMovimientoFk == 2
                                && m.Inventario.Medicamentos.Any(med => med.IdProveedorFk == p.Id))
                    .SelectMany(m => m.Inventario.Medicamentos) 
                    .Where(med => med.IdProveedorFk == p.Id)
                    .Sum(med => med.Precio) 
            })
            .ToListAsync();

        return gananciaXProvee.Select(p => new { p.Proveedor, p.Ganancia }).ToList();
    }

    // public async Task<IEnumerable<Medicamento>> GetMedicamentosProveedorA()
    // {
    //     var proveedorA = "ProveedorA";

    //     var medicamentosProveedorA = await _context.MovimientosInventarios
    //         .Where(m => m.IdTipoMovimientoFk == 1)
    //         .Where(m => m.Proveedor.Nombre == proveedorA)
    //         .SelectMany(m => m.Inventario.Medicamentos).ToListAsync();

    //     return medicamentosProveedorA;
    // }
    public async Task<IEnumerable<Proveedor>> GetProveNoVenMedis()
    {
        var fechaUltimoAño = DateTime.Now.AddYears(-1);

        var proveedoresNoVendieron = await _context.Proveedores
        .Where(p=>p.Medicamentos
        .Any(p=>!p.Inventario.MovimientosInventario
        .Any(p=>p.FechaMovimiento >=fechaUltimoAño && p.IdTipoMovimientoFk ==1)))
        .ToListAsync();
        

        return proveedoresNoVendieron;
    }
    
}
