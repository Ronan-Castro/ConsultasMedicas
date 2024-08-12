using Microsoft.AspNetCore.Mvc;
using ModelosConsultaMedica.Interfaces;
using ModelosConsultaMedica.Models;

namespace ConsultaMedica.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EspecialidadeController : ControllerBase
{
    private readonly IEspecialidadeRepository _especialidadeRepository;

    public EspecialidadeController(IEspecialidadeRepository especialidadeRepository)
    {
        _especialidadeRepository = especialidadeRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Especialidade>>> GetEspecialidades()
    {
        try
        {
            var especialidades = await _especialidadeRepository.GetAllAsync();
            if (especialidades is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(especialidades);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao acessar a base de dados");
        }
    }

}