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

    public async Task<IEnumerable<Paciente>> PacienteSinCompra2023()
    {
        var Paciente = await _context.Pacientes
        .Where(p=> p.MovimientosInventario.Where(t=> t.IdTipoMovimientoFk == 2 && t.FechaMovimiento.Year == 2023).Count() ==0)
        .ToListAsync();
        
        return Paciente;
    }
    public async Task<IEnumerable<Paciente>> TotalGastadoXpaciente2023()
    {
        var pacientesConGasto2023 = await _context.MovimientosInventarios
        .Where(n => n.IdTipoMovimientoFk == 2 && n.FechaMovimiento.Year == 2023)
        .GroupBy(n => n.IdPacienteFk)
        .Select(group => new
        {
            PacienteId = group.Key,
            TotalGastado = group.Sum(n => n.Cantidad * n.Precio)
        })
        .ToListAsync();

        var pacientes = await _context.Pacientes
            .Where(p => pacientesConGasto2023.Any(pc => pc.PacienteId == p.Id))
            .ToListAsync();

        return pacientes;
    }
}
