using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository
{
    public class VentaRepository : GenericRepository<Venta>, IVentaRepository 
    {
        private readonly ApiFarmaciaContext _context;
        public VentaRepository(ApiFarmaciaContext context) : base(context)
        {
            _context = context;
        }
    }
}