
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace SucursalesWeb.Service
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;
        public EmpleadoService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiBaseUrl = configuration.GetValue<string>("ApiBaseUrl");

        }
        public async Task<IEnumerable<EmpleadoDto>?> GetAllAsync()
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/empleado");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<EmpleadoDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            return Enumerable.Empty<EmpleadoDto>();
        }

        public async Task<bool> AddAsync(Empleado empleado)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_apiBaseUrl}/empleado", empleado);
            return response.IsSuccessStatusCode;
        }
    }
}