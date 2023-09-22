using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class RolRepository : GenericRepository<Rol>, IRolRepository
{
    private readonly ApiFarmaciaContext _context;

    public RolRepository(ApiFarmaciaContext context) : base(context)
    {
        _context = context;
    }
}
