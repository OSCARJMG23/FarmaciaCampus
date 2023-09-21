using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiFarmaciaContext _context;
    private ICiudadRepository _ciudades;
    private IDepartamentoRepository _departamentos;
    private IDireccionRepository _direcciones;
    private IEmpleadoRepository _empleados;
    private IFacturaRepository _facturas;
    private IFormaPagoRepository _formaPagos;
    private IInventarioRepository _inventarios;
    private IMarcaRepository _marcas;
    private IMedicamentoRepository _medicamentos;
    private IMovimientoInventarioRepository _movimientosInventarios;
    private IPacienteRepository _pacientes;
    private IPaisRepository _paises;
    private IPresentacionRepository _presentaciones;
    private IProveedorRepository _proveedores;
    private IRecetaRepository _recetas;
    private ITipoMovimientoRepository _tiposMovimientos;

    public UnitOfWork(ApiFarmaciaContext context)
    {
        _context = context;
    }

    public ICiudadRepository Ciudades
    {
        get
        {
            if (_ciudades == null)
            {
                _ciudades = new CiudadRepository(_context);
            }
            return _ciudades;
        }
    }

    public IDepartamentoRepository Departamentos
    {
        get
        {
            if (_departamentos == null)
            {
                _departamentos = new DepartamentoRepository(_context);
            }
            return _departamentos;
        }
    }


    public IDireccionRepository Direcciones
    {
        get
        {
            if (_direcciones == null)
            {
                _direcciones = new DireccionRepository(_context);
            }
            return _direcciones;
        }
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

    public IFacturaRepository Facturas
    {
        get
        {
            if (_facturas == null)
            {
                _facturas = new FacturaRepository(_context);
            }
            return _facturas;
        }
    }

    public IFormaPagoRepository FormaPagos
    {
        get
        {
            if (_formaPagos == null)
            {
                _formaPagos = new FormaPagoRepository(_context);
            }
            return _formaPagos;
        }
    }

    public IInventarioRepository Inventarios
    {
        get
        {
            if (_inventarios == null)
            {
                _inventarios = new InventarioRepository(_context);
            }
            return _inventarios;
        }
    }

    public IMarcaRepository Marcas
    {
        get
        {
            if (_marcas == null)
            {
                _marcas = new MarcaRepository(_context);
            }
            return _marcas;
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

    public IMovimientoInventarioRepository MovimientosInventarios
    {
        get
        {
            if (_movimientosInventarios == null)
            {
                _movimientosInventarios = new MovimientoInventarioRepository(_context);
            }
            return _movimientosInventarios;
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

    public IPaisRepository Paises
    {
        get
        {
            if (_paises == null)
            {
                _paises = new PaisRepository(_context);
            }
            return _paises;
        }
    }

    public IPresentacionRepository Presentaciones
    {
        get
        {
            if (_presentaciones == null)
            {
                _presentaciones = new PresentacionRepository(_context);
            }
            return _presentaciones;
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

    public IRecetaRepository Recetas
    {
        get
        {
            if (_recetas == null)
            {
                _recetas = new RecetaRepository(_context);
            }
            return _recetas;
        }
    }

    public ITipoMovimientoRepository TiposMovimientos
    {
        get
        {
            if (_tiposMovimientos == null)
            {
                _tiposMovimientos = new TipoMovimientoRepository(_context);
            }
            return _tiposMovimientos;
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
