using Dominio.Entities;
using Persistencia.Data.Configurations;

namespace ApiFarmacia.Dtos;

public class EmpleadosDto
{
    public string Message { get; set; }
    public bool IsAuthenticated { get; set; }
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Cargo { get; set; }
    public List<MovimientoInventario> MovimientosInventarios { get; set; }
    public List<string> Roles { get; set; }
}
