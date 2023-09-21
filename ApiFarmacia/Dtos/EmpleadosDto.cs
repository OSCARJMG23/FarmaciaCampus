using Persistencia.Data.Configurations;

namespace ApiFarmacia.Dtos;

public class EmpleadosDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Cargo { get; set; }
    public List<MovimientoInventarioDto> MovimientosInventarios { get; set; }
}
