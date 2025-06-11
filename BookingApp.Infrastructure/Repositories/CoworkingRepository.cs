using BookingApp.Domain.Entities;
using BookingApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Infrastructure.Repositories
{
    public class CoworkingRepository : GenericRepository<Coworking>, ICoworkingRepository
    {
        public CoworkingRepository(DatabaseContext context) : base(context)
        {
            
        }

        public async Task<List<Coworking>> GetCoworkingsInfoWithTypesAndRooms()
        {
            return await _context.Set<Coworking>()
                .Include(c => c.Address)
                .ThenInclude(a => a.City)
                .Include(c => c.Rooms)
                    .ThenInclude(rt => rt.RoomType)
                .ToListAsync();
        }
    }
}
