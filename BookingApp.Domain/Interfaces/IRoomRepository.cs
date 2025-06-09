using BookingApp.Domain.Entities;

namespace BookingApp.Domain.Interfaces
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        Task<List<Room>> GetRoomsByTypeAndCapacity(int typeId, int? capacityId);
    }
}
