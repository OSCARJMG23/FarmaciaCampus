using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IMedicamentoRepository : IGenericRepository<Medicamento>
{
    Task<IEnumerable<Inventario>> GetStockCincu();
    Task<IEnumerable<Medicamento>> MedicamentosNuncaVendidos();
    Task<IEnumerable<KeyValuePair<string, int>>> TotalMedicamentosVendidosXmes2023();
    Task<IEnumerable<Medicamento>> MedicamentosVendidosXmes();
    Task<IEnumerable<Medicamento>> MedicamentosSinVenta2023();
    Task<int> TotalMedicamentosVendidosTrimestre2023();
    Task<IEnumerable<Medicamento>> MedicamentosPrecioMas50Stockmenos100();
}
