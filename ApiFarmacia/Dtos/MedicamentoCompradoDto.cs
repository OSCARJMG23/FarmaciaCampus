namespace ApiFarmacia.Dtos;

public class MedicamentoCompradoDto
{
    public int Id { get; set; }
    public int IdCompraFk { get; set; }
    public int IdMedicamentoFk { get; set; }
    public int CantidadComprada { get; set; }
    public int PrecioComprada { get; set; }
}
