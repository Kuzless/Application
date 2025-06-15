using BookingApp.Application.Interfaces.Booking;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroqController : ControllerBase
    {
        private readonly IGroqBookingService _groqService;

        public GroqController(IGroqBookingService groqService)
        {
            _groqService = groqService;
        }

        [HttpPost("booking/{userId}")]
        public async Task<IActionResult> GenerateResponse([FromBody] string prompt, string userId)
        {
            var response = await _groqService.GeneratePersonalBookingResponse(prompt, userId);
            return Ok(response);
        }
    }
}
