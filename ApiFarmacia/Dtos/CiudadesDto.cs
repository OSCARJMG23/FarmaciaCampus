namespace ApiFarmacia.Dtos;

public class CiudadesDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public List<PacienteDto> Pacientes { get; set; }
}