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

    public async Task<IEnumerable<Paciente>> GetPacientesParacetamol()
    {

        string medicamento = "Paracetamol";
        var pacientesParacetamol = await _context.t
            .Where(mv => mv.Medicamento.NombreMedicamento.ToLower() == medicamento.ToLower())
            .Select(mv => mv.FacturaVenta.Cliente)
            .Distinct()
            .ToListAsync();

        return pacientesParacetamol;
    }
}
