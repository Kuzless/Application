using BookingApp.Domain.Entities;

namespace BookingApp.Domain.Interfaces
{
    public interface ICoworkingRepository : IGenericRepository<Coworking>
    {
        Task<List<Coworking>> GetCoworkingsInfoWithTypesAndRooms();
        Task<List<Coworking>> GetCoworkingsWithBookingsByUserId(string userId);
    }
}
