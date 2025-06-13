using BookingApp.Domain.Entities;

namespace BookingApp.Domain.Interfaces
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        Task<bool> IsRoomBookedForTimePeriod(int roomId, DateOnly startDate, DateOnly endDate, TimeOnly startTime, TimeOnly endTime, int? bookingId = null);
        Task<Booking> GetBookingWithRoomDataById(int id);
        Task<List<Booking>> GetBookingsWithRoomByUserId(int coworkingId, string userId);
        Task<List<Booking>> GetBookingsWithRoomDataByUserId(string userId);
    }
}
