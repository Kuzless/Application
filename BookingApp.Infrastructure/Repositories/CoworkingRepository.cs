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

        public async Task<List<Coworking>> GetCoworkingsWithBookingsByUserId(string userId)
        {
            return await _context.Set<Coworking>()
                .Select(c => new Coworking
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    AddressId = c.AddressId,
                    Rooms = c.Rooms.Select(r => new Room
                    {
                        Id = r.Id,
                        RoomType = r.RoomType,
                        RoomCapacity = r.RoomCapacity,
                        Bookings = r.Bookings.Where(b => b.CustomerId == userId).ToList(),
                        CoworkingId = r.CoworkingId
                    }).Where(r => r.Bookings.Any()).ToList(),
                }).Where(c => c.Rooms.Any())
                .ToListAsync();
        }
    }
}
