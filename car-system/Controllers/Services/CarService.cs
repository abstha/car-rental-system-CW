using car_system.Controllers.Data;
using car_system.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace car_system.Controllers.Services
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext _context;
        public CarService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateCar(Cars car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCar(int CarId)
        {
            var car = await _context.Cars.FindAsync(CarId);
            if (car != null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Cars>> GetAllCars()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Cars> GetCarById(int CarId)
        {
            return await _context.Cars.FindAsync(CarId);
        }

        public Task<List<Cars>> SearchCars(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateCar(Cars car)
        {
            var existingCar = await _context.Cars.FindAsync(car.CarId);

            if (existingCar == null)
            {
                throw new ArgumentException("Car not found");
            }

            // Update the properties of the existing car entity
            existingCar.Condition = car.Condition;
            existingCar.Model = car.Model;
            existingCar.Availability = car.Availability;
            // Update other properties as needed

            _context.Cars.Update(existingCar);
            await _context.SaveChangesAsync();
        }
    }
}
