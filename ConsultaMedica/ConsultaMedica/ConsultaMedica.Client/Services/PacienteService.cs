using ModelosConsultaMedica.Models;
using ModelosConsultaMedica.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace ConsultaMedica.Client.Services;

public class PacienteService : IPacienteRepository
{
    private readonly HttpClient httpClient;
    private readonly JsonSerializerOptions _options;

    public PacienteService(HttpClient httpClient)
    {
        this.httpClient = httpClient;

        _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task DeleteByIdAsync(int id)
    {
        var grupo = await httpClient
            .DeleteAsync($"api/Paciente/Delete-Paciente/{id}");
        await grupo.Content.ReadFromJsonAsync<Paciente>();
    }

    public async Task<List<Paciente>> GetAllAsync()
    {
        var grupos = await httpClient
            .GetAsync("api/Paciente/Pacientes");
        var response = await grupos.Content.ReadFromJsonAsync<List<Paciente>>();
        return response!;
    }

    public async Task<Paciente> GetByIdAsync(int id)
    {
        var grupo = await httpClient
            .GetAsync($"api/Paciente/Paciente/{id}");
        var response = await grupo.Content.ReadFromJsonAsync<Paciente>();
        return response!;
    }

    async Task IPacienteRepository.AddAsync(Paciente paciente)
    {
        var produto = await httpClient
            .PostAsJsonAsync("api/Paciente", paciente);
        await produto.Content.ReadFromJsonAsync<Paciente>();        
    }

    async Task IPacienteRepository.UpdateAsync(Paciente paciente)
    {
        var grupo = await httpClient
            .PutAsJsonAsync("api/Paciente/Update-Paciente", paciente);
        await grupo.Content.ReadFromJsonAsync<Paciente>();
    }
}
