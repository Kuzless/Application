namespace BookingApp.Application.DTOs.Booking.GetUserBookingsInfo
{
    public class CoworkingWithBookingsDTO
    {
        public CoworkingDTO Coworking { get; set; }
        public List<UserBookingInfoDTO> Bookings { get; set; }
    }
}
