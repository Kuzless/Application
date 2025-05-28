using BookingApp.Domain.Entities;

namespace BookingApp.Domain.Interfaces
{
    public interface IRoomTypeRepository : IGenericRepository<RoomType>
    {
        Task<List<RoomType>> GetRoomTypesWithCapacity();
    }
}
