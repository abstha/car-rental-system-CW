using car_system.Controllers.Services;
using Microsoft.AspNetCore.Mvc;

namespace car_system.Controllers
{
    public class OfferController : Controller
    {
        private readonly IOfferService _offerService;
        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }
        public IActionResult Index()
        {
            return View();
        }


    }
}
