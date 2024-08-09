using ModelosConsultaMedica.Models;

namespace ModelosConsultaMedica.Interfaces
{
    public interface IEspecialidadeRepository
    {
        Task<List<Especialidade>> GetAllAsync();
    }
}
