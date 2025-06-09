namespace BookingApp.Application.DTOs.Booking.GetUserBookingsInfo
{
    public class UserRoomInfoDTO
    {
        public RoomDTO Room { get; set; }
        public RoomTypeDTO RoomType { get; set; }
        public RoomCapacityDTO RoomCapacity { get; set; }
    }
}
