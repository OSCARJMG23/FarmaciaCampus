using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IPacienteRepository : IGenericRepository<Paciente>
{
    Task<IEnumerable<Paciente>> PacientesCompraronParacetamol2023();
    Task<IEnumerable<Paciente>> PacienteSinCompra2023();
    Task<IEnumerable<Paciente>> TotalGastadoXpaciente2023();
    Task<Paciente> PacienteGastadoMasDinero2023();
}
