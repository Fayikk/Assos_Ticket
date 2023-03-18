namespace Assos_Ticket.Server.Helper
{
    public interface IFileService
    {
        string Upload(IFormFile file, string root);
        void Delete(string root);
        string Update(IFormFile file, string filePath, string root);
    }
}
