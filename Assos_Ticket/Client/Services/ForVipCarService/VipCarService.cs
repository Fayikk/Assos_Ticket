using Assos_Ticket.Shared;
using System.Net.Http.Json;

namespace Assos_Ticket.Client.Services.ForVipCarService
{
    public class VipCarService : IVipCarService
    {
        private readonly HttpClient _httpClient;
        public VipCarService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<VipCar> vipCars { get ; set ; }

        public async Task GetVipCars()
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<VipCar>>>("api/vipcar/getall");
            if (result != null && result.Data != null)
            {
                vipCars = result.Data;
            }
        }
    }
}
