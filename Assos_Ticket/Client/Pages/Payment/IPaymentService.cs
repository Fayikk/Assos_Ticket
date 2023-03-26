using Assos_Ticket.Shared;

namespace Assos_Ticket.Client.Pages.Payment
{
    public interface IPaymentService
    {
        Task<ServiceResponse<string>> Checkout();
    }
}
