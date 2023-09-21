namespace ApiFarmacia.Dtos;

public class DepartamentosDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public List<CiudadDto> Ciudades { get; set; }
}