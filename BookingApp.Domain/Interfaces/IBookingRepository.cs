using BookingApp.Domain.Entities;

namespace BookingApp.Domain.Interfaces
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        Task<Booking> GetBookingWithRoomDataById(int id);
        Task<List<Booking>> GetBookingsWithRoomDataByCoworkingIdAndUserId(int coworkingId, string userId);
        Task<List<Booking>> GetBookingsWithRoomDataByUserId(string userId);
    }
}
