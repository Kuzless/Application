namespace BookingApp.Application.DTOs.Booking.GetBookingForEdit
{
    public class RoomTypeWithCapacitiesDTO : RoomTypeDTO
    {
        public List<RoomCapacityDTO> RoomCapacities { get; set; }
    }
}
