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

    public async Task<Empleado> EmpleadoMayorCantidadVentaDiferenteMedicamento2023()
    {
        var EmpleadoMayorCantidad = await _context.Empleados
        .Where(er=>er.MovimientosInventarios
            .Any(r=>r.IdTipoMovimientoFk == 2 && r.FechaMovimiento.Year == 2023))
            .Select(e => e)
            .OrderByDescending(e=>e.MovimientosInventarios
                .Where(ni => ni.IdTipoMovimientoFk==2 && ni.FechaMovimiento.Year==2023)
                .Select(ni => ni.Inventario.Medicamentos)
                .Distinct()
                .Count())
            .FirstOrDefaultAsync();

        return EmpleadoMayorCantidad;
    }

    public async Task<IEnumerable<Empleado>> EmpleadoSinVentaAbril()
    {
        var abril2023Inicio = new DateTime(2023, 4, 1);
        var abril2023Fin = new DateTime(2023, 4, 30);

        var Empleados = await _context.Empleados
        .Where(e => !e.MovimientosInventarios
            .Any(t=>t.IdTipoMovimientoFk == 2 &&
                    t.FechaMovimiento >= abril2023Inicio &&
                    t.FechaMovimiento <= abril2023Fin))
        .ToListAsync();

        return Empleados;
    }
}