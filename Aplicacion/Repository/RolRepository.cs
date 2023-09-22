using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class RolRepository : GenericRepository<Rol>, IRolRepository
{
    private readonly ApiFarmaciaContext _context;

    public RolRepository(ApiFarmaciaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Rol>> GetAllAsync()
    {
        return await _context.Rols 
            .Include(p => p.Empleados)
            .ToListAsync();
    }

    public override async Task<Rol> GetByIdAsync(int id)
    {
        return await _context.Rols
        .Include(p => p.Empleados)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}
