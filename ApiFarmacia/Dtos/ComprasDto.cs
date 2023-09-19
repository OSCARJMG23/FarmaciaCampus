using Dominio.Entities;

namespace ApiFarmacia.Dtos;

public class ComprasDto
{
    public int Id { get; set; }
    public DateTime FechaCompra { get; set; }
    public int IdProveedorFk { get; set; } 
    public List<MedicamentoCompradoDto> MedicamentosComprados { get; set; }
}