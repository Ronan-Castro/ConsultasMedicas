using ModelosConsultaMedica.Models;

namespace ConsultaMedica.Repositories.Pacientes
{
    public interface IPacienteRepository
    {
        Task AddAsync(Paciente paciente);
        Task UpdateAsync(Paciente paciente);
        Task<List<Paciente>> GetAllAsync();
        Task DeleteByIdAsync(int id);
        Task<Paciente> GetByIdAsync(int id);
    }
}
