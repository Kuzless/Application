using BookingApp.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.API.Interfaces
{
    public interface IApiResponseHandler
    {
        IActionResult Handle<T>(OperationResult<T> data);
    }
}
