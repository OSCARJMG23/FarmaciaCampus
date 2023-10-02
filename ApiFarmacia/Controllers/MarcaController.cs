using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using ApiFarmacia.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiFarmacia.Controllers;

public class MarcaController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public MarcaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Marca>>> Get()
    {
        var marca = await unitofwork.Marcas.GetAllAsync();
        return mapper.Map<List<Marca>>(marca);
    }

    [HttpGet("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Marca>> Get(int id)
    {
        var marcas = await unitofwork.Marcas.GetByIdAsync(id);
        return mapper.Map<Marca>(marcas);
    }

    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Marca>> Post(Marca marcaa)
    {
        var marca = this.mapper.Map<Marca>(marcaa);
        this.unitofwork.Marcas.Add(marca);
        await unitofwork.SaveAsync();
        if (marca == null){
            return BadRequest();
        }
        marcaa.Id = marca.Id;
        return CreatedAtAction(nameof(Post), new { id = marcaa.Id }, marcaa);
    }

    [HttpPut]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Marca>> Put (int id, [FromBody]Marca marcaa)
    {
        if(marcaa == null)
            return NotFound();

        var marca = this.mapper.Map<Marca>(marcaa);
        unitofwork.Marcas.Update(marca);
        await unitofwork.SaveAsync();
        return marcaa;     
    }

    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var marca = await unitofwork.Marcas.GetByIdAsync(id);

        if (marca == null)
        {
            return Notfound();
        }

        unitofwork.Marcas.Remove(marca);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}