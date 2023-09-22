using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IEmpleadoRepository : IGenericRepository<Empleado>
{
    Task<Empleado> GetByUsernameAsync(string nombre);
    Task<Empleado> GetByRefreshTokenAsync(string nombre);
}
