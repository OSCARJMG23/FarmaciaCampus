using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Dominio.Interfaces;

public interface IMovimientoInventarioRepository : IGenericRepository<MovimientoInventario>
{
    Task<IEnumerable<Medicamento>> GetMedicamentosProveedorA();
    Task<IEnumerable<Medicamento>> GetTotalMedisVenXProve(); 
    Task<decimal> GetTotalDineroVentMedi();
    List<Medicamento> GetMedicamentosNoVendidos();
    IQueryable<Paciente> GetPacientesCompraParacetamol();
    double GetPromMedisComprXPacXVen();
    Task<ActionResult<IEnumerable<Proveedor>>> GetProveNoVenMedis();
}
