using Assos_Ticket.Shared;
using Assos_Ticket.Shared.Model;

namespace Assos_Ticket.Client.Pages.Payment
{
    public interface IPaymentService
    {
        Task<ServiceResponse<string>> Checkout(PaymentModel model);
    }
}
