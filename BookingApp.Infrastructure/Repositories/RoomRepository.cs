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
        public async Task<List<Room>> GetRoomsByTypeAndCapacity(int typeId, int coworkingId, int? capacityId)
        {
            return await _context.Set<Room>()
                .Where(r => r.RoomTypeId == typeId && r.CoworkingId == coworkingId && r.RoomCapacityId == capacityId)
                .ToListAsync();
        }
    }
}
