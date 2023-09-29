using Dominio.Entities;
using Dominio.Interfaces;
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

    public override async Task<IEnumerable<Proveedor>> GetAllAsync()
    {
        return await _context.Set<Proveedor>()
        .Include(e => e.Medicamentos).ToListAsync();
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
}
