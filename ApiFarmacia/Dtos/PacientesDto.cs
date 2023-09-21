using Persistencia.Data.Configurations;

namespace ApiFarmacia.Dtos;

public class PacientesDto
{
    public int Id { get; set; }    
    public string Nombre { get; set; }    
    public string Telefono { get; set; }    
    public int IdDireccionFk { get; set; }    
    public List<MovimientoInventario> MovimientosInventarios { get; set; }
    public List<Receta> Recetas { get; set; }
}