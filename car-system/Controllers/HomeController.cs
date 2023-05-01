using Microsoft.AspNetCore.Mvc;
using car_system.Controllers.Services;

namespace car_system.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public IActionResult Index()
        {
            var cars = _homeService.GetAllCars();

            // TODO: Pass the cars data to the view

            return View(cars);
        }

        public IActionResult AdminPage()
        {
            // TODO: Add the necessary logic for the admin page

            var cars = _homeService.GetAllCars();

            return View(cars);
        }
    }
}