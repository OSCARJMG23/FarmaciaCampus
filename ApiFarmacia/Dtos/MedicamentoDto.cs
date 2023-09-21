namespace ApiFarmacia.Dtos;

public class MedicamentoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Precio { get; set; }
    public DateTime FechaExpiracion { get; set; }
}
