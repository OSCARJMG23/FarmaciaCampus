using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class MedicamentoRepository : GenericRepository<Medicamento>, IMedicamentoRepository
{
    private readonly ApiFarmaciaContext _context;

    public MedicamentoRepository(ApiFarmaciaContext context) : base(context)
    {
        _context = context;
    }

    public virtual void menosCincuentaUnit(Medicamento)
    {
        foreach(medicamento in Medicamentos)
        {
            
        }
    }
}
