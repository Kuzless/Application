using Microsoft.AspNetCore.Mvc;

namespace BookingApp.API.Interfaces
{
    public interface IApiResponseHandler
    {
        IActionResult Handle(int errorCode, string message);
        IActionResult Handle<T>(T data);
    }
}
