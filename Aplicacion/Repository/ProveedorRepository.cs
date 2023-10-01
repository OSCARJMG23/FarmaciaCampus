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
