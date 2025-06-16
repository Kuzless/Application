using BookingApp.Domain.Entities;

namespace BookingApp.Application.Interfaces.Booking
{
    public interface IBookingCommandService
    {
        Task<Room?> FindAvailableRoom(int roomTypeId, int coworkingId, int? roomCapacityId, string startDate, string endDate, string startTime, string endTime, int? bookingId = null);
    }
}
