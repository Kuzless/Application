using BookingApp.Domain.Entities;

namespace BookingApp.Domain.Interfaces
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        Task<bool> IsRoomBookedForTimePeriod(int roomId, DateOnly startDate, DateOnly endDate, TimeOnly startTime, TimeOnly endTime);
        Task<List<Booking>> GetBookingsWithRoomByUserId(string userId);
    }
}
