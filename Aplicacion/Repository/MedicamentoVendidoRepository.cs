using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository
{
    public class MedicamentoVendidoRepository : GenericRepository<MedicamentoVendido>, IMedicamentoVendidoRepository
    {
        private readonly ApiFarmaciaContext _context;
        public MedicamentoVendidoRepository(ApiFarmaciaContext context) : base (context)
        {
            _context = context;
        }
    }
}