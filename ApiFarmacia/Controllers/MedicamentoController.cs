using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using ApiFarmacia.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiFarmacia.Controllers;

public class MedicamentoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public MedicamentoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<MedicamentoDto>>> Get()
    {
        var medicamento = await unitofwork.Medicamentos.GetAllAsync();
        return mapper.Map<List<MedicamentoDto>>(medicamento);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MedicamentosDto>> Get(int id)
    {
        var medicamentos = await unitofwork.Medicamentos.GetByIdAsync(id);
        return mapper.Map<MedicamentosDto>(medicamentos);
    }

    [HttpGet("GetStock50")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<MedicamentoDto>>> GetStock50()
    {
    var medicamento = await unitofwork.Medicamentos.GetStockCincu();
    return mapper.Map<List<MedicamentoDto>>(medicamento);
    }

    [HttpGet("nunca-vendido")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<MedicamentosDto>>> MedicamentosNuncaVendidos()
    {
        var medicamentosNuncaVendidos = await unitofwork.Medicamentos.MedicamentosNuncaVendidos();
        return mapper.Map<List<MedicamentosDto>>(medicamentosNuncaVendidos);
    }

    [HttpGet("total-medicamentos-vendidosXmes-2023")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<MedicamentosDto>>> TotalMedicamentosVendidosXmes2023()
    {
        var medicamentosVendidos2023 = await unitofwork.Medicamentos.TotalMedicamentosVendidosXmes2023();
        return mapper.Map<List<MedicamentosDto>>(medicamentosVendidos2023);
    }

    [HttpGet("medicamentos-vendidosXmes-2023")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<MedicamentosDto>>> MedicamentosVendidosXmes2023()
    {
        var medicamentosVendidos2023 = await unitofwork.Medicamentos.MedicamentosVendidosXmes();
        return mapper.Map<List<MedicamentosDto>>(medicamentosVendidos2023);
    }

    [HttpGet("medicamentos-no-vendidos-2023")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<MedicamentosDto>>> MedicamentosNoVendidos2023()
    {
        var medicamentosVendidos2023 = await unitofwork.Medicamentos.MedicamentosSinVenta2023();
        return mapper.Map<List<MedicamentosDto>>(medicamentosVendidos2023);
    }

    [HttpGet("total-medicamentos-vendidos-primer-trimestre-2023")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<int>> MedicamentosVendidosPrimerTrimestre2023()
    {
        var medicamentosVendidos2023 = await unitofwork.Medicamentos.TotalMedicamentosVendidosTrimestre2023();
        return medicamentosVendidos2023;
    }

    [HttpGet("medicamentos-precio-mas-50-stock-menos-100")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<MedicamentosDto>>> MedicamentosPrecioMas50StockMenos100()
    {
        var medicamentosSelec = await unitofwork.Medicamentos.MedicamentosPrecioMas50Stockmenos100();
        return mapper.Map<List<MedicamentosDto>>(medicamentosSelec);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Medicamento>> Post(MedicamentoDto medicamentoDto)
    {
        var medicamento = this.mapper.Map<Medicamento>(medicamentoDto);
        this.unitofwork.Medicamentos.Add(medicamento);
        await unitofwork.SaveAsync();
        if (medicamento == null){
            return BadRequest();
        }
        medicamentoDto.Id = medicamento.Id;
        return CreatedAtAction(nameof(Post), new { id = medicamentoDto.Id }, medicamentoDto);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<MedicamentoDto>> Put (int id, [FromBody]MedicamentoDto medicamentoDto)
    {
        if(medicamentoDto == null)
            return NotFound();

        var medicamento = this.mapper.Map<Medicamento>(medicamentoDto);
        unitofwork.Medicamentos.Update(medicamento);
        await unitofwork.SaveAsync();
        return medicamentoDto;     
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var medicamento = await unitofwork.Medicamentos.GetByIdAsync(id);

        if (medicamento == null)
        {
            return Notfound();
        }

        unitofwork.Medicamentos.Remove(medicamento);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}