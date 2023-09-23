using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using ApiFarmacia.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiFarmacia.Controllers;

public class RecetaController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public RecetaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<RecetaMedica>>> Get()
    {
        var receta = await unitofwork.Recetas.GetAllAsync();
        return mapper.Map<List<RecetaMedica>>(receta);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RecetaMedica>> Get(int id)
    {
        var recetas = await unitofwork.Recetas.GetByIdAsync(id);
        return mapper.Map<RecetaMedica>(recetas);
    }

    [HttpGet("GetRecetas2023")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<RecetaMedica>>> GetRecetas2023()
    {
        var receta = await unitofwork.Recetas.Get2023Recetas();
        return mapper.Map<List<RecetaMedica>>(receta);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RecetaMedica>> Post(RecetaMedica recetaa)
    {
        var receta = this.mapper.Map<RecetaMedica>(recetaa);
        this.unitofwork.Recetas.Add(receta);
        await unitofwork.SaveAsync();
        if (receta == null){
            return BadRequest();
        }
        recetaa.Id = receta.Id;
        return CreatedAtAction(nameof(Post), new { id = recetaa.Id }, recetaa);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<RecetaMedica>> Put (int id, [FromBody]RecetaMedica recetaa)
    {
        if(recetaa == null)
            return NotFound();

        var receta = this.mapper.Map<RecetaMedica>(recetaa);
        unitofwork.Recetas.Update(receta);
        await unitofwork.SaveAsync();
        return recetaa;     
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var receta = await unitofwork.Recetas.GetByIdAsync(id);

        if (receta == null)
        {
            return Notfound();
        }

        unitofwork.Recetas.Remove(receta);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}