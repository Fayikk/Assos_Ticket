using Assos_Ticket.Shared;
using System.Net.Http.Json;

namespace Assos_Ticket.Client.Services.ForBusService
{
    public class BusService : IBusService
    {
        private readonly HttpClient _http;
        public BusService(HttpClient http)
        {
            _http = http;
        }

        public List<BusExpedition> busExpeditions { get; set; } = new List<BusExpedition>();

        public async Task GetAllBusExpedition()
        {
           var result = await _http.GetFromJsonAsync<ServiceResponse<List<BusExpedition>>>("api/bus/GetAll");
            if (result != null && result.Data != null)
            {
                busExpeditions = result.Data;
            }

        }
    }
}
