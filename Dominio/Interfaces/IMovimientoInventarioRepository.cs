using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IMovimientoInventarioRepository : IGenericRepository<MovimientoInventario>
{
    Task<IEnumerable<Medicamento>> GetMedicamentosProveedorA();
    Task<IEnumerable<Medicamento>> GetTotalMedisVenXProve(); 
    Task<decimal> GetTotalDineroVentMedi();
    List<Medicamento> GetMedicamentosNoVendidos();
    IQueryable<Paciente> GetPacientesCompraParacetamol();
    double GetPromMedisComprXPacXVen();
}
