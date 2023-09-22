using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class RecetaRepository : GenericRepository<RecetaMedica>, IRecetaRepository
{
    private readonly ApiFarmaciaContext _context;

    public RecetaRepository(ApiFarmaciaContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RecetaMedica>> Get2023Recetas()
    {   
    DateTime fechaRecetas = new DateTime(2023, 1, 2);
    var fechasDespuesEnero = await _context.Recetas.Where(m => m. < fechaRecetas).ToListAsync();
    return fechasDespuesEnero;
    }
}
