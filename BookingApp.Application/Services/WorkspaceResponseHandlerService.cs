using BookingApp.Application.DTOs;
using BookingApp.Application.Interfaces;

namespace BookingApp.Application.Services
{
    public class WorkspaceResponseHandlerService : IResponseHandlerService
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
                case 404:
                    return new OperationResult<T>
                    {
                        IsSuccess = false,
                        Message = "Workspace not found",
                        ErrorCode = 404
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
