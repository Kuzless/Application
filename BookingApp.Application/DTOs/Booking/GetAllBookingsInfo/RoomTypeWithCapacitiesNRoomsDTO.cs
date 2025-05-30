using BookingApp.Application.DTOs.Booking.GetAllBookingsInfo;

namespace BookingApp.Application.DTOs.Booking
{
    public class RoomTypeWithCapacitiesNRoomsDTO : RoomTypeDTO
    {
        public List<RoomCapacityWithRoomsDTO> RoomCapacities { get; set; }
    }
}
