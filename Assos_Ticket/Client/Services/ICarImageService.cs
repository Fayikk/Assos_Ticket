using Assos_Ticket.Shared;

namespace Assos_Ticket.Client.Services
{
    public interface ICarImageService
    {
        List<CarImage> carImages { get; set; }
        Task<List<CarImage>> GetAll();
    }
}

