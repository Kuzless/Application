using BookingApp.Domain.Entities;
using BookingApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Infrastructure.Repositories
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(DatabaseContext context) : base(context) { }

        public async Task<List<Booking>> GetBookingsWithRoomByUserId(string userId)
        {
            return await _context.Set<Booking>()
                .Where(b => b.CustomerId == userId)
                .Include(b => b.Room)
                .ToListAsync();
        }


        public async Task<Booking> GetBookingWithRoomDataById(int id)
        {
            return await _context.Set<Booking>()
                .Where(b => b.Id == id)
                .Include(b => b.Room)
                .ThenInclude(r => r.RoomType)
                .Include(b => b.Room.RoomCapacity)
                .FirstAsync();
        }

        public async Task<List<Booking>> GetBookingsWithRoomDataByUserId(string userId)
        {
            return await _context.Set<Booking>()
                .Where(b => b.CustomerId == userId)
                .Include(b => b.Room)
                .ThenInclude(r => r.RoomType)
                .Include(b => b.Room.RoomCapacity)
                .ToListAsync();
        }

        public async Task<bool> IsRoomBookedForTimePeriod(int roomId, DateOnly startDate, DateOnly endDate, TimeOnly startTime, TimeOnly endTime, int? bookingId = null)
        {
            var isBooked = await _context.Set<Booking>()
                .Where(b =>
                    b.RoomId == roomId
                    && (b.StartDate <= endDate && b.EndDate >= startDate)
                    && (b.StartTime < endTime && b.EndTime > startTime)
                    && (bookingId == null || b.Id != bookingId)
                ).AnyAsync();
            return isBooked;
        }
    }
}
