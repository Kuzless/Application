namespace BookingApp.Application.DTOs.Booking
{
    public class BookingWithAllRoomTypesDTO : BookingDTO
    {
        public List<RoomTypeWithCapacitiesDTO> RoomTypes { get; set; }
    }
}
