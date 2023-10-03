using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using ApiFarmacia.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiFarmacia.Controllers;

public class InventarioController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public InventarioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    /* [Authorize] */
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Inventario>>> Get()
    {
        var inventario = await unitofwork.Inventarios.GetAllAsync();
        return mapper.Map<List<Inventario>>(inventario);
    }

    [HttpGet("{id}")]
    /* [Authorize] */
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Inventario>> Get(int id)
    {
        var inventario = await unitofwork.Inventarios.GetByIdAsync(id);
        return mapper.Map<Inventario>(inventario);
    }

    [HttpPost]
    /* [Authorize] */
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Inventario>> Post(Inventario inventarioo)
    {
        var inventario = this.mapper.Map<Inventario>(inventarioo);
        this.unitofwork.Inventarios.Add(inventario);
        await unitofwork.SaveAsync();
        if (inventario == null){
            return BadRequest();
        }
        inventarioo.Id = inventario.Id;
        return CreatedAtAction(nameof(Post), new { id = inventarioo.Id }, inventarioo);
    }

    [HttpPut]
    /* [Authorize] */
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Inventario>> Put (int id, [FromBody]Inventario inventarioo)
    {
        if(inventarioo == null)
            return NotFound();

        var inventario = this.mapper.Map<Inventario>(inventarioo);
        unitofwork.Inventarios.Update(inventario);
        await unitofwork.SaveAsync();
        return inventarioo;     
    }

    [HttpDelete("{id}")]
    /* [Authorize] */
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var inventario = await unitofwork.Inventarios.GetByIdAsync(id);

        if (inventario == null)
        {
            return Notfound();
        }

        unitofwork.Inventarios.Remove(inventario);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}