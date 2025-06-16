using BookingApp.Domain.Entities;
using BookingApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Infrastructure.Repositories
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(DatabaseContext context) : base(context)
        {

        }
        public async Task<Room?> GetAvailableRoom(int typeId, int coworkingId, int? capacityId, DateOnly startDate, DateOnly endDate, TimeOnly startTime, TimeOnly endTime, int? bookingId = null)
        {
            return await _context.Set<Room>()
                .Where(r => 
                r.RoomTypeId == typeId 
                && r.CoworkingId == coworkingId 
                && r.RoomCapacityId == capacityId 
                && !r.Bookings.Any(b =>
                    (b.StartDate <= endDate && b.EndDate >= startDate)
                    && (b.StartTime < endTime && b.EndTime > startTime)
                    && (bookingId == null || b.Id != bookingId)
                ))
                .FirstOrDefaultAsync();
        }
    }
}
