using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using ApiFarmacia.Dtos;
using Microsoft.AspNetCore.Mvc;
using ApiFarmacia.Services;
using Microsoft.AspNetCore.Authorization;

namespace ApiFarmacia.Controllers;

public class EmpleadoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public EmpleadoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
   [Authorize]    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<EmpleadoDto>>> Get()
    {
        var empleado = await unitofwork.Empleados.GetAllAsync();
        return mapper.Map<List<EmpleadoDto>>(empleado);
    }

    [HttpGet("{id}")]
   [Authorize]    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EmpleadosDto>> Get(int id)
    {
        var empleados = await unitofwork.Empleados.GetByIdAsync(id);
        return mapper.Map<EmpleadosDto>(empleados);
    }

    [HttpGet("mas-5-ventas")]
   [Authorize]    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<EmpleadosDto>>> EmpleadoMas5Ventas(int id)
    {
        var empleados5ventas = await unitofwork.Empleados.EmpleadoMas5Ventas();
        return  mapper.Map<List<EmpleadosDto>>(empleados5ventas);
    }

    [HttpGet("sin-ventas-2023")]
   [Authorize]    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<EmpleadosDto>>> EmpleadoSinVentas2023()
    {
        var empleadosSinventas2023 = await unitofwork.Empleados.EmpleadosNingunaVenta2023();
        return  mapper.Map<List<EmpleadosDto>>(empleadosSinventas2023);
    }

    [HttpGet("menos-5-ventas-2023")]
   [Authorize]    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<EmpleadosDto>>> EmpleadosMenos5Ventas2023()
    {
        var empleadosSinventas2023 = await unitofwork.Empleados.EmpleadoMenos5Ventas();
        return  mapper.Map<List<EmpleadosDto>>(empleadosSinventas2023);
    }

    [HttpGet("ventamayorcantidad-medicamentos-distintos")]
   [Authorize]    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Empleado>> EmpleadoMayorCantidadVentaDistintosMedicamentos()
    {
        var empleado = await unitofwork.Empleados.EmpleadoMayorCantidadVentaDiferenteMedicamento2023();
        return  empleado;
    }

    [HttpGet("sin-ventas-abril-2023")]
   [Authorize]    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<EmpleadosDto>>> EmpleadoSinVentasAbril2023()
    {
        var empleadosSinventasAbril2023 = await unitofwork.Empleados.EmpleadoSinVentaAbril();
        return  mapper.Map<List<EmpleadosDto>>(empleadosSinventasAbril2023);
    }
    [HttpGet("CantVentaEmple")]
   [Authorize]    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IEnumerable<dynamic>> GetCantVent()
    {
        var cantVentas = await unitofwork.Empleados.GetCantVentXEmple2023();
        return cantVentas;
    }

    [HttpPost]
   [Authorize]    [ProducesResponseType(StatusCodes.Status200OK)]
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
   [Authorize]    [ProducesResponseType(StatusCodes.Status200OK)]
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
   [Authorize]    [ProducesResponseType(StatusCodes.Status404NotFound)]
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