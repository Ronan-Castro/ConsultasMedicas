using Microsoft.AspNetCore.Mvc;
using ModelosConsultaMedica.Interfaces;
using ModelosConsultaMedica.Models;

namespace ConsultaMedica.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PacienteController : ControllerBase
{
    private readonly IPacienteRepository _pacienteRepository;

    public PacienteController(IPacienteRepository pacienteRepository)
    {
        _pacienteRepository = pacienteRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Paciente>>> GetPacientes()
    {
        try
        {
            var pacientes = await _pacienteRepository.GetAllAsync();
            if (pacientes is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(pacientes);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao acessar a base de dados");
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Paciente>> GetPaciente(int id)
    {
        try
        {
            var paciente = await _pacienteRepository.GetByIdAsync(id);
            if (paciente is null)
            {
                return NotFound("Paciente não localizado");
            }
            else
            {
                return Ok(paciente);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                              "Erro ao acessar o banco de dados");
        }
    }

    [HttpPost]
    public async Task<ActionResult<IEnumerable<Paciente>>> AddPaciente(
        Paciente paciente
    )
    {
        try
        {
            await _pacienteRepository.AddAsync(paciente);
                return Ok();            
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao acessar a base de dados");
        }
    }

}