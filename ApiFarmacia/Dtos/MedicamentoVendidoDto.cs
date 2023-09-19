namespace ApiFarmacia.Dtos;

public class MedicamentoVendidoDto
{
    public int Id { get; set; }
    public int IdMedicamentoFk { get; set; }
    public int IdVentaFk { get; set; }
    public int CantidadVendida { get; set; }
    public int Precio { get; set; }
}
