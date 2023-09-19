namespace ApiFarmacia.Dtos;

public class MedicamentosDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Precio { get; set; }
    public int Stock { get; set; }
    public DateTime FechaExpiracion { get; set; }
    public int IdProveedorFk { get; set; }
    public List<MedicamentoCompradoDto> MedicamentosComprados { get; set; }
    public List<MedicamentoVendidoDto> MedicamentosVendidos { get; set; }
}