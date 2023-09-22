using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using ApiFarmacia.Dtos;
using Microsoft.AspNetCore.Mvc;
using ApiFarmacia.Services;

namespace ApiFarmacia.Controllers;

public class EmpleadoController : BaseApiController
{
    private readonly IEmpleadoService _empleadoService;
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public EmpleadoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<EmpleadoDto>>> Get()
    {
        var empleado = await unitofwork.Empleados.GetAllAsync();
        return mapper.Map<List<EmpleadoDto>>(empleado);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EmpleadosDto>> Get(int id)
    {
        var empleados = await unitofwork.Empleados.GetByIdAsync(id);
        return mapper.Map<EmpleadosDto>(empleados);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Empleado>> Post(EmpleadoDto empleadoDto)
    {
        var empleado = this.mapper.Map<Empleado>(empleadoDto);
        this.unitofwork.Empleados.Add(empleado);
        await unitofwork.SaveAsync();
        if (empleado == null){
            return BadRequest();
        }
        empleadoDto.Id = empleado.Id;
        return CreatedAtAction(nameof(Post), new { id = empleadoDto.Id }, empleadoDto);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<EmpleadoDto>> Put (int id, [FromBody]EmpleadoDto empleadoDto)
    {
        if(empleadoDto == null)
            return NotFound();

        var empleado = this.mapper.Map<Empleado>(empleadoDto);
        unitofwork.Empleados.Update(empleado);
        await unitofwork.SaveAsync();
        return empleadoDto;     
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var empleado = await unitofwork.Empleados.GetByIdAsync(id);

        if (empleado == null)
        {
            return Notfound();
        }

        unitofwork.Empleados.Remove(empleado);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    [HttpPost("token")] 
    public async Task<IActionResult> GetTokenAsync(LoginDto model)
    {
        var result = await _empleadoService.GetTokenAsync(model);
        SetRefreshTokenInCookie(result.RefreshToken);
        return Ok(result);
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken()
    {
        var refreshToken = Request.Cookies["refreshToken"];
        var response = await _empleadoService.RefreshTokenAsync(refreshToken);
        if (!string.IsNullOrEmpty(response.RefreshToken))
            SetRefreshTokenInCookie(response.RefreshToken);
        return Ok(response);
    }

    private void SetRefreshTokenInCookie(string refreshToken)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddDays(10),
        };
        Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}