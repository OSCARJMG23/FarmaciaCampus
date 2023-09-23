using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IMedicamentoRepository : IGenericRepository<Medicamento>
{
    Task<IEnumerable<Inventario>> GetStockCincu(); 
    Task<IEnumerable<Medicamento>> Get2024Expiracion(); 
    Task<int> TotalVenParace();  
    Task<IEnumerable<Medicamento>> Get2024DespuExpiracion();
    Task<IEnumerable<Medicamento>> GetMarzo();  
    Task<Medicamento> GetMasCaro();  
}
