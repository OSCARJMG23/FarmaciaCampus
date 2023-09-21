using ApiFarmacia.Dtos;

namespace ApiFarmacia.Services;

public interface IEmpleadoService
{
    Task<string> RegisterAsync(RegisterDto model);
    Task<EmpleadosDto> GetTokenAsync(LoginDto model);
    Task<EmpleadosDto> RefreshTokenAsync(string refreshToken);
}