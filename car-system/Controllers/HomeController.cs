using Microsoft.AspNetCore.Mvc;
using car_system.Controllers.Services;
using car_system.Models.Entities;
using Microsoft.AspNetCore.Identity;
using car_system.Models;

namespace car_system.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<UserRole> _roleManager;

        public HomeController(IHomeService homeService, UserManager<Users> userManager, RoleManager<UserRole> roleManager)
        {
            _homeService = homeService;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var cars = _homeService.GetAllCars();

            // TODO: Pass the cars data to the view

            return View(cars);
        }

        public IActionResult AdminCar()
        {
            // TODO: Add the necessary logic for the admin page

            var cars = _homeService.GetAllCars();

            return View(cars);
        }

        public async Task<IActionResult> AddStaff(RegisterView model)
        {
            if (ModelState.IsValid)
            {
                var staff = new Users
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name,
                    Phone = model.PhoneNumber,
                    Address = model.Address
                };

                var result = await _userManager.CreateAsync(staff, model.Password);

                if (result.Succeeded)
                {
                    var role = "Staff"; // Assuming "Staff" is the role for staff members

                    // Check if the role exists
                    var roleExists = await _roleManager.RoleExistsAsync(role);
                    if (!roleExists)
                    {
                        // Create the role if it doesn't exist
                        var newRole = new UserRole { Name = role };
                        await _roleManager.CreateAsync(newRole);
                    }

                    // Assign the role to the staff member
                    await _userManager.AddToRoleAsync(staff, role);

                    // Redirect to the staff listing page or provide appropriate feedback
                    return RedirectToAction("AdminStaff");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                    // Registration failed
                    return View("AddStaff", model);
                }
            }

            // Invalid model state
            return View("AddStaff", model);
        }
        public IActionResult AdminStaff()
        {
            var staffMembers = _userManager.GetUsersInRoleAsync("Staff").Result.ToList();
            return View(staffMembers);
        }
    }
}