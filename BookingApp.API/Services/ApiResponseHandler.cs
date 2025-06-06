using BookingApp.API.Interfaces;
using BookingApp.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.API.Services
{
    public class ApiResponseHandler : IApiResponseHandler
    {
        public IActionResult Handle<T>(OperationResult<T> data)
        {
            switch (data.ErrorCode)
            {
                case 200:
                    return new OkObjectResult(data) { StatusCode = 200 };
                case 400:
                    return new BadRequestObjectResult(data) { StatusCode = 400 };
                case 404:
                    return new NotFoundObjectResult(data) { StatusCode = 404 };
                case 409:
                    return new ConflictObjectResult(data) { StatusCode = 409 };
                default:
                    return new ObjectResult(data) { StatusCode = 500 };
            }
        }
    }
}
