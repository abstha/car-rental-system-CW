using Microsoft.AspNetCore.Mvc;
using car_system.Controllers.Services;
using car_system.Models.Entities;
using Microsoft.AspNetCore.Identity;
using car_system.Models;
using car_system.Models.DTO;

namespace car_system.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<UserRole> _roleManager;
        private readonly IOfferService _offerService;
        private readonly ICarService _carService;
        private readonly IRentalService _rentalService;

        public HomeController(IHomeService homeService, UserManager<Users> userManager, RoleManager<UserRole> roleManager, IOfferService offerService, ICarService carService, IRentalService rentalService)
        {
            _homeService = homeService;
            _userManager = userManager;
            _roleManager = roleManager;
            _offerService = offerService;
            _carService = carService;
            _rentalService = rentalService;

        }
        public IActionResult Index()
        {
            var cars = _homeService.GetAllCars();
            var offers = _offerService.GetAllOffers();

            var viewModel = new IndexViewModel
            {
                Cars = cars,
                Offers = offers
            };

            return View(viewModel);
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

        public IActionResult AdminOffer()
        {
            // TODO: Add the necessary logic for the admin offer page

            var offers = _offerService.GetAllOffers();

            return View(offers);
        }

        [HttpGet]
        public IActionResult AddCar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(CarCreateDTO carDTO)
        {
            if (ModelState.IsValid)
            {
                await _carService.CreateCar(carDTO);
                return RedirectToAction("Index");
            }

            return View(carDTO);
        }

        [HttpGet]
        public IActionResult AdminRequests()
        {
            var rentalRequests = _rentalService.GetAllRentalRequests();
            var rentalRequestList = rentalRequests.Result; // Await the task to get the list

            // Pass the rental requests data to the view
            return View(rentalRequestList);
        }

        public async Task<IActionResult> AdminSales()
        {
            // Retrieve the RentalRequest records from the database
            var rentalRequests = await _rentalService.GetAllRentalRequests();

            // Sort the rentalRequests list by RentalDate in ascending order
            rentalRequests = rentalRequests.OrderBy(r => r.RentalDate).ToList();

            return View(rentalRequests);
        }
    }
}