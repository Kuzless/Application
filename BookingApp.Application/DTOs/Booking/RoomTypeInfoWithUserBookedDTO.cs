namespace BookingApp.Application.DTOs.Booking
{
    public class RoomTypeInfoWithUserBookedDTO : RoomTypeWithCapacitiesDTO
    {
        public List<AmenityDTO> Amenities { get; set; }
        public List<BookingWithRoomTypeDTO> BookingsWithRoomTypes { get; set; }
    }
}
