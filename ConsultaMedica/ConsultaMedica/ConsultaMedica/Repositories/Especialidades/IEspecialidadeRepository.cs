using ConsultaMedica.Models;

namespace ConsultaMedica.Repositories.Especialidades
{
    public interface IEspecialidadeRepository
    {
        Task<List<Especialidade>> GetAllAsync();
    }
}
