using Assos_Ticket.Shared;
using System.Net.Http.Json;

namespace Assos_Ticket.Client.Services.ForPlaneService
{
    public class PlaneService : IPlaneService
    {
        private readonly HttpClient _httpClient;
        public PlaneService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<PlaneExpedition> planeExpeditions { get ; set; } = new List<PlaneExpedition>();

        public async Task GetPlaneList()
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<PlaneExpedition>>>("api/plane/getall");
            if (result != null && result.Data != null)
            {
                planeExpeditions = result.Data;
            }
        }
    }
}
