using Assos_Ticket.Shared;

namespace Assos_Ticket.Server.Services.ForAuth
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<bool> UserExists(string email);
        Task<ServiceResponse<string>> Login(string email, string password);
        Task<ServiceResponse<bool>> ChangePassword(int userId, string oldPassword, string newPassword, string ConfirmPassword);
        int GetUserId();
        string GetUserEmail();
        Task<User> GetUserByEmail(string email);
        Task<ServiceResponse<bool>> RoleForAdmin(string email);
        Task<ServiceResponse<bool>> DeleteAccount(string password);
    }
}
