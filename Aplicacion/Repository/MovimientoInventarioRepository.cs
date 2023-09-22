using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository
{
    public class MovimientoInventarioRepository : GenericRepository<MovimientoInventario>, IMovimientoInventarioRepository
    {
        private readonly ApiFarmaciaContext _context;

        public MovimientoInventarioRepository(ApiFarmaciaContext context) : base(context)
        {
            _context = context;
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
            return empleados ;
        }
    }
}