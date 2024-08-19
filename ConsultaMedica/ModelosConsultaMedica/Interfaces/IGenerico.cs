using ModelosConsultaMedica.Models;

namespace ModelosConsultaMedica.Interfaces
{
    public interface IGenerico<T>
    {
        Task<List<T>> GetAllAsync();
        Task AddAsync(T agendamento);
        Task UpdateAsync(T agendamento);
        Task DeleteByIdAsync(int id);
        Task<T?> GetByIdAsync(int id);
    }
}
