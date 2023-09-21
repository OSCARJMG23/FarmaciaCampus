namespace Dominio.Interfaces;

public interface IUnitOfWork
{
    ICiudadRepository Ciudades { get; }
    IDepartamentoRepository Departamentos { get; }
    IDetalleMovimientoRepository DetallesMovimientos { get; }
    IDireccionRepository Direcciones { get; }
    IEmpleadoRepository Empleados { get; }
    IFacturaRepository Facturas { get; }
    IFormaPagoRepository FormaPagos { get; }
    IInvetarioRepository Invetarios { get; }
    IMarcaRepository Marcas { get; }
    IMedicamentoRepository Medicamentos { get; }
    IMovimientoInventarioRepository MovimientosInventarios { get; }
    IPacienteRepository Pacientes { get; }
    IPaisRepository Paises { get; }
    IPresentacionRepository Presentaciones { get; }
    IProveedorRepository Proveedores { get; }
    IRecetaRepository Recetas { get; }
    ITipoMovimientoRepository TiposMovimientos { get; }
    IRol Roles { get; }

    Task<int> SaveAsync();
}
