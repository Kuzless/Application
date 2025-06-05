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

        public async Task<bool> IsRoomBookedForTimePeriod(int roomId, DateOnly startDate, DateOnly endDate, TimeOnly startTime, TimeOnly endTime)
        {
            var isBooked = await _context.Set<Booking>().Where(b => 
            (b.RoomId == roomId) 
            && (b.StartDate <= endDate && b.EndDate >= startDate)
            && (b.StartTime < endTime && b.EndTime > startTime)
            ).AnyAsync();
            return isBooked;
        }
    }
}
