namespace BookingApp.Application.DTOs.Booking.GetDataForNewBooking
{
    public class NewBookingStructureDTO
    {
        public RoomTypeDTO RoomType { get; set; }
        public List<RoomCapacityDTO> RoomCapacities { get; set; }
    }
}
