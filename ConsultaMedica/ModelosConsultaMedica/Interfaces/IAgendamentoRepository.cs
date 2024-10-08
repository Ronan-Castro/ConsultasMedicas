﻿using ModelosConsultaMedica.Models;

namespace ModelosConsultaMedica.Interfaces
{
    public interface IAgendamentoRepository
    {
        Task<List<Agendamento>> GetAllAsync();
        Task AddAsync(Agendamento agendamento);
        Task UpdateAsync(Agendamento agendamento);
        Task DeleteByIdAsync(int id);
        Task<Agendamento?> GetByIdAsync(int id);
        Task<List<AgendamentosAnuais>?> GetReportAsync();
    }
}
