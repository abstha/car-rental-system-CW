using car_system.Controllers.Services;
using car_system.Models;
using car_system.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace car_system.Controllers
{
    [ApiController]
    [Route("api/offers")]
    public class OfferController : Controller
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        // GET: api/offers
        [HttpGet]
        public IActionResult Index()
        {
            var offers = _offerService.GetAllOffers();
            return View(offers);
        }

        // GET: api/offers/{id}
        [HttpGet("{id}")]


        public IActionResult Details(int id)
        {
            var offer = _offerService.GetOfferById(id);

            if (offer == null)
            {
                return NotFound();
            }

            return View(offer);
        }

        // GET: api/offers/create
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: api/offers
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AddOfferView offerView)
        {
            if (ModelState.IsValid)
            {
                _offerService.CreateOffer(offerView);
                return RedirectToAction(nameof(Index));
            }

            return View(offerView);
        }

        // GET: api/offers/edit/{id}
        [HttpGet("edit/{id}")]


        public IActionResult Edit(int id)
        {
            var offer = _offerService.GetOfferById(id);

            if (offer == null)
            {
                return NotFound();
            }

            return View(offer);
        }

        // POST: api/offers/edit/{id}
        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
       

        public IActionResult Edit(int id, Offers offer)
        {
            if (id != offer.OfferID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _offerService.UpdateOffer(offer);
                return RedirectToAction(nameof(Index));
            }

            return View(offer);
        }

        // GET: api/offers/delete/{id}
        [HttpGet("delete/{id}")]
 

        public IActionResult Delete(int id)
        {
            var offer = _offerService.GetOfferById(id);

            if (offer == null)
            {
                return NotFound();
            }

            return View(offer);
        }

        // POST: api/offers/delete/{id}
        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken]
       

        public IActionResult DeleteConfirmed(int id)
        {
            _offerService.DeleteOffer(id);
            return RedirectToAction(nameof(Index));
        }

    }
}

