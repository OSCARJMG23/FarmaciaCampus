namespace ApiFarmacia.Dtos;

public class ProveedoresDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Contacto { get; set; }
    public string Direccion { get; set; }
    public List<MedicamentoDto> Medicamentos { get; set; }
}
