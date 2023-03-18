using Assos_Ticket.Server.Context;
using Assos_Ticket.Server.Helper;
using Assos_Ticket.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Assos_Ticket.Server.Services.ForCarImage
{
    public class CarImageService : ICarImageService
    {
        IFileService _fileHelper;
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _env;
        public CarImageService(IFileService fileHelper, DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _fileHelper = fileHelper;
            _env = env;
        }
        public CarImage Add(IFormFile file,int carId )
        {
            var forCar = _context.VipCars.FirstOrDefault(x => x.CarId == carId);
            CarImage carImage = new CarImage(); 
            string ImagesPath = "wwwroot\\images\\";
           
            carImage.ImagePath = _fileHelper.Upload(file, ImagesPath);
            carImage.Date = DateTime.Now;
            carImage.VipCarId=carId;
            carImage.ImageUrl = $"/images/{carImage.ImagePath}";
            forCar.ImageUrl = carImage.ImageUrl;
            _context.CarImages.Add(carImage);
            _context.VipCars.Update(forCar);
            _context.SaveChanges();

            return carImage;
        }

        public async Task<ServiceResponse<FileStream>> GetImageByGuid(int id)
        {
            var carImage = await _context.CarImages.FirstOrDefaultAsync(x => x.VipCarId == id);
            if (carImage == null)
            {
                return new ServiceResponse<FileStream>
                {
                    Success = false,
                    Message = "Image not found."
                };
            }

            var imageFilePath = Path.Combine(_env.WebRootPath, "images", carImage.ImagePath);
            if (!File.Exists(imageFilePath))
            {
                return new ServiceResponse<FileStream>
                {
                    Success = false,
                    Message = "Image file not found."
                };
            }

            var stream = new FileStream(imageFilePath, FileMode.Open);
            return new ServiceResponse<FileStream>
            {
                Success = true,
                Data = stream
            };
        }

        public List<CarImage> GetAll()
        {
            var cars = _context.CarImages.ToList();

            foreach (var car in cars)
            {
                car.ImageUrl = $"/images/{car.ImagePath}";
            }

            return cars;
        }

        public  CarImage AddPlane(IFormFile file, int planeId)
        {
            var forPlane =  _context.Planes.FirstOrDefault(x => x.PlaneId == planeId);
            CarImage carImage = new CarImage();
            string ImagesPath = "wwwroot\\images\\";

            carImage.ImagePath = _fileHelper.Upload(file, ImagesPath);
            carImage.Date = DateTime.Now;
            carImage.PlaneId = planeId;
            carImage.ImageUrl = $"/images/{carImage.ImagePath}";
            forPlane.ImageUrl = carImage.ImageUrl;
            _context.CarImages.Add(carImage);
            _context.Planes.Update(forPlane);
            _context.SaveChanges();

            return carImage;
        }

        public CarImage AddBus(IFormFile file, int busId)
        {
            var forBus = _context.Busses.FirstOrDefault(x => x.BusId == busId);
            CarImage carImage = new CarImage();
            string ImagesPath = "wwwroot\\images\\";

            carImage.ImagePath = _fileHelper.Upload(file, ImagesPath);
            carImage.Date = DateTime.Now;
            carImage.BusId = busId;
            carImage.ImageUrl = $"/images/{carImage.ImagePath}";
            forBus.ImageUrl = carImage.ImageUrl;
            _context.CarImages.Add(carImage);
            _context.Busses.Update(forBus);
            _context.SaveChanges();

            return carImage;
        }
    }
}
