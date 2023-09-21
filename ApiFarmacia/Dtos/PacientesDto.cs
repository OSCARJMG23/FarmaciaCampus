using System.ComponentModel.DataAnnotations;
using Dominio.Entities;
using Persistencia.Data.Configurations;

namespace ApiFarmacia.Dtos;

public class PacientesDto
{
    public int Id { get; set; }    
    [Required(ErrorMessage = "El nombre del paciente es requerido")]
    public string Nombre { get; set; }    
    public string Telefono { get; set; }    
    public int IdDireccionFk { get; set; }    
    public List<MovimientoInventario> MovimientosInventarios { get; set; }
    public List<RecetaMedica> Recetas { get; set; }
}