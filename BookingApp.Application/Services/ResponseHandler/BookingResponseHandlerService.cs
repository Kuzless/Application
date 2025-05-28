using BookingApp.Application.DTOs;
using BookingApp.Application.Interfaces;

namespace BookingApp.Application.Services.ErrorHandler
{
    public class BookingResponseHandlerService : IResponseHandlerService
    {
        public OperationResult Handle(int errorCode = 500, string? message = "Unknown error")
        {
            switch (errorCode)
            {
                case 200:
                    return new OperationResult
                    {
                        IsSuccess = true,
                        Message = "Booking operation completed successfully",
                        ErrorCode = 200
                    };
                case 404:
                    return new OperationResult
                    {
                        IsSuccess = false,
                        Message = "Booking not found",
                        ErrorCode = 404
                    };
                case 409:
                    return new OperationResult
                    {
                        IsSuccess = false,
                        Message = "This time is already booked",
                        ErrorCode = 409
                    };
                default:
                    return new OperationResult
                    {
                        IsSuccess = false,
                        Message = $"An error occurred: {message}",
                        ErrorCode = errorCode
                    };
            }
        }
    }
}
