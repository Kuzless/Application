namespace BookingApp.Application.DTOs.Booking.GetAllBookingsInfo
{
    public class BookingWithRoomDTO : BookingDTO
    {
        public RoomDTO Room { get; set; }
    }
}
