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

    public override async Task<IEnumerable<Medicamento>> GetMedisXProvee()
    {
        var medicamentosXProveedor = await _context.Medicamentos.Where(m => m.FechaExpiracion < fechaLimite).ToListAsync();
        return medicamentosXProveedor;

        foreach(var proveedor in Proveedores)
        {
            foreach(var medicamento in proveedor.Medicamentos)
            {

            }
        }
    }
}
