using Assos_Ticket.Shared;

namespace Assos_Ticket.Client.Services.ForCarService
{
    public interface ICarImageService
    {
        List<CarImage> carImages { get; set; }
        Task<List<CarImage>> GetAll();
    }
}

