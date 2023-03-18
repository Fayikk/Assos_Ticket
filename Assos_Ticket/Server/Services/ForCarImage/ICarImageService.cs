using Assos_Ticket.Shared;

namespace Assos_Ticket.Server.Services.ForCarImage
{
    public interface ICarImageService
    {
        CarImage Add(IFormFile file,int carId);
        CarImage AddPlane(IFormFile file, int planeId);
        CarImage AddBus(IFormFile file, int busId);
        Task<ServiceResponse<FileStream>> GetImageByGuid(int id);
        List<CarImage> GetAll();
    }
}
