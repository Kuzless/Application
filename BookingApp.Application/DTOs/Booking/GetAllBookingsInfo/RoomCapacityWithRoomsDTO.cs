namespace BookingApp.Application.DTOs.Booking.GetAllBookingsInfo
{
    public class RoomCapacityWithRoomsDTO : RoomCapacityDTO
    {
        public List<RoomDTO> Rooms { get; set; }
    }
}
