using car_system.Controllers.Services;
using car_system.Models;
using car_system.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace car_system.Controllers
{
    [ApiController]
    [Route("api/damages")] // Route prefix for all actions in the controller
    public class DamageController : Controller
    {
        private readonly IDamageService _damageService;

        public DamageController(IDamageService damageService)
        {
            _damageService = damageService;
        }

        // GET: api/damages
        [HttpGet]

        public IActionResult GetAllDamages()
        {
            var damages = _damageService.GetAllDamages();
            return View(damages);
        }

        // GET: api/damages/5
        [HttpGet("{id}")]
      
        public IActionResult GetDamageById(int id)
        {
            var damage = _damageService.GetDamageById(id);

            if (damage == null)
            {
                return NotFound();
            }

            return View(damage);
        }

        // POST: api/damages
        [HttpPost]

        public IActionResult CreateDamage(DamageView damage)
        {
            if (ModelState.IsValid)
            {
                // Map the DamageView to the Damage entity and pass it to the service
                var damageEntity = new Damages
                {
                    UserID = damage.UserID,
                    VerifiedBy = damage.VerifiedBy,
                    CarID = damage.CarId,
                    Amount = damage.Amount
                };

                _damageService.CreateDamage(damageEntity);
                return RedirectToAction(nameof(Index));
            }

            return View(damage);
        }

        // PUT: api/damages/5
        [HttpPut("{id}")]

        public IActionResult UpdateDamage(int id, DamageView damage)
        {
            if (id != damage.DamageID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Map the DamageView to the Damage entity and pass it to the service
                var damageEntity = new Damages
                {
                    DamageID = id,
                    UserID = damage.UserID,
                    VerifiedBy = damage.VerifiedBy,
                    CarID = damage.CarId,
                    Amount = damage.Amount
                };

                _damageService.UpdateDamage(damageEntity);
                return RedirectToAction(nameof(Index));
            }

            return View(damage);
        }

        // DELETE: api/damages/5
        [HttpDelete("{id}")]

        public IActionResult DeleteDamage(int id)
        {
            var damage = _damageService.GetDamageById(id);

            if (damage == null)
            {
                return NotFound();
            }

            _damageService.DeleteDamage(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
