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

        public async Task<List<RoomType>> GetRoomTypesWithFullInfo()
        {
            return await _context.Set<RoomType>()
                .Include(rt => rt.RoomCapacities)
                .ThenInclude(rc => rc.RoomCapacity)
                .ThenInclude(rc => rc.Rooms)
                .Include(rt => rt.RoomTypeAmenities)
                .ThenInclude(ra => ra.Amenity)
                .ToListAsync();
        }
    }
}
