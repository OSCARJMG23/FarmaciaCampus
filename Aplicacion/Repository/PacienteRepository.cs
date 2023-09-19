using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository
{
    public class PacienteRepository : GenericRepository<Paciente>, IPacienteRepository
    {
        private readonly ApiFarmaciaContext _context;

        public PacienteRepository(ApiFarmaciaContext context) : base(context)
        {
            _context = context;
        }
    }
}