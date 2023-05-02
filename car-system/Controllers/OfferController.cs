using car_system.Controllers.Services;
using car_system.Models;
using car_system.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace car_system.Controllers
{
    [ApiController]
    [Route("api/offer")]
    public class OfferController : Controller
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        // GET: api/offer
        [HttpGet]
        public IActionResult GetAllOffers()
        {
            var offers = _offerService.GetAllOffers();
            return Ok(offers);
        }

        // GET: api/offer/{id}
        [HttpGet("{id}")]
        public IActionResult GetOfferById(int id)
        {
            var offer = _offerService.GetOfferById(id);

            if (offer == null)
            {
                return NotFound();
            }

            return Ok(offer);
        }

        // POST: api/offer
        [HttpPost]
        public IActionResult CreateOffer([FromBody] CreateOfferView offerView)
        {
            try
            {
                _offerService.CreateOffer(offerView);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/offer/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateOffer(int id, [FromBody] Offers offer)
        {
            try
            {
                offer.OfferID = id;
                _offerService.UpdateOffer(offer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/offer/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteOffer(int id)
        {
            try
            {
                _offerService.DeleteOffer(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

