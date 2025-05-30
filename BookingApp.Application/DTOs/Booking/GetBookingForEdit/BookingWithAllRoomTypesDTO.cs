namespace BookingApp.Application.DTOs.Booking.GetBookingForEdit
{
    public class BookingWithAllRoomTypesDTO : BookingDTO
    {
        public List<RoomTypeWithCapacitiesDTO> RoomTypes { get; set; }
    }
}
