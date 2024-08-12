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
        var paciente = await httpClient
            .DeleteAsync($"api/Paciente/DeletePaciente/{id}");
        await paciente.Content.ReadFromJsonAsync<Paciente>();
    }

    public async Task<List<Paciente>> GetAllAsync()
    {
        var pacientes = await httpClient
            .GetAsync("api/Paciente/Pacientes");
        var response = await pacientes.Content.ReadFromJsonAsync<List<Paciente>>();
        return response!;
    }

    public async Task<Paciente> GetByIdAsync(int id)
    {
        var paciente = await httpClient
            .GetAsync($"api/Paciente/Paciente/{id}");
        var response = await paciente.Content.ReadFromJsonAsync<Paciente>();
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
        var retorno = await httpClient
            .PutAsJsonAsync("api/Paciente/UpdatePaciente", paciente);
        await retorno.Content.ReadFromJsonAsync<Paciente>();
    }
}
