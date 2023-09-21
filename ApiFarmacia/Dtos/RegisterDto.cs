using System.ComponentModel.DataAnnotations;
namespace ApiFarmacia.Dtos;
public class RegisterDto
{
    [Required]
    public string Nombre { get; set; }
}