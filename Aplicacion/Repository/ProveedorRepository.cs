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
        var Proveedor = await _context.Proveedores
            .OrderByDescending(p=>p.Medicamentos
                .SelectMany(h=>h.Inventario.MovimientosInventario)
                .Where(ti=>ti.IdTipoMovimientoFk == 1 && ti.FechaMovimiento.Year ==2023)
                .Sum(ti=>ti.Cantidad))
            .FirstOrDefaultAsync();
        return Proveedor;
    }
}
