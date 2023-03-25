using Assos_Ticket.Shared.Model;
using Assos_Ticket.Shared;

namespace Assos_Ticket.Client.Services.ForAuthServices
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(UserRegister request);
        Task<ServiceResponse<string>> Login(UserLogin user);
        //Task<ServiceResponse<bool>> ChangePassword(UserChangePassword changePassword);
        Task<bool> IsUserAuthenticated();
    }
}
