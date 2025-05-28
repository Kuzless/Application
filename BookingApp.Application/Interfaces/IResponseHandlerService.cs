using BookingApp.Application.DTOs;

namespace BookingApp.Application.Interfaces
{
    public interface IResponseHandlerService
    {
        OperationResult Handle(int errorCode, string? message = "Unknown error");
    }
}
