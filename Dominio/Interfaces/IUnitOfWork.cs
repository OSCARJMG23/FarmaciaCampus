namespace Dominio.Interfaces;

public interface IUnitOfWork
{
    IEmpleadoRepository Empleados { get; }
    IPacienteRepository Pacientes { get; }
    IProveedorRepository Proveedores { get; }
    ICompraRepository Compras { get; }
    IMedicamentoRepository Medicamentos { get; }
    IVentaRepository Ventas { get; }

    Task<int> SaveAsync();
}
