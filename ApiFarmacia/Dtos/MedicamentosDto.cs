namespace ApiFarmacia.Dtos;

public class MedicamentosDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Precio { get; set; }
    public DateTime FechaExpiracion { get; set; }
    public int IdProveedorFk { get; set; }
    public int IdMarcaFk { get; set; }
    public int IdPresentacionFk { get; set; }
}