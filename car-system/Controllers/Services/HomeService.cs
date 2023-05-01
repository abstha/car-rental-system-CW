using car_system.Controllers.Data;
using car_system.Models.Entities;

namespace car_system.Controllers.Services
{
    public class HomeService : IHomeService
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Cars> GetAllCars()
        {
            return _dbContext.Cars.ToList();
        }
    }
}
