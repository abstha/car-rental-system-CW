using car_system.Controllers.Data;
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

        public async Task<RentalRequest> CreateRentalRequest(string userId, int carId, DateTime rentalDate)
        {
            var rentalRequest = new RentalRequest
            {
                UserId = userId,
                CarRented = carId,
                RentalDate = rentalDate,
                RentalStatus = "Pending"
            };

            _dbContext.RentalRequests.Add(rentalRequest);
            await _dbContext.SaveChangesAsync();

            return rentalRequest;
        }

        public async Task<RentalRequest> GetRentalRequestById(int rentalId)
        {
            return await _dbContext.RentalRequests.FindAsync(rentalId);
        }

        public async Task<List<RentalRequest>> GetAllRentalRequests()
        {
            return await _dbContext.RentalRequests.ToListAsync();
        }

        public async Task<List<RentalRequest>> GetRentalRequestsByUserId(string userId)
        {
            return await _dbContext.RentalRequests.Where(r => r.UserId == userId).ToListAsync();
        }

        public async Task<List<RentalRequest>> GetRentalRequestsByCarId(int carId)
        {
            return await _dbContext.RentalRequests.Where(r => r.CarRented == carId).ToListAsync();
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
    }
}
