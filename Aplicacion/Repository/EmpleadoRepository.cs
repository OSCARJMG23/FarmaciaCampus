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


    public async Task<Empleado> GetByUsernameAsync(string nombre)
    {
        return await _context.Empleados

            .FirstOrDefaultAsync(u => u.Nombre.ToLower() == nombre.ToLower());
    }
        public async Task<IEnumerable<Empleado>> EmpleadoMas5Ventas()
        {
/*             var Ventas = await _context.MovimientosInventarios
            .Where(fv => fv.IdTipoMovimientoFk == 2).Where(nt=>nt.Empleado.MovimientosInventarios.Count()>=5)
            .ToListAsync();
            return Ventas; */
            var empleados = await _context.Empleados
            .Where(fn=>fn.MovimientosInventarios.Where(nt=> nt.IdTipoMovimientoFk == 2).Count()>=5)
            .ToListAsync();
            return empleados;
        }

        public async Task<IEnumerable<Empleado>> EmpleadoMenos5Ventas()
        {
            DateTime FechaInicio = new DateTime(2023, 1, 1);
            DateTime FechaFinal = new DateTime(2023, 12, 31);
            var empleados = await _context.Empleados
            .Where(v => v.MovimientosInventarios.Where(n=>n.IdTipoMovimientoFk ==2 && n.FechaMovimiento >= FechaInicio && n.FechaMovimiento <= FechaFinal).Count()<=5)
            .ToListAsync();
            return empleados;
        }
        public async Task<IEnumerable<Empleado>> EmpleadosNingunaVenta2023()
        {
            var empleados = await _context.Empleados
            .Where(m=>m.MovimientosInventarios.Where(n=>n.IdTipoMovimientoFk == 2 && n.FechaMovimiento.Year == 2023).Count()==0)
            .ToListAsync();

            return empleados;
        }

    public async Task<Empleado> EmpleadoMayorCantidadVentaDiferenteMedicamento2023()
    {
        var EmpleadoMayorCantidad = await _context.Empleados
        .Where(er=>er.MovimientosInventarios
            .Any(r=>r.IdTipoMovimientoFk == 2 && r.FechaMovimiento.Year == 2023))
            .Select(e => e)
            .OrderByDescending(e=>e.MovimientosInventarios
                .Where(ni => ni.IdTipoMovimientoFk==2 && ni.FechaMovimiento.Year==2023)
                .Select(ni => ni.IdInventarioFk)
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
    public async Task<IEnumerable<dynamic>> GetCantVentXEmple2023()
    {
        DateTime fechaInicio = new DateTime(2023, 1, 1);
        DateTime fechaFin = new DateTime(2024, 1, 1);

        var cantVentasPorEmpleado = await _context.MovimientosInventarios
            .Where(m => m.IdTipoMovimientoFk == 2 && m.FechaMovimiento >= fechaInicio && m.FechaMovimiento < fechaFin)
            .GroupBy(m => m.IdEmpleadoFk)
            .Select(g => new
            {
                Empleado = _context.Empleados.FirstOrDefault(e=>e.Id ==g.Key).Nombre,
                Ventas = g.Count()
            })
            .ToListAsync();


        return cantVentasPorEmpleado.Select(p=> new {p.Empleado, p.Ventas }).ToList();
    }
}