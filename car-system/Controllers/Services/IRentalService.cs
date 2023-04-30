using car_system.Models.DTO;
using car_system.Models.Entities;

namespace car_system.Controllers.Services
{
    public interface IRentalService
    {
        Task<RentalRequestDTO> CreateRentalRequest(string userId, int carId, DateTime rentalDate);
        Task<RentalRequestDTO> GetRentalRequestById(int rentalId);
        Task<List<RentalRequestDTO>> GetAllRentalRequests();
        Task<List<RentalRequestDTO>> GetRentalRequestsByUserId(string userId);
        Task<List<RentalRequestDTO>> GetRentalRequestsByCarId(int carId);
        Task<bool> UpdateRentalRequestStatus(int rentalId, string status);
        Task<bool> DeleteRentalRequest(int rentalId);
    }
}