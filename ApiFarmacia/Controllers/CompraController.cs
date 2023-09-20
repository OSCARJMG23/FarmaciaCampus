using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using ApiFarmacia.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiFarmacia.Controllers;

public class CompraController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public CompraController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<CompraDto>>> Get()
    {
        var compra = await unitofwork.Compras.GetAllAsync();
        return mapper.Map<List<CompraDto>>(compra);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ComprasDto>> Get(int id)
    {
        var compras = await unitofwork.Compras.GetByIdAsync(id);
        return mapper.Map<ComprasDto>(compras);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Compra>> Post(CompraDto compraDto)
    {
        var compra = this.mapper.Map<Compra>(compraDto);
        this.unitofwork.Compras.Add(compra);
        await unitofwork.SaveAsync();
        if (compra == null){
            return BadRequest();
        }
        compraDto.Id = compra.Id;
        return CreatedAtAction(nameof(Post), new { id = compraDto.Id }, compraDto);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<CompraDto>> Put (int id, [FromBody]CompraDto compraDto)
    {
        if(compraDto == null)
            return NotFound();

        var compra = this.mapper.Map<Compra>(compraDto);
        unitofwork.Compras.Update(compra);
        await unitofwork.SaveAsync();
        return compraDto;     
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var compra = await unitofwork.Compras.GetByIdAsync(id);

        if (compra == null)
        {
            return Notfound();
        }

        unitofwork.Compras.Remove(compra);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}