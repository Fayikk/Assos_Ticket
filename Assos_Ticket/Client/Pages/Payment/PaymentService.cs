using Assos_Ticket.Shared;
using Assos_Ticket.Shared.Model;
using System.Net.Http.Json;

namespace Assos_Ticket.Client.Pages.Payment
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;
        public PaymentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse<string>>  Checkout(PaymentModel model)
        {
            var result = await _httpClient.PostAsJsonAsync("api/PaymentConttroller",model);
            
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();


        }
    }
}
