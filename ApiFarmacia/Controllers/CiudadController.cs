using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using ApiFarmacia.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiFarmacia.Controllers;

public class CiudadController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public CiudadController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<CiudadDto>>> Get()
    {
        var ciudad = await unitofwork.Ciudades.GetAllAsync();
        return mapper.Map<List<CiudadDto>>(ciudad);
    }

    [HttpGet("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CiudadesDto>> Get(int id)
    {
        var ciudades = await unitofwork.Ciudades.GetByIdAsync(id);
        return mapper.Map<CiudadesDto>(ciudades);
    }

    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Ciudad>> Post(CiudadDto ciudadDto)
    {
        var ciudad = this.mapper.Map<Ciudad>(ciudadDto);
        this.unitofwork.Ciudades.Add(ciudad);
        await unitofwork.SaveAsync();
        if (ciudad == null){
            return BadRequest();
        }
        ciudadDto.Id = ciudad.Id;
        return CreatedAtAction(nameof(Post), new { id = ciudadDto.Id }, ciudadDto);
    }

    [HttpPut]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<CiudadDto>> Put (int id, [FromBody]CiudadDto ciudadDto)
    {
        if(ciudadDto == null)
            return NotFound();

        var ciudad = this.mapper.Map<Ciudad>(ciudadDto);
        unitofwork.Ciudades.Update(ciudad);
        await unitofwork.SaveAsync();
        return ciudadDto;     
    }

    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var ciudad = await unitofwork.Ciudades.GetByIdAsync(id);

        if (ciudad == null)
        {
            return Notfound();
        }

        unitofwork.Ciudades.Remove(ciudad);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}