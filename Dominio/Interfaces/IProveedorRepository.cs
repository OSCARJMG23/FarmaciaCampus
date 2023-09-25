using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Dominio.Interfaces;

public interface IProveedorRepository : IGenericRepository<Proveedor>
{
    Task<IEnumerable<Proveedor>> GetMedicamentosPorProveedor(); 
    Task<ActionResult<IEnumerable<dynamic>>> GetGananciaXProvee();
}
