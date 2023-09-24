using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using ApiFarmacia.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiFarmacia.Controllers;

public class MovimientoInventarioController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public MovimientoInventarioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<MovimientoInventario>>> Get()
    {
        var movimientoInventario = await unitofwork.MovimientosInventarios.GetAllAsync();
        return mapper.Map<List<MovimientoInventario>>(movimientoInventario);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MovimientoInventario>> Get(int id)
    {
        var movimientosInventarios = await unitofwork.MovimientosInventarios.GetByIdAsync(id);
        return mapper.Map<MovimientoInventario>(movimientosInventarios);
    }

    [HttpGet("GetTotalMedisVendi")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Medicamento>> GetTotalMediVendi()
    {
        var medisVendiTotal = await unitofwork.MovimientosInventarios.GetTotalMedisVenXProve();
        return mapper.Map<Medicamento>(medisVendiTotal);
    }

    [HttpGet("GetTotalRecaudado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<decimal> GetTotalRecaudado()
    {
        var totalReacaudadoo = await unitofwork.MovimientosInventarios.GetTotalDineroVentMedi();
        return totalReacaudadoo;
    }
    
    [HttpGet("GetMediNoVendidos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public List<Medicamento> GetMediNoVendidos()
    {
        var medisNovendi = unitofwork.MovimientosInventarios.GetMedicamentosNoVendidos();
        return medisNovendi;
    }

    [HttpGet("GetPacienComParace")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IQueryable<Paciente> GetPacienComParace()
    {
        var pacientesParace = unitofwork.MovimientosInventarios.GetPacientesCompraParacetamol();
        return pacientesParace;
    }

    [HttpGet("GetPromMedis")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public double GetPromMedis()
    {
        var promedioMedis = unitofwork.MovimientosInventarios.GetPromMedisComprXPacXVen();
        return promedioMedis;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MovimientoInventario>> Post(MovimientoInventario movimientoInventarioo)
    {
        var movimientoInventario = this.mapper.Map<MovimientoInventario>(movimientoInventarioo);
        this.unitofwork.MovimientosInventarios.Add(movimientoInventario);
        await unitofwork.SaveAsync();
        if (movimientoInventario == null){
            return BadRequest();
        }
        movimientoInventarioo.Id = movimientoInventario.Id;
        return CreatedAtAction(nameof(Post), new { id = movimientoInventarioo.Id }, movimientoInventarioo);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<MovimientoInventario>> Put (int id, [FromBody]MovimientoInventario movimientoInventarioo)
    {
        if(movimientoInventarioo == null)
            return NotFound();

        var movimientoInventario = this.mapper.Map<MovimientoInventario>(movimientoInventarioo);
        unitofwork.MovimientosInventarios.Update(movimientoInventario);
        await unitofwork.SaveAsync();
        return movimientoInventarioo;     
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var movimientoInventario = await unitofwork.MovimientosInventarios.GetByIdAsync(id);

        if (movimientoInventario == null)
        {
            return Notfound();
        }

        unitofwork.MovimientosInventarios.Remove(movimientoInventario);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}