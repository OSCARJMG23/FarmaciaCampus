namespace ApiFarmacia.Dtos;

public class ProveedoresDto
{
    public int Id { get; set; }
    public string Contacto { get; set; }
    public List<CompraDto> Compras { get; set; }
    public List<MedicamentoDto> Medicamentos { get; set; }
}
