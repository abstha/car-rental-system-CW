using car_system.Controllers.Services;
using car_system.Models.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace car_system.Controllers
{
    [EnableCors]
    public class CarController : Controller
    {

        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<IActionResult> Index()
        {
            var cars = await _carService.GetAllCars();
            return View(cars);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("/api/Cars/Create")]
        public async Task<IActionResult> Create(Cars car)
        {
            if (ModelState.IsValid)
            {
                await _carService.CreateCar(car);
                return RedirectToAction("Index");
            }

            return View(car);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var car = await _carService.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        [HttpPost]
        [Route("/api/Cars/Edit")]
        public async Task<IActionResult> Edit(int id, Cars car)
        {
            if (id != car.CarId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _carService.UpdateCar(car);
                }
                catch (Exception)
                {
                    return NotFound();
                }

                return RedirectToAction("Index");
            }

            return View(car);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var car = await _carService.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        [HttpPost]
        [Route("/api/Cars/DeleteConfirmed/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _carService.DeleteCar(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Search(string searchTerm)
        {
            var cars = await _carService.SearchCars(searchTerm);
            return View(cars);
        }
    }
}
