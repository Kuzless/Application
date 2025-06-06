namespace BookingApp.Application.DTOs.Booking.GetUserBookingsInfo
{
    public class UserBookingInfoDTO
    {
        public BookingDTO Booking { get; set; }
        public UserRoomInfoDTO UserRoomInfo { get; set; }
    }
}
