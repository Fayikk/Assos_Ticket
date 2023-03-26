using Assos_Ticket.Shared;
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

        public async Task  Checkout()
        {
            var result = _httpClient.PostAsJsonAsync<string>("api/PaymentConttroller", null);

        }
    }
}
