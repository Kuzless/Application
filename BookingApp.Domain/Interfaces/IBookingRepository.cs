using BookingApp.Domain.Entities;

namespace BookingApp.Domain.Interfaces
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        Task<bool> IsRoomBookedForTimePeriod(int roomId, DateTime start, DateTime end);
        Task<List<Booking>> GetBookingsWithRoomByCustomerEmail(string email);
    }
}
