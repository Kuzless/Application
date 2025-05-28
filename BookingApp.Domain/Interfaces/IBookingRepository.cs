using BookingApp.Domain.Entities;

namespace BookingApp.Domain.Interfaces
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        Task<List<Booking>> GetRoomBookingsForTimePeriod(int roomId, DateTime start, DateTime end);
    }
}
