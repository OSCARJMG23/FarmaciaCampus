using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IRecetaRepository : IGenericRepository<RecetaMedica>
{
    Task<IEnumerable<RecetaMedica>> Get2023Recetas(); 
}
