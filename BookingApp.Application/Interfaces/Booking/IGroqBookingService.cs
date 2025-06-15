namespace BookingApp.Application.Interfaces.Booking
{
    public interface IGroqBookingService
    {
        Task<string> GeneratePersonalBookingResponse(string message, string userId);
    }
}
