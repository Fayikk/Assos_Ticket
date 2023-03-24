using Assos_Ticket.Shared;
using System.Net.Http.Json;

namespace Assos_Ticket.Client.Services.ForCarService
{
    public class CarImageService : ICarImageService
    {
        private readonly HttpClient _httpClient;
        public CarImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<CarImage> carImages { get; set; }

        public async Task<List<CarImage>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<CarImage>>("api/CarImage");

        }
    }
}
