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
}
