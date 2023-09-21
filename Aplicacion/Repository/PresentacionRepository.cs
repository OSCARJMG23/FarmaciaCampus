using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository
{
    public class PresentacionRepository : GenericRepository<Presentacion>, IPresentacionRepository
    {
        private readonly ApiFarmaciaContext _context;

        public PresentacionRepository(ApiFarmaciaContext context) : base(context)
        {
            _context = context;
        }
    }
}