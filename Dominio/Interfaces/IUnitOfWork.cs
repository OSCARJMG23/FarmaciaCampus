using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IUnitOfWork
{
    ICiudadRepository Ciudades { get; }
    IDepartamentoRepository Departamentos { get; }
    IDireccionRepository Direcciones { get; }
    IEmpleadoRepository Empleados { get; }
    IFacturaRepository Facturas { get; }
    IFormaPagoRepository FormaPagos { get; }
    IInventarioRepository Inventarios { get; }
    IMarcaRepository Marcas { get; }
    IMedicamentoRepository Medicamentos { get; }
    IMovimientoInventarioRepository MovimientosInventarios { get; }
    IPacienteRepository Pacientes { get; }
    IPaisRepository Paises { get; }
    IPresentacionRepository Presentaciones { get; }
    IProveedorRepository Proveedores { get; }
    IRecetaRepository Recetas { get; }
    ITipoMovimientoRepository TiposMovimientos { get; }
    IRolRepository Roles { get; }
    IUserRepository Users { get; }

    Task<int> SaveAsync();
}
