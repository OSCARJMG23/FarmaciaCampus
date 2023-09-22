using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using ApiFarmacia.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiFarmacia.Controllers;

public class FacturaController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public FacturaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Factura>>> Get()
    {
        var factura = await unitofwork.Facturas.GetAllAsync();
        return mapper.Map<List<Factura>>(factura);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Factura>> Get(int id)
    {
        var facturas = await unitofwork.Facturas.GetByIdAsync(id);
        return mapper.Map<Factura>(facturas);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Factura>> Post(Factura facturaa)
    {
        var factura = this.mapper.Map<Factura>(facturaa);
        this.unitofwork.Facturas.Add(factura);
        await unitofwork.SaveAsync();
        if (factura == null){
            return BadRequest();
        }
        facturaa.Id = factura.Id;
        return CreatedAtAction(nameof(Post), new { id = facturaa.Id }, facturaa);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Factura>> Put (int id, [FromBody]Factura facturaa)
    {
        if(facturaa == null)
            return NotFound();

        var factura = this.mapper.Map<Factura>(facturaa);
        unitofwork.Facturas.Update(factura);
        await unitofwork.SaveAsync();
        return facturaa;     
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var factura = await unitofwork.Facturas.GetByIdAsync(id);

        if (factura == null)
        {
            return Notfound();
        }

        unitofwork.Facturas.Remove(factura);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}