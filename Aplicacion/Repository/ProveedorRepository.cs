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

     public async Task<IEnumerable<Proveedor>> GetMedicamentosPorProveedor()
     {
        var medicamentosPorProvee = await _context.Proveedores
            .Include(p => p.Medicamentos)
            .ToListAsync();

        return medicamentosPorProvee;
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
