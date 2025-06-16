using BookingApp.Application.DTOs;
using BookingApp.Application.Interfaces;

namespace BookingApp.Infrastructure.Services.ResponseHandling
{
    public class GroqResponseHandlerService : IResponseHandlerService
    {
        public OperationResult<T> Handle<T>(int errorCode = 500, string? message = "Unknown error", T? data = default)
        {
            switch (errorCode)
            {
                case 200:
                    return new OperationResult<T>
                    {
                        IsSuccess = true,
                        Message = "Operation completed successfully",
                        ErrorCode = 200,
                        Data = data == null ? default : data
                    };
                default:
                    return new OperationResult<T>
                    {
                        IsSuccess = false,
                        Message = $"An error occurred: {message}",
                        ErrorCode = errorCode
                    };
            }
        }
    }
}
