using BookingApp.Application.DTOs;

namespace BookingApp.Application.Interfaces
{
    public interface IResponseHandlerService
    {
        OperationResult<T> Handle<T>(int errorCode, string? message = "Unknown error", T? data = default);
    }
}
