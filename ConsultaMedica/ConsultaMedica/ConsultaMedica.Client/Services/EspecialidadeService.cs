using ModelosConsultaMedica.Models;
using ModelosConsultaMedica.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace ConsultaMedica.Client.Services;

public class EspecialidadeService : IEspecialidadeRepository
{
    private readonly HttpClient httpClient;
    private readonly JsonSerializerOptions _options;

    public EspecialidadeService(HttpClient httpClient)
    {
        this.httpClient = httpClient;

        _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task DeleteByIdAsync(int id)
    {
        var especialidade = await httpClient
            .DeleteAsync($"api/Especialidade/Delete-Especialidade/{id}");
        await especialidade.Content.ReadFromJsonAsync<Especialidade>();
    }

    public async Task<List<Especialidade>> GetAllAsync()
    {
        var especialidades = await httpClient
            .GetAsync("api/Especialidade/Especialidades");
        var response = await especialidades.Content.ReadFromJsonAsync<List<Especialidade>>();
        return response!;
    }

    public async Task<Especialidade> GetByIdAsync(int id)
    {
        var especialidade = await httpClient
            .GetAsync($"api/Especialidade/Especialidade/{id}");
        var response = await especialidade.Content.ReadFromJsonAsync<Especialidade>();
        return response!;
    }

    async Task IEspecialidadeRepository.AddAsync(Especialidade especialidade)
    {
        var produto = await httpClient
            .PostAsJsonAsync("api/Especialidade", especialidade);
        await produto.Content.ReadFromJsonAsync<Especialidade>();        
    }

    async Task IEspecialidadeRepository.UpdateAsync(Especialidade especialidade)
    {
        var especialidade = await httpClient
            .PutAsJsonAsync("api/Especialidade/Update-Especialidade", especialidade);
        await especialidade.Content.ReadFromJsonAsync<Especialidade>();
    }
}
