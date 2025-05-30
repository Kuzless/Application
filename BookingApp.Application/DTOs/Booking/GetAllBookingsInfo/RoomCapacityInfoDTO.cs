namespace BookingApp.Application.DTOs.Booking.GetAllBookingsInfo
{
    public class RoomCapacityInfoDTO
    {
        public RoomCapacityDTO RoomCapacity { get; set; }
        public List<RoomDTO> Rooms { get; set; }
    }
}
