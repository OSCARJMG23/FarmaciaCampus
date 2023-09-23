using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class PacienteRepository : GenericRepository<Paciente>, IPacienteRepository
{
    private readonly ApiFarmaciaContext _context;

    public PacienteRepository(ApiFarmaciaContext context) : base(context)
    {
        _context = context;
    }
}
