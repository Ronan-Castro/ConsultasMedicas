using ModelosConsultaMedica.Models;
using ModelosConsultaMedica.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace ConsultaMedica.Client.Services;

public class AgendamentoService : IAgendamentoRepository
{
    private readonly HttpClient httpClient;
    private readonly JsonSerializerOptions _options;

    public AgendamentoService(HttpClient httpClient)
    {
        this.httpClient = httpClient;

        _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task DeleteByIdAsync(int id)
    {
        var agendamento = await httpClient
            .DeleteAsync($"api/Agendamento/Delete-Agendamento/{id}");
        await agendamento.Content.ReadFromJsonAsync<Agendamento>();
    }

    public async Task<List<Agendamento>> GetAllAsync()
    {
        var agendamentos = await httpClient
            .GetAsync("api/Agendamento/Agendamentos");
        var response = await agendamentos.Content.ReadFromJsonAsync<List<Agendamento>>();
        return response!;
    }

    public async Task<Agendamento> GetByIdAsync(int id)
    {
        var agendamento = await httpClient
            .GetAsync($"api/Agendamento/Agendamento/{id}");
        var response = await agendamento.Content.ReadFromJsonAsync<Agendamento>();
        return response!;
    }

    public async Task<List<AgendamentosAnuais>?> GetReportAsync()
    {
        var agendamentos = await httpClient
            .GetAsync("api/Agendamento/AgendamentosAnuais");
        var response = await agendamentos.Content.ReadFromJsonAsync<List<AgendamentosAnuais>>();
        return response!;
    }

    async Task IAgendamentoRepository.AddAsync(Agendamento agendamento)
    {
        var produto = await httpClient
            .PostAsJsonAsync("api/Agendamento", agendamento);
        await produto.Content.ReadFromJsonAsync<Agendamento>();        
    }
}
