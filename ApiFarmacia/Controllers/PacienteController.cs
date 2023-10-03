using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using ApiFarmacia.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiFarmacia.Controllers;

public class PacienteController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public PacienteController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<PacienteDto>>> Get()
    {
        var paciente = await unitofwork.Pacientes.GetAllAsync();
        return mapper.Map<List<PacienteDto>>(paciente);
    }

    [HttpGet("{id}")]
    /* [Authorize] */
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PacientesDto>> Get(int id)
    {
        var pacientes = await unitofwork.Pacientes.GetByIdAsync(id);
        return mapper.Map<PacientesDto>(pacientes);
    }

    [HttpGet("gastado-mas-dinero-2023")]
    /* [Authorize] */
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PacienteDto>> PacienteGastadoMasDinero2023()
    {
        var paciente = await unitofwork.Pacientes.PacienteGastadoMasDinero2023();
        return mapper.Map<PacienteDto>(paciente);
    }

    [HttpGet("compraron-paracetamol-2023")]
    /* [Authorize] */
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<PacientesDto>>> PacientesCompraronQueParacetamol2023()
    {
        var pacientes = await unitofwork.Pacientes.PacientesCompraronParacetamol2023();
        return mapper.Map<List<PacientesDto>>(pacientes);
    }

    [HttpGet("no-compraron-2023")]
    /* [Authorize] */
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<PacientesDto>>> PacientesNoCompraron2023()
    {
        var pacientes = await unitofwork.Pacientes.PacienteSinCompra2023();
        return mapper.Map<List<PacientesDto>>(pacientes);
    }

    [HttpGet("total-gastadoXpaciente-2023")]
    /* [Authorize] */
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<PacienteDto>>> TotalGastadoXpaciente()
    {
        var pacientes = await unitofwork.Pacientes.TotalGastadoXpaciente2023();


        return Ok(pacientes);
    }

    [HttpPost]
    /* [Authorize] */
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Paciente>> Post(PacienteDto pacienteDto)
    {
        var paciente = this.mapper.Map<Paciente>(pacienteDto);
        this.unitofwork.Pacientes.Add(paciente);
        await unitofwork.SaveAsync();
        if (paciente == null){
            return BadRequest();
        }
        pacienteDto.Id = paciente.Id;
        return CreatedAtAction(nameof(Post), new { id = pacienteDto.Id }, pacienteDto);
    }

    [HttpPut]
    /* [Authorize] */
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<PacienteDto>> Put (int id, [FromBody]PacienteDto pacienteDto)
    {
        if(pacienteDto == null)
            return NotFound();

        var paciente = this.mapper.Map<Paciente>(pacienteDto);
        unitofwork.Pacientes.Update(paciente);
        await unitofwork.SaveAsync();
        return pacienteDto;     
    }

    [HttpDelete("{id}")]
    /* [Authorize] */
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var paciente = await unitofwork.Pacientes.GetByIdAsync(id);

        if (paciente == null)
        {
            return Notfound();
        }

        unitofwork.Pacientes.Remove(paciente);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}