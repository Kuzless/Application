using BookingApp.Application.Interfaces.Booking;
using BookingApp.Domain.Entities;
using BookingApp.Domain.Interfaces;

namespace BookingApp.Infrastructure.Services.Booking
{
    public class BookingCommandService : IBookingCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookingCommandService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Room?> FindAvailableRoom(int roomTypeId, int coworkingId, int? roomCapacityId, string startDate, string endDate, string startTime, string endTime, int? bookingId = null)
        {
            var formattedStartDate = DateOnly.Parse(startDate);
            var formattedEndDate = DateOnly.Parse(endDate);
            var formattedStartTime = TimeOnly.Parse(startTime);
            
            if (endTime == "24:00")
            {
                endTime = "00:00";
                formattedEndDate = formattedEndDate.AddDays(1);
                endDate = formattedEndDate.ToString("yyyy-MM-dd");
            }
            var formattedEndTime = TimeOnly.Parse(endTime);

            var availableRoom = await _unitOfWork.RoomRepository.GetAvailableRoom(roomTypeId, coworkingId, roomCapacityId, formattedStartDate, formattedEndDate, formattedStartTime, formattedEndTime, bookingId);
            return availableRoom;
        }
    }
}
