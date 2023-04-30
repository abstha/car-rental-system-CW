using car_system.Controllers.Services;
using car_system.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace car_system.Controllers
{
    [ApiController]
    [Route("api/rentals")]
    public class RentalController : Controller
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost]
    
        public async Task<IActionResult> CreateRentalRequest([FromBody] RentalRequest rentalRequest)
        {
            try
            {
                var createdRentalRequest = await _rentalService.CreateRentalRequest(rentalRequest.UserId, rentalRequest.CarRented, rentalRequest.RentalDate);
                return Ok(createdRentalRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{rentalId}")]
     
        public async Task<IActionResult> GetRentalRequestById(int rentalId)
        {
            try
            {
                var rentalRequest = await _rentalService.GetRentalRequestById(rentalId);
                if (rentalRequest == null)
                    return NotFound();

                return Ok(rentalRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
     

        public async Task<IActionResult> GetAllRentalRequests()
        {
            try
            {
                var rentalRequests = await _rentalService.GetAllRentalRequests();
                return Ok(rentalRequests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("user/{userId}")]
       

        public async Task<IActionResult> GetRentalRequestsByUserId(string userId)
        {
            try
            {
                var rentalRequests = await _rentalService.GetRentalRequestsByUserId(userId);
                return Ok(rentalRequests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("car/{carId}")]
    

        public async Task<IActionResult> GetRentalRequestsByCarId(int carId)
        {
            try
            {
                var rentalRequests = await _rentalService.GetRentalRequestsByCarId(carId);
                return Ok(rentalRequests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{rentalId}")]
        

        public async Task<IActionResult> UpdateRentalRequestStatus(int rentalId, [FromBody] string status)
        {
            try
            {
                var success = await _rentalService.UpdateRentalRequestStatus(rentalId, status);
                if (!success)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{rentalId}")]
        

        public async Task<IActionResult> DeleteRentalRequest(int rentalId)
        {
            try
            {
                var success = await _rentalService.DeleteRentalRequest(rentalId);
                if (!success)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
