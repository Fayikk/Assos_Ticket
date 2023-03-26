using Assos_Ticket.Shared;
using Assos_Ticket.Shared.Model;

namespace Assos_Ticket.Server.PaymentSystem
{
    public interface IPaymentService
    {
        ServiceResponse<string> Should_Create_Payment(PaymentModel model);
        string Cancel_Refund();
    }
}
