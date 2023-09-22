using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ApiFarmacia.Dtos;
using ApiFarmacia.Helpers;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ApiFarmacia.Services;

public class EmpleadoService : IEmpleadoService
{
    private readonly JWT _jwt;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<Empleado> _passwordHasher;
    public EmpleadoService(IUnitOfWork unitOfWork, IOptions<JWT> jwt, IPasswordHasher<Empleado> passwordHasher)
    {
        _jwt = jwt.Value;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }
    public async Task<string> RegisterAsync(RegisterDto registerDto)
    {
        var empleado = new Empleado
        {
            Nombre = registerDto.Nombre
        };

        empleado.Password = _passwordHasher.HashPassword(empleado, registerDto.Password);

        var existingUser = _unitOfWork.Empleados
                                    .Find(u => u.Nombre.ToLower() == registerDto.Nombre.ToLower())
                                    .FirstOrDefault();

        if (existingUser == null)
        {
            var rolDefault = _unitOfWork.Roles
                                    .Find(u => u.Nombre == Authorization.rol_default.ToString())
                                    .First();
            try
            {
                empleado.Rols.Add(rolDefault);
                _unitOfWork.Empleados.Add(empleado);
                await _unitOfWork.SaveAsync();

                return $"Employed  {registerDto.Nombre} has been registered successfully";
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return $"Error: {message}";
            }
        }
        else
        {
            return $"Employed {registerDto.Nombre} already registered.";
        }
    }
    public async Task<EmpleadosDto> GetTokenAsync(LoginDto model)
    {
        EmpleadosDto empleadosDto = new EmpleadosDto();
        var empleado = await _unitOfWork.Empleados
                    .GetByUsernameAsync(model.Nombre);

        if (empleado == null)
        {
            empleadosDto.IsAuthenticated = false;
            empleadosDto.Message = $"Employed does not exist with name {model.Nombre}.";
            return empleadosDto;
        }

        var result = _passwordHasher.VerifyHashedPassword(empleado, empleado.Password, model.Password);

        if (result == PasswordVerificationResult.Success)
        {
            empleadosDto.IsAuthenticated = true;
            JwtSecurityToken jwtSecurityToken = CreateJwtToken(empleado);
            empleadosDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            empleadosDto.Nombre = empleado.Nombre;
            empleadosDto.Roles = empleado.Rols
                                            .Select(u => u.Nombre)
                                            .ToList();

            if (empleado.RefreshTokens.Any(a => a.IsActive))
            {
                var activeRefreshToken = empleado.RefreshTokens.Where(a => a.IsActive == true).FirstOrDefault();
                empleadosDto.RefreshToken = activeRefreshToken.Token;
                empleadosDto.RefreshTokenExpiration = activeRefreshToken.Expires;
            }
            else
            {
                var refreshToken = CreateRefreshToken();
                empleadosDto.RefreshToken = refreshToken.Token;
                empleadosDto.RefreshTokenExpiration = refreshToken.Expires;
                empleado.RefreshTokens.Add(refreshToken);
                _unitOfWork.Empleados.Update(empleado);
                await _unitOfWork.SaveAsync();
            }

            return empleadosDto;
        }
        empleadosDto.IsAuthenticated = false;
        empleadosDto.Message = $"Credenciales incorrectas para el empleado {empleado.Nombre}.";
        return empleadosDto;
    }

    public async Task<EmpleadosDto> RefreshTokenAsync(string refreshToken)
    {
        var empleadosDto = new EmpleadosDto();

        var empleado = await _unitOfWork.Empleados
                        .GetByRefreshTokenAsync(refreshToken);

        if (empleado == null)
        {
            empleadosDto.IsAuthenticated = false;
            empleadosDto.Message = $"Token is not assigned to any employed.";
            return empleadosDto;
        }

        var refreshTokenBd = empleado.RefreshTokens.Single(x => x.Token == refreshToken);

        if (!refreshTokenBd.IsActive)
        {
            empleadosDto.IsAuthenticated = false;
            empleadosDto.Message = $"Token is not active.";
            return empleadosDto;
        }
        //Revoque the current refresh token and
        refreshTokenBd.Revoked = DateTime.UtcNow;
        //generate a new refresh token and save it in the database
        var newRefreshToken = CreateRefreshToken();
        empleado.RefreshTokens.Add(newRefreshToken);
        _unitOfWork.Empleados.Update(empleado);
        await _unitOfWork.SaveAsync();
        //Generate a new Json Web Token
        empleadosDto.IsAuthenticated = true;
        JwtSecurityToken jwtSecurityToken = CreateJwtToken(empleado);
        empleadosDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        empleadosDto.Nombre = empleado.Nombre;
        empleadosDto.Roles = empleado.Rols
                                        .Select(u => u.Nombre)
                                        .ToList();
        empleadosDto.RefreshToken = newRefreshToken.Token;
        empleadosDto.RefreshTokenExpiration = newRefreshToken.Expires;
        return empleadosDto;
    }
    private RefreshToken CreateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var generator = RandomNumberGenerator.Create())
        {
            generator.GetBytes(randomNumber);
            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                Expires = DateTime.UtcNow.AddDays(10),
                Created = DateTime.UtcNow
            };
        }
    }
    private JwtSecurityToken CreateJwtToken(Empleado empleado)
    {
        var roles = empleado.Rols;
        var roleClaims = new List<Claim>();
        foreach (var role in roles)
        {
            roleClaims.Add(new Claim("roles", role.Nombre));
        }
        var claims = new[]
        {
                                new Claim(JwtRegisteredClaimNames.Sub, empleado.Nombre),
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                new Claim("uid", empleado.Id.ToString())
                        }
        .Union(roleClaims);
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
            signingCredentials: signingCredentials);
        return jwtSecurityToken;
    }

    Task<PacientesDto> IEmpleadoService.GetTokenAsync(LoginDto model)
    {
        throw new NotImplementedException();
    }

    Task<PacientesDto> IEmpleadoService.RefreshTokenAsync(string refreshToken)
    {
        throw new NotImplementedException();
    }
}