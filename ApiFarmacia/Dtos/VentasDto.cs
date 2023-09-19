namespace ApiFarmacia.Dtos;

public class VentasDto
{
    public int Id { get; set; }
    public DateTime FechaVenta { get; set; }
    public int IdPacienteFk { get; set; }
    public int IdEmpleadoFk { get; set; }
    public List<MedicamentoVendidoDto> MedicamentosVendidos { get; set; }
}