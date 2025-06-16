using BookingApp.Domain.Entities;

namespace BookingApp.Domain.Interfaces
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        Task<Room?> GetAvailableRoom(int typeId, int coworkingId, int? capacityId, DateOnly startDate, DateOnly endDate, TimeOnly startTime, TimeOnly endTime, int? bookingId = null);
    }
}
