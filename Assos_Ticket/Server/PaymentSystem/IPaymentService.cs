using Assos_Ticket.Shared;

namespace Assos_Ticket.Server.PaymentSystem
{
    public interface IPaymentService
    {
        ServiceResponse<string> Should_Create_Payment();
        string Cancel_Refund();
    }
}
