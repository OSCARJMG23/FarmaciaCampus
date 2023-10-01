using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IMedicamentoRepository : IGenericRepository<Medicamento>
{
    Task<IEnumerable<Medicamento>> GetStockCincu(); 
    Task<IEnumerable<Medicamento>> Get2024Expiracion(); 
    Task<int> TotalVenParace();  
    Task<IEnumerable<Medicamento>> Get2024DespuExpiracion();
    Task<Medicamento> GetMasCaro();  
    Task<int> GetTotalMedicVendidosMarzo();  
    Task<Medicamento> GetMediMenosVen2023();
}
