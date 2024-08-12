using ConsultaMedica.Repositories.Medicos;
using Microsoft.AspNetCore.Mvc;
using ModelosConsultaMedica.Interfaces;
using ModelosConsultaMedica.Models;

namespace ConsultaMedica.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MedicoController : ControllerBase
{
    private readonly IMedicoRepository _medicoRepository;

    public MedicoController(IMedicoRepository medicoRepository)
    {
        _medicoRepository = medicoRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Medico>>> GetMedicos()
    {
        try
        {
            var medicos = await _medicoRepository.GetAllAsync();
            if (medicos is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(medicos);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao acessar a base de dados");
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Medico>> GetMedico(int id)
    {
        try
        {
            var medico = await _medicoRepository.GetByIdAsync(id);
            if (medico is null)
            {
                return NotFound("Medico não localizado");
            }
            else
            {
                return Ok(medico);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                              "Erro ao acessar o banco de dados");
        }
    }

    [HttpPost]
    public async Task<ActionResult<IEnumerable<Medico>>> AddMedico(
        Medico medico
    )
    {
        try
        {
            await _medicoRepository.AddAsync(medico);
                return Ok();            
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao acessar a base de dados");
        }
    }

    [HttpPut]
    public async Task<ActionResult<IEnumerable<Medico>>> UpdateMedico(
        Medico medico
    )
    {
        try
        {
            await _medicoRepository.UpdateAsync(medico);
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao acessar a base de dados");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<IEnumerable<Medico>>> DeleteMedico(int id)
    {
        try
        {
            await _medicoRepository.DeleteByIdAsync(id);
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao acessar a base de dados");
        }
    }

}