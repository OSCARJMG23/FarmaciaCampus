namespace ApiFarmacia.Dtos;

public class CompraDto
{
    public int Id { get; set; }
    public DateTime FechaCompra { get; set; }
    public int IdProveedorFk { get; set; }
}
