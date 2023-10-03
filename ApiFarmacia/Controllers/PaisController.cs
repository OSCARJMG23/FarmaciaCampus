using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using ApiFarmacia.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiFarmacia.Controllers;

public class PaisController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public PaisController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    /* [Authorize] */
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Pais>>> Get()
    {
        var pais = await unitofwork.Paises.GetAllAsync();
        return mapper.Map<List<Pais>>(pais);
    }

    [HttpGet("{id}")]
    /* [Authorize] */
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pais>> Get(int id)
    {
        var paises = await unitofwork.Paises.GetByIdAsync(id);
        return mapper.Map<Pais>(paises);
    }

    [HttpPost]
    /* [Authorize] */
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pais>> Post(Pais paiss)
    {
        var pais = this.mapper.Map<Pais>(paiss);
        this.unitofwork.Paises.Add(pais);
        await unitofwork.SaveAsync();
        if (pais == null){
            return BadRequest();
        }
        paiss.Id = pais.Id;
        return CreatedAtAction(nameof(Post), new { id = paiss.Id }, paiss);
    }

    [HttpPut]
    /* [Authorize] */
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pais>> Put (int id, [FromBody]Pais paiss)
    {
        if(paiss == null)
            return NotFound();

        var pais = this.mapper.Map<Pais>(paiss);
        unitofwork.Paises.Update(pais);
        await unitofwork.SaveAsync();
        return paiss;     
    }

    [HttpDelete("{id}")]
    /* [Authorize] */
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var pais = await unitofwork.Paises.GetByIdAsync(id);

        if (pais == null)
        {
            return Notfound();
        }

        unitofwork.Paises.Remove(pais);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}