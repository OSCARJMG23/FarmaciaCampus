using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using ApiFarmacia.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiFarmacia.Controllers;

public class PresentacionController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public PresentacionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Presentacion>>> Get()
    {
        var presentacion = await unitofwork.Presentaciones.GetAllAsync();
        return mapper.Map<List<Presentacion>>(presentacion);
    }

    [HttpGet("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Presentacion>> Get(int id)
    {
        var presentaciones = await unitofwork.Presentaciones.GetByIdAsync(id);
        return mapper.Map<Presentacion>(presentaciones);
    }

    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Presentacion>> Post(Presentacion presentacionn)
    {
        var presentacion = this.mapper.Map<Presentacion>(presentacionn);
        this.unitofwork.Presentaciones.Add(presentacion);
        await unitofwork.SaveAsync();
        if (presentacion == null){
            return BadRequest();
        }
        presentacionn.Id = presentacion.Id;
        return CreatedAtAction(nameof(Post), new { id = presentacionn.Id }, presentacionn);
    }

    [HttpPut]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Presentacion>> Put (int id, [FromBody]Presentacion presentacionn)
    {
        if(presentacionn == null)
            return NotFound();

        var presentacion = this.mapper.Map<Presentacion>(presentacionn);
        unitofwork.Presentaciones.Update(presentacion);
        await unitofwork.SaveAsync();
        return presentacionn;     
    }

    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var presentacion = await unitofwork.Presentaciones.GetByIdAsync(id);

        if (presentacion == null)
        {
            return Notfound();
        }

        unitofwork.Presentaciones.Remove(presentacion);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}