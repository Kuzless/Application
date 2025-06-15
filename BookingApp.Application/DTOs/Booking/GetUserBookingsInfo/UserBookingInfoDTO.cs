namespace BookingApp.Application.DTOs.Booking.GetUserBookingsInfo
{
    public class UserBookingInfoDTO
    {
        public BookingDTO Booking { get; set; }
        public RoomDTO Room { get; set; }
        public RoomTypeDTO RoomType { get; set; }
        public RoomCapacityDTO RoomCapacity { get; set; }
    }
}
