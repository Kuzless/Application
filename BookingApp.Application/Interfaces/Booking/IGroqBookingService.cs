using BookingApp.Application.DTOs;

namespace BookingApp.Application.Interfaces.Booking
{
    public interface IGroqBookingService
    {
        Task<OperationResult<string>> GeneratePersonalBookingResponse(string message, string userId);
    }
}
