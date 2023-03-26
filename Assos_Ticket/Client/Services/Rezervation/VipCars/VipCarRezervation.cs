using Assos_Ticket.Shared;
using System.Net.Http.Json;

namespace Assos_Ticket.Client.Services.Rezervation.VipCars
{
    public class VipCarRezervation : IVipCarRezervation
    {
        private readonly HttpClient _httpClient;
        public VipCarRezervation(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<RezerveVipCar> rezerveVipCars { get; set; } = new List<RezerveVipCar>();

        public async Task<ServiceResponse<string>> CreateRezervation(int id)
        {
          var result = await _httpClient.PostAsync($"api/VipCarRezerve/{id}",null);
            //var trying = result;
          return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

		public async Task GetMyRezerveList()
		{
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<RezerveVipCar>>>("api/VipCarRezerve");
            if (result != null && result.Data != null)
            {
                rezerveVipCars = result.Data;
            }

		}
	}
}
