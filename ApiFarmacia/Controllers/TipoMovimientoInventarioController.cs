using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using ApiFarmacia.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiFarmacia.Controllers;

public class TipoMovimientoInventarioController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public TipoMovimientoInventarioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<TipoMovimientoInventario>>> Get()
    {
        var tipoMovimiento = await unitofwork.TiposMovimientos.GetAllAsync();
        return mapper.Map<List<TipoMovimientoInventario>>(tipoMovimiento);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoMovimientoInventario>> Get(int id)
    {
        var tiposMovimientos = await unitofwork.TiposMovimientos.GetByIdAsync(id);
        return mapper.Map<TipoMovimientoInventario>(tiposMovimientos);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoMovimientoInventario>> Post(TipoMovimientoInventario tipoMovimientoo)
    {
        var tipoMovimiento = this.mapper.Map<TipoMovimientoInventario>(tipoMovimientoo);
        this.unitofwork.TiposMovimientos.Add(tipoMovimiento);
        await unitofwork.SaveAsync();
        if (tipoMovimiento == null){
            return BadRequest();
        }
        tipoMovimientoo.Id = tipoMovimiento.Id;
        return CreatedAtAction(nameof(Post), new { id = tipoMovimientoo.Id }, tipoMovimientoo);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<TipoMovimientoInventario>> Put (int id, [FromBody]TipoMovimientoInventario tipoMovimientoo)
    {
        if(tipoMovimientoo == null)
            return NotFound();

        var tipoMovimiento = this.mapper.Map<TipoMovimientoInventario>(tipoMovimientoo);
        unitofwork.TiposMovimientos.Update(tipoMovimiento);
        await unitofwork.SaveAsync();
        return tipoMovimientoo;     
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var tipoMovimiento = await unitofwork.TiposMovimientos.GetByIdAsync(id);

        if (tipoMovimiento == null)
        {
            return Notfound();
        }

        unitofwork.TiposMovimientos.Remove(tipoMovimiento);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}