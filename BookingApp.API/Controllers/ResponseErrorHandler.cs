using Microsoft.AspNetCore.Mvc;

namespace BookingApp.API.Controllers
{
    public static class ResponseErrorHandler
    {
        public static IActionResult Handle (int errorCode, string message)
        {
            switch (errorCode)
            {
                case 200:
                    return new OkObjectResult(message);
                case 400:
                    return new BadRequestObjectResult(message);
                case 404:
                    return new NotFoundObjectResult(message);
                case 409:
                    return new ConflictObjectResult(message);
                default:
                    return new ObjectResult(message) { StatusCode = 500 };
            }
        }
    }
}
