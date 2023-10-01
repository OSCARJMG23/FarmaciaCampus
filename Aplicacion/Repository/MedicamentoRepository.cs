using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class MedicamentoRepository : GenericRepository<Medicamento>, IMedicamentoRepository
{
    private readonly ApiFarmaciaContext _context;

    public MedicamentoRepository(ApiFarmaciaContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Medicamento>> GetStockCincu()
    {   
        var medicamentosMenorCincu = await _context.Medicamentos
            .Where(p=>p.Inventario.Stock <=50)
            .ToListAsync();
        return medicamentosMenorCincu; 
    }

    public async Task<IEnumerable<Medicamento>> Get2024Expiracion()
    {   
        DateTime fechaLimite = new DateTime(2023, 12, 31);
        var medicamentosSinCaducar = await _context.Medicamentos.Where(m => m.FechaExpiracion <= fechaLimite).ToListAsync();
        return medicamentosSinCaducar;
    }

    public async Task<int> TotalVenParace()
    {
        var unidadesVendidas = await _context.MovimientosInventarios
            .Where(movimiento => movimiento.IdTipoMovimientoFk == 2)
            .Where(movimiento => movimiento.Inventario.Medicamentos.Any(medicamento => medicamento.Nombre == "Paracetamol"))
            .SumAsync(movimiento => movimiento.Cantidad);

        return unidadesVendidas;
    }

    public async Task<IEnumerable<Medicamento>> Get2024DespuExpiracion()
    {   
        var medicamentosExp2024 = await _context.Medicamentos
        .Where(m => m.FechaExpiracion.Year == 2024)
        .ToListAsync();
        return medicamentosExp2024;
    }    

    public async Task<int> GetTotalMedicVendidosMarzo()
    {
        DateTime fechaInicio = new DateTime(2023, 3, 1);
        DateTime fechaFin = new DateTime(2023, 3, 31);

        var totalMedicamentosVendidos = await _context.MovimientosInventarios
            .Where(movimiento => movimiento.IdTipoMovimientoFk == 2 &&
                                movimiento.FechaMovimiento >= fechaInicio &&
                                movimiento.FechaMovimiento <= fechaFin)
            .SumAsync(movimiento => movimiento.Cantidad);

        return totalMedicamentosVendidos;
    }

    public async Task<Medicamento> GetMediMenosVen2023()
    {
        var fechaInicio = new DateTime(2023, 1, 1);
        var fechaFin = new DateTime(2023, 12, 31);

        var medicamentoMenosVendido = await _context.MovimientosInventarios
            .Where(m => m.IdTipoMovimientoFk == 2 && m.FechaMovimiento >= fechaInicio && m.FechaMovimiento <= fechaFin)
            .GroupBy(m => m.IdInventarioFk)
            .OrderBy(g => g.Sum(m => m.Cantidad))
            .Select(g => g.FirstOrDefault().Inventario.Medicamentos).FirstOrDefaultAsync();

        return medicamentoMenosVendido.FirstOrDefault();
    }

    public async Task<Medicamento> GetMasCaro()
    {   
        var medicamentoMasCaro =  await _context.Medicamentos.OrderByDescending(m => m.Precio).FirstOrDefaultAsync();
        return medicamentoMasCaro;
    }
}
