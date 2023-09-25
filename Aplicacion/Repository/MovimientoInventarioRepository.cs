using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class MovimientoInventarioRepository : GenericRepository<MovimientoInventario>, IMovimientoInventarioRepository
{
    private readonly ApiFarmaciaContext _context;

    public MovimientoInventarioRepository(ApiFarmaciaContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Medicamento>> GetMedicamentosProveedorA()
    {
        var proveedorA = "ProveedorA";

        var medicamentosProveedorA = await _context.MovimientosInventarios
            .Where(m => m.IdTipoMovimientoFk == 1)
            .Join(
                _context.Medicamentos,
                movimiento => movimiento.IdInventarioFk,
                medicamento => medicamento.IdInventarioFk,
                (movimiento, medicamento) => new { Movimiento = movimiento, Medicamento = medicamento }
            )
            .Where(med => med.Medicamento.Proveedor.Nombre == proveedorA)
            .Select(med => med.Medicamento).ToListAsync();

        return medicamentosProveedorA;
    }

    public async Task<IEnumerable<Medicamento>> GetTotalMedisVenXProve()
    {
        var medicamentosVendidosPorProveedor = await _context.MovimientosInventarios
            .Where(m => m.IdTipoMovimientoFk == 2)
            .Join(
                _context.Medicamentos,
                movimiento => movimiento.IdInventarioFk,
                medicamento => medicamento.IdInventarioFk,
                (movimiento, medicamento) => new { Movimiento = movimiento, Medicamento = medicamento }
            )
            .Select(med => med.Medicamento)
            .ToListAsync();

        return medicamentosVendidosPorProveedor;
    }

    public async Task<decimal> GetTotalDineroVentMedi()
    {
        decimal totalVentas = await _context.MovimientosInventarios
            .Where(movimiento => movimiento.IdTipoMovimientoFk == 2)
            .Where(movimiento => movimiento.Inventario != null && movimiento.Inventario.Medicamentos != null)
            .SelectMany(movimiento => movimiento.Inventario.Medicamentos, (movimiento, medicamento) => movimiento.Cantidad * medicamento.Precio)
            .SumAsync();

        return totalVentas;
    }

    public List<Medicamento> GetMedicamentosNoVendidos()
    {
        var medicamentosVendidosIds = _context.MovimientosInventarios
            .Where(m => m.IdTipoMovimientoFk == 2)
            .Select(m => m.IdInventarioFk);

        var medicamentosNoVendidos = _context.Medicamentos
            .Where(m => !medicamentosVendidosIds.Contains(m.IdInventarioFk)).ToList();

        return medicamentosNoVendidos;
    }

    public IQueryable<Paciente> GetPacientesCompraParacetamol()
    {
        var pacientesCompraParacetamol = from movimiento in _context.MovimientosInventarios
                                            where movimiento.IdTipoMovimientoFk == 1
                                            join inventario in _context.Inventarios on movimiento.IdInventarioFk equals inventario.Id
                                            join medicamento in _context.Medicamentos on inventario.Id equals medicamento.IdInventarioFk
                                            where medicamento.Nombre == "Paracetamol"
                                            select movimiento.Paciente;

        return pacientesCompraParacetamol;
    }

    public async Task<IEnumerable<Medicamento>> GetMediMenosVendido()
    {
        var medicamentosVendidosIds = _context.MovimientosInventarios
            .Where(m => m.IdTipoMovimientoFk == 2)
            .Select(m => m.IdInventarioFk);

        var medicamentosNoVendidos = _context.Medicamentos
            .Where(m => !medicamentosVendidosIds.Contains(m.IdInventarioFk)).ToList();

        return medicamentosNoVendidos;
    }

    public double GetPromMedisComprXPacXVen()
    {
        var promedio = _context.MovimientosInventarios
            .Where(m => m.IdTipoMovimientoFk == 1)
            .GroupBy(m => m.IdPacienteFk) 
            .Select(group => new
            {
                PacienteId = group.Key,
                Promedio = group.Average(m => m.Cantidad) 
            })
            .Select(p => p.Promedio).Average();

        return promedio;
    }

    public async Task<ActionResult<IEnumerable<Proveedor>>> GetProveNoVenMedis()
    {
        DateTime fechaInicio = new DateTime(2023, 1, 1);
        DateTime fechaFin = new DateTime(2023, 12, 31);

        var proveedoresVendieron = _context.MovimientosInventarios
            .Where(m => m.FechaMovimiento >= fechaInicio && m.FechaMovimiento <= fechaFin
                && m.IdTipoMovimientoFk == 2)
            .Select(m => m.IdInventarioFk);
        var proveedoresNoVendieron = _context.Proveedores
            .Where(p => !proveedoresVendieron.Contains(p.IdDireccionFk)).ToList();

        return proveedoresNoVendieron;
    }
}
