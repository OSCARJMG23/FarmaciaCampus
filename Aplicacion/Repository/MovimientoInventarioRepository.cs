using Dominio.Entities;
using Dominio.Interfaces;
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

    public List<Medicamento> GetMedicamentosNoVendidos(List<Medicamento> medicamentos, List<MovimientoInventario> movimientosInventario)
    {
        var medicamentosVendidosIds = movimientosInventario
            .Where(m => m.IdTipoMovimientoFk == 2)
            .Select(m => m.IdInventarioFk);

        var medicamentosNoVendidos = medicamentos
            .Where(m => !medicamentosVendidosIds.Contains(m.IdInventarioFk)).ToList();

        return medicamentosNoVendidos;
    }

    public async Task<IEnumerable<Paciente>> GetPacientesParacetamol()
{
    string medicamentoNombre = "Paracetamol";

    var pacientesParacetamol = await _context.MovimientosInventarios
        .Where(mv => mv.IdTipoMovimientoFk == 1) 
        .Where(mv => mv.Medicamentos.Any(m => m.Nombre == medicamentoNombre)) 
        .Select(mv => mv.Factura.Paciente) 
        .Distinct()
        .ToListAsync();

    return pacientesParacetamol;
}
}
