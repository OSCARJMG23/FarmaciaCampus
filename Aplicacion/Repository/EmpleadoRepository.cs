using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleadoRepository
{
    private readonly ApiFarmaciaContext _context;
    public EmpleadoRepository(ApiFarmaciaContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Empleado> GetByRefreshTokenAsync(string refreshToken)
    {
        return await _context.Empleados
            .Include(u => u.Rols)
            .Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken));
    }

    public async Task<Empleado> GetByUsernameAsync(string nombre)
    {
        return await _context.Empleados
            .Include(u => u.Rols)   
            .Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u => u.Nombre.ToLower() == nombre.ToLower());
    }

}