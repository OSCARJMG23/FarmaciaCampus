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

    public async Task<IEnumerable<Inventario>> GetStockCincu()
    {   
        var medicamentosMenorCincu = await _context.Inventarios.Where(m => m.Stock < 50).ToListAsync();
        return medicamentosMenorCincu;
    }
    public async Task<IEnumerable<KeyValuePair<string, int>>> TotalMedicamentosVendidosXmes2023()
    {
        var totalXmes = await _context.MovimientosInventarios
        .Where(ti=>ti.IdTipoMovimientoFk == 2 && ti.FechaMovimiento.Year == 2023)
        .GroupBy(ti =>ti.FechaMovimiento.ToString("MMMM yyyy"))
        .Select(group=> new KeyValuePair<string,int>(
                group.Key,
                group.Sum(ti=>ti.Cantidad)
        ))        
        .ToListAsync();

        return totalXmes;
    }
}
