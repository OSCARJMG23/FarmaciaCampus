using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository
{
    public class PaisRepository : GenericRepository<Pais>, IPaisRepository
    {
        private readonly ApiFarmaciaContext _context;

        public PaisRepository(ApiFarmaciaContext context) : base(context)
        {
            _context = context;
        }
    }
}