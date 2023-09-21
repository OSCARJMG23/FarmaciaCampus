using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiFarmaciaContext _context;
    private IEmpleadoRepository _empleados;
    private IPacienteRepository _pacientes;
    private IProveedorRepository _proveedores;
    private IMedicamentoRepository _medicamentos;
    public UnitOfWork(ApiFarmaciaContext context)
    {
        _context = context;
    }

    public IEmpleadoRepository Empleados
    {
        get
        {
            if (_empleados == null)
            {
                _empleados = new EmpleadoRepository(_context);
            }
            return _empleados;
        }
    }

    public IPacienteRepository Pacientes
    {
        get
        {
            if (_pacientes == null)
            {
                _pacientes = new PacienteRepository(_context);
            }
            return _pacientes;
        }
    }

    public IProveedorRepository Proveedores
    {
        get
        {
            if (_proveedores == null)
            {
                _proveedores = new ProveedorRepository(_context);
            }
            return _proveedores;
        }
    }


    public IMedicamentoRepository Medicamentos
    {
        get
        {
            if (_medicamentos == null)
            {
                _medicamentos = new MedicamentoRepository(_context);
            }
            return _medicamentos;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
