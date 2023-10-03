using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using ApiFarmacia.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiFarmacia.Controllers;

public class FormaDePagoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public FormaDePagoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    /* [Authorize] */
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<FormaDePago>>> Get()
    {
        var formaPago = await unitofwork.FormaPagos.GetAllAsync();
        return mapper.Map<List<FormaDePago>>(formaPago);
    }

    [HttpGet("{id}")]
    /* [Authorize] */
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FormaDePago>> Get(int id)
    {
        var formaPagos = await unitofwork.FormaPagos.GetByIdAsync(id);
        return mapper.Map<FormaDePago>(formaPagos);
    }

    [HttpPost]
    /* [Authorize] */
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FormaDePago>> Post(FormaDePago formaPagoo)
    {
        var formaPago = this.mapper.Map<FormaDePago>(formaPagoo);
        this.unitofwork.FormaPagos.Add(formaPago);
        await unitofwork.SaveAsync();
        if (formaPago == null){
            return BadRequest();
        }
        formaPagoo.Id = formaPago.Id;
        return CreatedAtAction(nameof(Post), new { id = formaPagoo.Id }, formaPagoo);
    }

    [HttpPut]
    /* [Authorize] */
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<FormaDePago>> Put (int id, [FromBody]FormaDePago formaPagoo)
    {
        if(formaPagoo == null)
            return NotFound();

        var formaPago = this.mapper.Map<FormaDePago>(formaPagoo);
        unitofwork.FormaPagos.Update(formaPago);
        await unitofwork.SaveAsync();
        return formaPagoo;     
    }

    [HttpDelete("{id}")]
    /* [Authorize] */
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var formaPago = await unitofwork.FormaPagos.GetByIdAsync(id);

        if (formaPago == null)
        {
            return Notfound();
        }

        unitofwork.FormaPagos.Remove(formaPago);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}