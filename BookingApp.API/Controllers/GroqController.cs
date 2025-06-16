using BookingApp.API.Interfaces;
using BookingApp.Application.DTOs.Groq;
using BookingApp.Application.Interfaces.Booking;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroqController : ControllerBase
    {
        private readonly IGroqBookingService _groqService;
        private readonly IApiResponseHandler _apiResponseHandler;

        public GroqController(IGroqBookingService groqService, IApiResponseHandler apiResponseHandler)
        {
            _groqService = groqService;
            _apiResponseHandler = apiResponseHandler;
        }

        [HttpPost("booking")]
        public async Task<IActionResult> GenerateBookingResponse([FromBody] UserPromptGroqDTO request)
        {
            var response = await _groqService.GeneratePersonalBookingResponse(request.Prompt, request.UserId);
            return _apiResponseHandler.Handle(response);
        }
    }
}
