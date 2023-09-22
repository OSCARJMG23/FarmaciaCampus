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

    public async Task<IEnumerable<Medicamento>> GetCompraProvA()
    {
        Proveedor proveedor = proveedor =
        var medicamentoCompraA = await _context.Medicamentos.Where(m =>m.) 
    }

    public async Task<IEnumerable<Medicamento>> Get2024Expiracion()
    {   
        DateTime fechaLimite = new DateTime(2023, 12, 31);
        var medicamentosSinCaducar = await _context.Medicamentos.Where(m => m.FechaExpiracion < fechaLimite).ToListAsync();
        return medicamentosSinCaducar;
    }

    public async Task<IEnumerable<Medicamento>> GetParacetamol()
    {   
        var paracetamol = await _context.Medicamentos.Where(m => m.Nombre == "paracetamol").ToListAsync();
        return paracetamol;
    }

    public async Task<IEnumerable<Medicamento>> Get2024DespuExpiracion()
    {   
        DateTime fechaLimite = new DateTime(2024, 1, 1);
        var medicamentosExp2024 = await _context.Medicamentos.Where(m => m.FechaExpiracion < fechaLimite).ToListAsync();
        return medicamentosExp2024;
    }    

    public async Task<IEnumerable<Medicamento>> GetMarzo()
    {   
        DateTime fechaLimite = new DateTime(2023, 3, 1);
        var medicamentosMarzo = await _context.Medicamentos.Where(m => m.FechaExpiracion < fechaLimite).ToListAsync();
        return medicamentosMarzo;
    }
}
