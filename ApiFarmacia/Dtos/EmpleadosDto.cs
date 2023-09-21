using Dominio.Entities;
using Persistencia.Data.Configurations;

namespace ApiFarmacia.Dtos;

public class EmpleadosDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Cargo { get; set; }
    public List<MovimientoInventario> MovimientosInventarios { get; set; }
}
