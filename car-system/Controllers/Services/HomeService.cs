using car_system.Controllers.Data;
using car_system.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace car_system.Controllers.Services
{
    public class HomeService : IHomeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<Users> _userManager;

        public HomeService(ApplicationDbContext dbContext, UserManager<Users> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public List<Cars> GetAllCars()
        {
            return _dbContext.Cars.ToList();
        }

        public async Task AddStaff(Users staff, string password)
        {
            await _userManager.CreateAsync(staff, password);
            await _userManager.AddToRoleAsync(staff, "Staff");
        }

        public List<Users> GetStaffMembers()
        {
            return _userManager.GetUsersInRoleAsync("Staff").Result.ToList();
        }
    }
}