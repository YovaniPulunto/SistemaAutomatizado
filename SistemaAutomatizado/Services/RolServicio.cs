using System.Net.Http.Json;
using SistemaAutomatizado.Models;

namespace SistemaAutomatizado.Services;

public class RolServicio
{
    private readonly HttpClient _http;

    public RolServicio(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<RolSalida>> ObtenerTodos()
    {
        var respuesta = await _http.GetAsync("api/Roles/lista");
        if (!respuesta.IsSuccessStatusCode)
            return new List<RolSalida>();

        return await respuesta.Content.ReadFromJsonAsync<List<RolSalida>>() ?? new List<RolSalida>();
    }

    public async Task<RolSalida?> Crear(RolGuardar rol)
    {
        var respuesta = await _http.PostAsJsonAsync("api/Roles", rol);
        return await respuesta.Content.ReadFromJsonAsync<RolSalida>();
    }

    public async Task<RolSalida?> Modificar(RolSalida rol)
    {
        var respuesta = await _http.PutAsJsonAsync($"api/Roles/{rol.IdRol}", rol);
        return await respuesta.Content.ReadFromJsonAsync<RolSalida>();
    }

    public async Task Eliminar(int id)
    {
        await _http.DeleteAsync($"api/Roles/{id}");
    }
}