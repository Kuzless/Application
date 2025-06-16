using BookingApp.Domain.Entities;
using BookingApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Infrastructure.Repositories
{
    public class RoomTypeRepository : GenericRepository<RoomType>, IRoomTypeRepository
    {
        public RoomTypeRepository(DatabaseContext context) : base(context) { }
        public async Task<List<RoomType>> GetRoomTypesWithCapacity()
        {
            return await _context.Set<RoomType>().Include(rt => rt.RoomCapacities)
                .ThenInclude(rc => rc.RoomCapacity).ToListAsync();
        }

        public async Task<List<RoomType>> GetRoomTypesWithFullInfoByCoworkingId(int coworkingId)
        {
            return await _context.Set<RoomType>()
                .Include(rt => rt.RoomCapacities)
                .ThenInclude(rc => rc.RoomCapacity)
                .Include(rt => rt.Rooms.Where(r => r.CoworkingId == coworkingId))
                .Include(rt => rt.RoomTypeAmenities)
                .ThenInclude(ra => ra.Amenity)
                .ToListAsync();
        }
    }
}
