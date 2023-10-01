using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using ApiFarmacia.Dtos;
using Microsoft.AspNetCore.Mvc;
using Aplicacion.Repository;

namespace ApiFarmacia.Controllers;

public class ProveedorController : BaseApiController
{
    private IUnitOfWork unitofwork;
    readonly IMapper mapper;

    public ProveedorController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<ProveedorDto>>> Get()
    {
        var proveedor = await unitofwork.Proveedores.GetAllAsync();
        return mapper.Map<List<ProveedorDto>>(proveedor);
    }

    [HttpGet("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<ProveedoresDto>> GetById(int id)
    {
        var proveedores = await unitofwork.Proveedores.GetByIdAsync(id);
        return mapper.Map<ProveedoresDto>(proveedores);
    }

    [HttpGet("GetMedisXProve")] 
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<ProveedoresDto>>> GetMedisXProve()
    {
        var proveedor = await unitofwork.Proveedores.GetMedicamentosPorProveedor();
        return mapper.Map<List<ProveedoresDto>>(proveedor);
    }

    [HttpGet("suministro-mas-medicamentos-2023")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<ProveedorDto>> ProveedorMasSuministro2023()
    {
        var proveedor = await unitofwork.Proveedores.ProveedorMasSuministros2023();
        if(proveedor == null)
        {
            return BadRequest();
        }
        return mapper.Map<ProveedorDto>(proveedor);
    }

    [HttpGet("suministraron-2023")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<int>> TotalProveedoresSuministro2023()
    {
        var TotalProveedores = await unitofwork.Proveedores.TotalProveedoresSuministro2023();
        return TotalProveedores;
    }

    [HttpGet("medicamentos-menos-50-stock")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<ProveedoresDto>>> ProveedoresMenos50stockMedicamentos()
    {
        var proveedores = await unitofwork.Proveedores.ProvedorMedicamentosMenos50Stock();
        return mapper.Map<List<ProveedoresDto>>(proveedores);
    }

    [HttpGet("suministro-almenos-5-medicamentos-diferentes-2023")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<ProveedoresDto>>> ProveedoresSuministro5MedicamentosDiferentes()
    {
        var proveedores = await unitofwork.Proveedores.ProvedorSuministro5MedicamentosDiferentes2023();
        return mapper.Map<List<ProveedoresDto>>(proveedores);
    [HttpGet("proveedorMedica")] 
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<MedicamentoDto>>> GetMediProveA()
    {
        var medicamentos = await unitofwork.MovimientosInventarios.GetMedicamentosProveedorA();
        return mapper.Map<List<MedicamentoDto>>(medicamentos);
    }

    [HttpGet("GetProveeNoVenMedis")] 
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<ProveedorDto>>> GetProveNoVentas()
    {
        var proveedoresNoVenta = await unitofwork.Proveedores.GetProveNoVenMedis();
        return mapper.Map<List<ProveedorDto>>(proveedoresNoVenta);
    }

    [HttpGet("GetGananTotalProvee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<dynamic>>> GetGananTotalProvee()
    {
        var gananciaTotal = await unitofwork.Proveedores.GetGananciaXProvee();
        return gananciaTotal;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Proveedor>> Post(ProveedorDto proveedorDto)
    {
        var proveedor = this.mapper.Map<Proveedor>(proveedorDto);
        this.unitofwork.Proveedores.Add(proveedor);
        await unitofwork.SaveAsync();
        if (proveedor == null){
            return BadRequest();
        }
        proveedorDto.Id = proveedor.Id;
        return CreatedAtAction(nameof(Post), new { id = proveedorDto.Id }, proveedorDto);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<ProveedorDto>> Put (int id, [FromBody]ProveedorDto proveedorDto)
    {
        if(proveedorDto == null)
            return NotFound();

        var proveedor = this.mapper.Map<Proveedor>(proveedorDto);
        unitofwork.Proveedores.Update(proveedor);
        await unitofwork.SaveAsync();
        return proveedorDto;     
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var proveedor = await unitofwork.Proveedores.GetByIdAsync(id);

        if (proveedor == null)
        {
            return Notfound();
        }

        unitofwork.Proveedores.Remove(proveedor);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
