using car_system.Models.Entities;

namespace car_system.Controllers.Services
{
    public interface IRentalService
    {
        Task<RentalRequest> CreateRentalRequest(string userId, int carId, DateTime rentalDate);
        Task<RentalRequest> GetRentalRequestById(int rentalId);
        Task<List<RentalRequest>> GetAllRentalRequests();
        Task<List<RentalRequest>> GetRentalRequestsByUserId(string userId);
        Task<List<RentalRequest>> GetRentalRequestsByCarId(int carId);
        Task<bool> UpdateRentalRequestStatus(int rentalId, string status);
        Task<bool> DeleteRentalRequest(int rentalId);
    }
}
