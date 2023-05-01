using car_system.Models.Entities;

namespace car_system.Controllers.Services
{
    public interface IHomeService
    {
        List<Cars> GetAllCars();
    }
}
