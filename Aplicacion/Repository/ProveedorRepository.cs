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

    public async Task<ActionResult<IEnumerable<Proveedor>>> GetGananciaXProvee()
    {
        DateTime fechaInicio = new DateTime(2023, 1, 1);
        DateTime fechaFin = new DateTime(2023, 12, 31);

        var gananciaXProvee = await _context.Proveedores
            .Select(p => new
            {
                Proveedor = p,
                Ganancia = _context.MovimientosInventarios
                    .Where(m => m.FechaMovimiento >= fechaInicio && m.FechaMovimiento <= fechaFin
                                && m.IdTipoMovimientoFk == 2
                                && m.Medicamento.IdProveedorFk == p.Id)
                    .Sum(m => m.Precio * m.Cantidad)
            }).ToListAsync();

        return gananciaXProvee;
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

    
}
