using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using iText.Layout.Element;
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

        public async Task<IEnumerable<Medicamento>> MedicamentosNuncaVendidos()
        {
            var MedicamentosVendidos = await _context.Medicamentos
            .Where(tn=> tn.Inventario.MovimientosInventario
            .Any(pm => pm.IdTipoMovimientoFk ==2))
            .ToListAsync();

            var MedicamentosNuncaVendidos = await _context.Medicamentos
            .Where(tn=> !MedicamentosVendidos.Contains(tn))
            .ToListAsync();

            return MedicamentosNuncaVendidos;
        }

        public async Task<Paciente> PacienteGastadoMasDinero2023()
        {
            var movimientos2023 = await _context.MovimientosInventarios
            .Where(n => n.FechaMovimiento.Year == 2023 && n.IdTipoMovimientoFk == 2)
            .ToListAsync();

            var gastoXpaciente = movimientos2023
            .GroupBy(ti=>ti.IdPacienteFk)
            .Select(group=> new
            {
                PacienteId = group.Key,
                GastoTotal = group.Sum(ti=>ti.Precio*ti.Cantidad)
            })
            .ToList();

            var pacienteMayorGasto = gastoXpaciente
            .OrderByDescending(x => x.GastoTotal)
            .FirstOrDefault();

            if (pacienteMayorGasto != null)
            {
                var paciente = await _context.Pacientes
                .FirstOrDefaultAsync(p=>p.Id==pacienteMayorGasto.PacienteId);

                return paciente;
            }
            return null;
        }

        public async Task<IEnumerable<Empleado>> EmpleadosNingunaVenta2023()
        {
            var empleados = await _context.Empleados
            .Where(m=>m.MovimientosInventarios.Where(n=>n.IdTipoMovimientoFk == 2 && n.FechaMovimiento.Year == 2023).Count()==0)
            .ToListAsync();

            return empleados;
        }

        public async Task<IEnumerable<Paciente>> PacientesCompraronParacetamol2023()
        {
            var paciente = await _context.Pacientes
            .Where(t=>t.MovimientosInventario
            .Any(f => f.IdTipoMovimientoFk == 2 && 
                    f.FechaMovimiento.Year == 2023 && 
                    f.Inventario.Medicamentos.Any(p=>p.Nombre == "Paracetamol")))
            .ToListAsync();

            return paciente;
        }
    }
}