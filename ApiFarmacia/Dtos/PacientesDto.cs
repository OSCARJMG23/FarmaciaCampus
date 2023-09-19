namespace ApiFarmacia.Dtos;

public class PacientesDto
{
    public int Id { get; set; }    
    public string Nombre { get; set; }    
    public string Telefono { get; set; }    
    public List<VentaDto> Ventas { get; set; }
}