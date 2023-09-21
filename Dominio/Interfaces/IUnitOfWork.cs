namespace Dominio.Interfaces;

public interface IUnitOfWork
{
    IEmpleadoRepository Empleados { get; }
    IPacienteRepository Pacientes { get; }
    IProveedorRepository Proveedores { get; }
    IMedicamentoRepository Medicamentos { get; }
    Task<int> SaveAsync();
}
