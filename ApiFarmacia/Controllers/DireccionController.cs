using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using ApiFarmacia.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiFarmacia.Controllers;

public class DireccionController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public DireccionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
   [Authorize]    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Direccion>>> Get()
    {
        var direccion = await unitofwork.Direcciones.GetAllAsync();
        return mapper.Map<List<Direccion>>(direccion);
    }

    [HttpGet("{id}")]
   [Authorize]    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Direccion>> Get(int id)
    {
        var direcciones = await unitofwork.Direcciones.GetByIdAsync(id);
        return mapper.Map<Direccion>(direcciones);
    }

    [HttpPost]
   [Authorize]    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Direccion>> Post(Direccion direccionn)
    {
        var direccion = this.mapper.Map<Direccion>(direccionn);
        this.unitofwork.Direcciones.Add(direccion);
        await unitofwork.SaveAsync();
        if (direccion == null){
            return BadRequest();
        }
        direccionn.Id = direccion.Id;
        return CreatedAtAction(nameof(Post), new { id = direccionn.Id }, direccionn);
    }

    [HttpPut]
   [Authorize]    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Direccion>> Put (int id, [FromBody]Direccion direccionn)
    {
        if(direccionn == null)
            return NotFound();

        var direccion = this.mapper.Map<Direccion>(direccionn);
        unitofwork.Direcciones.Update(direccion);
        await unitofwork.SaveAsync();
        return direccionn;     
    }

    [HttpDelete("{id}")]
   [Authorize]    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var direccion = await unitofwork.Direcciones.GetByIdAsync(id);

        if (direccion == null)
        {
            return Notfound();
        }

        unitofwork.Direcciones.Remove(direccion);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}