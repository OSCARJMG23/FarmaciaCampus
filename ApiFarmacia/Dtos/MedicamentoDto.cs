namespace ApiFarmacia.Dtos;

public class MedicamentoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Precio { get; set; }
    public int Stock { get; set; }
    public DateTime FechaExpiracion { get; set; }
    public int IdProveedorFk { get; set; }
}
