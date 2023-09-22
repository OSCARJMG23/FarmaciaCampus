using System.ComponentModel.DataAnnotations;

namespace ApiFarmacia.Dtos;

public class LoginDto
{
    [Required]
    public string Nombre { get; set; }
    [Required]
    public string Password { get; set; }
}