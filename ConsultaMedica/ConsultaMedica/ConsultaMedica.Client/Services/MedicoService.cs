using ModelosConsultaMedica.Models;
using ModelosConsultaMedica.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace ConsultaMedica.Client.Services;

public class MedicoService : IMedicoRepository
{
    private readonly HttpClient httpClient;
    private readonly JsonSerializerOptions _options;

    public MedicoService(HttpClient httpClient)
    {
        this.httpClient = httpClient;

        _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task DeleteByIdAsync(int id)
    {
        var medico = await httpClient
            .DeleteAsync($"api/Medico/Delete-Medico/{id}");
        await medico.Content.ReadFromJsonAsync<Medico>();
    }

    public async Task<List<Medico>> GetAllAsync()
    {
        var medicos = await httpClient
            .GetAsync("api/Medico/Medicos");
        var response = await medicos.Content.ReadFromJsonAsync<List<Medico>>();
        return response!;
    }

    public async Task<Medico> GetByIdAsync(int id)
    {
        var medico = await httpClient
            .GetAsync($"api/Medico/Medico/{id}");
        var response = await medico.Content.ReadFromJsonAsync<Medico>();
        return response!;
    }

    async Task IMedicoRepository.AddAsync(Medico medico)
    {
        var produto = await httpClient
            .PostAsJsonAsync("api/Medico", medico);
        await produto.Content.ReadFromJsonAsync<Medico>();        
    }

    async Task IMedicoRepository.UpdateAsync(Medico medico)
    {
        var medico = await httpClient
            .PutAsJsonAsync("api/Medico/Update-Medico", medico);
        await medico.Content.ReadFromJsonAsync<Medico>();
    }
}
