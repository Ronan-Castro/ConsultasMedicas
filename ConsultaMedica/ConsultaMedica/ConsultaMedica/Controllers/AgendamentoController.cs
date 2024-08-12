using ConsultaMedica.Repositories.Agendamentos;
using Microsoft.AspNetCore.Mvc;
using ModelosConsultaMedica.Interfaces;
using ModelosConsultaMedica.Models;

namespace ConsultaMedica.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AgendamentoController : ControllerBase
{
    private readonly IAgendamentoRepository _agendamentoRepository;

    public AgendamentoController(IAgendamentoRepository agendamentoRepository)
    {
        _agendamentoRepository = agendamentoRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Agendamento>>> GetAgendamentos()
    {
        try
        {
            var agendamentos = await _agendamentoRepository.GetAllAsync();
            if (agendamentos is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(agendamentos);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao acessar a base de dados");
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Agendamento>> GetAgendamento(int id)
    {
        try
        {
            var agendamento = await _agendamentoRepository.GetByIdAsync(id);
            if (agendamento is null)
            {
                return NotFound("Agendamento não localizado");
            }
            else
            {
                return Ok(agendamento);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                              "Erro ao acessar o banco de dados");
        }
    }

    [HttpPost]
    public async Task<ActionResult<IEnumerable<Agendamento>>> AddAgendamento(
        Agendamento agendamento
    )
    {
        try
        {
            await _agendamentoRepository.AddAsync(agendamento);
                return Ok();            
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao acessar a base de dados");
        }
    }

    [HttpPut]
    public async Task<ActionResult<IEnumerable<Agendamento>>> UpdateAgendamento(
        Agendamento agendamento
    )
    {
        try
        {
            await _agendamentoRepository.UpdateAsync(agendamento);
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao acessar a base de dados");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<IEnumerable<Agendamento>>> DeleteAgendamento(int id)
    {
        try
        {
            await _agendamentoRepository.DeleteByIdAsync(id);
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao acessar a base de dados");
        }
    }

}