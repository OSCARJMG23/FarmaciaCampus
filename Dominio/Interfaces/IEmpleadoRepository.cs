using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IEmpleadoRepository : IGenericRepository<Empleado>
{

    Task<IEnumerable<Empleado>> EmpleadoMas5Ventas();
    Task<IEnumerable<Empleado>> EmpleadoMenos5Ventas();
    Task<IEnumerable<Empleado>> EmpleadosNingunaVenta2023();
    Task<Empleado> EmpleadoMayorCantidadVentaDiferenteMedicamento2023();
    Task<IEnumerable<Empleado>> EmpleadoSinVentaAbril();
    Task<IEnumerable<dynamic>> GetCantVentXEmple2023();
}
