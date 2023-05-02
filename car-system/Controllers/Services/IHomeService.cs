using car_system.Models.DTO;
using car_system.Models.Entities;

namespace car_system.Controllers.Services
{
    public interface IHomeService
    {
        List<Cars> GetAllCars();
        Task AddStaff(Users staff, string password);
        List<Users> GetStaffMembers();

        Task CreateCar(CarCreateDTO carDTO);
    }
}
