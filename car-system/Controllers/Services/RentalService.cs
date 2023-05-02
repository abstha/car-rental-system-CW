using car_system.Controllers.Data;
using car_system.Models.DTO;
using car_system.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace car_system.Controllers.Services
{
    public class RentalService : IRentalService
    {
        private readonly ApplicationDbContext _dbContext;

        public RentalService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RentalRequestDTO> CreateRentalRequest(RentalRequestDTO rentalRequestDTO)
        {
            var rentalRequest = new RentalRequest
            {
                UserId = rentalRequestDTO.UserId,
                CarRented = rentalRequestDTO.CarRented,
                RentalDate = rentalRequestDTO.RentalDate,
                RentalStatus = "Pending",
                IsApproved = rentalRequestDTO.IsApproved,
                ApprovedByStaffId = rentalRequestDTO.ApprovedByStaffId
            };

            _dbContext.RentalRequests.Add(rentalRequest);
            await _dbContext.SaveChangesAsync();

            return MapToDTO(rentalRequest);
        }

        public async Task<RentalRequestDTO> GetRentalRequestById(int rentalId)
        {
            var rentalRequest = await _dbContext.RentalRequests.FindAsync(rentalId);

            return rentalRequest != null ? MapToDTO(rentalRequest) : null;
        }

        public async Task<List<RentalRequestDTO>> GetAllRentalRequests()
        {
            var rentalRequests = await _dbContext.RentalRequests.ToListAsync();

            return rentalRequests.Select(r => MapToDTO(r)).ToList();
        }

        public async Task<List<RentalRequestDTO>> GetRentalRequestsByUserId(string userId)
        {
            var rentalRequests = await _dbContext.RentalRequests.Where(r => r.UserId == userId).ToListAsync();

            return rentalRequests.Select(r => MapToDTO(r)).ToList();
        }

        public async Task<List<RentalRequestDTO>> GetRentalRequestsByCarId(int carId)
        {
            var rentalRequests = await _dbContext.RentalRequests.Where(r => r.CarRented == carId).ToListAsync();

            return rentalRequests.Select(r => MapToDTO(r)).ToList();
        }

        public async Task<bool> UpdateRentalRequestStatus(int rentalId, string status)
        {
            var rentalRequest = await _dbContext.RentalRequests.FindAsync(rentalId);

            if (rentalRequest == null)
                return false;

            rentalRequest.RentalStatus = status;
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteRentalRequest(int rentalId)
        {
            var rentalRequest = await _dbContext.RentalRequests.FindAsync(rentalId);

            if (rentalRequest == null)
                return false;

            _dbContext.RentalRequests.Remove(rentalRequest);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        private RentalRequestDTO MapToDTO(RentalRequest rentalRequest)
        {
            return new RentalRequestDTO
            {
                RentalId = rentalRequest.RentalId,
                UserId = rentalRequest.UserId,
                CarRented = rentalRequest.CarRented,
                RentalDate = rentalRequest.RentalDate,
                RentalStatus = rentalRequest.RentalStatus,
                IsApproved = rentalRequest.IsApproved,
                ApprovedByStaffId = rentalRequest.ApprovedByStaffId
            };
        }

    }
}