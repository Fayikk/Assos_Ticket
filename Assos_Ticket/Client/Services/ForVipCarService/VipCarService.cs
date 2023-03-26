using Assos_Ticket.Shared;
using Assos_Ticket.Shared.DTO;
using Assos_Ticket.Shared.Model;
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

        public List<VipCar> vipCars { get ; set ; } = new List<VipCar>();
        public List<FilterForVipCar> filterForVipCars { get ; set ; }

        //public VipCarDTO vipCar { get; set; } = new VipCarDTO();
        VipCarDTO vipCar = new VipCarDTO();

		public async Task<VipCarDTO> GetVipCar(int id)
		{
          var result =  await _httpClient.GetFromJsonAsync<ServiceResponse<VipCarDTO>>($"api/VipCar/getbyId/{id}");
            if (result != null && result.Data != null)
            {
                vipCar = result.Data;
            }
            return vipCar;
           
		}

		public async Task GetVipCars()
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<VipCar>>>("api/vipcar/getall");
            if (result != null && result.Data != null)
            {
                vipCars = result.Data;
            }
        }

        public async Task<ServiceResponse<List<VipCar>>> FilterVipCars(FilterForVipCar vipCar)
        {
            var result = await _httpClient.PostAsJsonAsync("api/vipcar/forFilter", vipCar);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<List<VipCar>>>();

        }





        //[HttpPost("forFilter")]

        //public async Task<ActionResult<ServiceResponse<List<VipCar>>>> FilterByCar(FilterForVipCar car, bool status)
        //{
        //    var result = await _vipCarService.GetFilterByVipCar(car, status);
        //    return Ok(result);
        //}





    }
    //[HttpGet("{id}")]
    //public async Task<ActionResult<ServiceResponse<VipCarDTO>>> GetCarById([FromRoute] int id)
    //{
    //	var result = await _vipCarService.GetByCar(id);
    //	return Ok(result);
    //}
}
