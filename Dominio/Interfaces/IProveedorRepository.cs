using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Dominio.Interfaces;

public interface IProveedorRepository : IGenericRepository<Proveedor>
{
    Task<Proveedor> ProveedorMasSuministros2023();
    Task<IEnumerable<Proveedor>> ProvedorMedicamentosMenos50Stock();
    Task<IEnumerable<Proveedor>> ProvedorSuministro5MedicamentosDiferentes2023();
    Task<int>TotalProveedoresSuministro2023();
    Task<IEnumerable<Proveedor>> GetMedicamentosPorProveedor(); 
    Task<ActionResult<IEnumerable<dynamic>>> GetGananciaXProvee();
    Task<IEnumerable<Proveedor>> GetProveNoVenMedis();
}
