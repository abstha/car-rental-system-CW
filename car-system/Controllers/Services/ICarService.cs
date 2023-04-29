using car_system.Models.Entities;

namespace car_system.Controllers.Services
{
    public interface ICarService
    {
        Task<List<Cars>> GetAllCars();
        Task<Cars> GetCarById(int carId);
        Task CreateCar(Cars car);
        Task UpdateCar(Cars car);
        Task DeleteCar(int carId);
        Task<List<Cars>> SearchCars(string searchTerm);
    }
}
