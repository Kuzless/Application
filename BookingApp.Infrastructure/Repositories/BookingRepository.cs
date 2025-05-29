using BookingApp.Domain.Entities;
using BookingApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Infrastructure.Repositories
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(DatabaseContext context) : base(context) { }

        public async Task<List<Booking>> GetBookingsWithRoomByCustomerEmail(string email)
        {
            return await _context.Set<Booking>()
                .Where(b => b.CustomerEmail == email)
                .Include(b => b.Room)
                .ToListAsync();
        }

        public async Task<List<Booking>> GetRoomBookingsForTimePeriod(int roomId, DateTime start, DateTime end)
        {
            var rooms = await _context.Set<Booking>().Where(b => (b.RoomId == roomId) && (b.StartDate <= end && b.EndDate >= start)).ToListAsync();
            return rooms;
        }
    }
}
